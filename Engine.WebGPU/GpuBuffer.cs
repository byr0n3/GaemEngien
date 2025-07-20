using System.Diagnostics;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using wgpu.Flags;
using wgpu.Internal.Enums;
using wgpu.Internal.Structs;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents a GPU buffer, which is a contiguous block of memory used for storing data on the GPU.
	/// </summary>
	[MustDisposeResource]
	public readonly struct GpuBuffer : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Gets the size of the GPU buffer in bytes.
		/// </summary>
		public ulong Size =>
			BufferNative.GetSize(this);

		/// <summary>
		/// Maps the buffer to a CPU-accessible memory range.
		/// </summary>
		/// <param name="device">The device used to poll for completion of mapping operation.</param>
		/// <param name="mode">Specifies the mapping mode, which can be read or write.</param>
		/// <param name="offset">The offset from the start of the buffer in bytes.</param>
		/// <param name="size">The size of the range to map in bytes.</param>
		/// <returns>A structure representing the mapped buffer.</returns>
		[MustDisposeResource]
		public unsafe MappedBuffer Map(Device device, MapMode mode, uint offset, uint size)
		{
			var state = 0;

			var callbackInfo = new BufferMapCallbackInfo
			{
				Callback = &Handle,
				UserData1 = &state,
			};

			BufferNative.MapAsync(this, mode, (nint)offset, (nint)size, callbackInfo);

			while (state != 1)
			{
				device.Poll(false, default);
			}

			var dataPtr = BufferNative.GetConstMappedRange(this, (nint)offset, (nint)size);

			return new MappedBuffer(this, dataPtr);

			[UnmanagedCallersOnly]
			static void Handle(MapAsyncStatus status, StringView message, void* statePtr, void* _)
			{
				if (status != MapAsyncStatus.Success)
				{
					Debug.Fail($"bufferMapAsync failed with status {status.ToString()}: {message.ToString()}");
					return;
				}

				(*(int*)statePtr) = 1;
			}
		}

		/// <summary>
		/// Releases the unmanaged resources used by the buffer and optionally releases the managed resources.
		/// </summary>
		public void Dispose()
		{
			BufferNative.Destroy(this);
			BufferNative.Release(this);
		}

		/// <summary>
		/// Represents a mapped buffer, which is a CPU-accessible memory range of a <see cref="GpuBuffer"/>.
		/// </summary>
		[MustDisposeResource]
		[StructLayout(LayoutKind.Sequential)]
		public readonly unsafe struct MappedBuffer : System.IDisposable
		{
			private readonly void* ptr;
			private readonly GpuBuffer buffer;

			/// <summary>
			/// Gets a value indicating whether the mapped buffer is valid and not null.
			/// </summary>
			public bool IsValid =>
				this.ptr != null;

			internal MappedBuffer(GpuBuffer buffer, void* ptr)
			{
				this.ptr = ptr;
				this.buffer = buffer;
			}

			/// <summary>
			/// Gets a pointer to the mapped data in the buffer.
			/// </summary>
			/// <typeparam name="TValue">The type of the elements in the buffer.</typeparam>
			/// <returns>A pointer to the first element of type <typeparam cref="TValue"/> in the mapped range.</returns>
			public TValue* GetPointer<TValue>()
				where TValue : unmanaged =>
				(TValue*)this.ptr;

			/// <summary>
			/// Releases the resources used by this GPU buffer.
			/// </summary>
			public void Dispose() =>
				BufferNative.Unmap(this.buffer);
		}
	}
}
