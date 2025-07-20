using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using JetBrains.Annotations;
using wgpu.Internal.Enums;
using wgpu.Internal.Structs;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents an instance of a WebGPU device that manages the creation and disposal of GPU resources.
	/// </summary>
	[PublicAPI]
	[MustDisposeResource]
	public readonly unsafe struct Instance : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Gets a value indicating whether the instance is valid.
		/// </summary>
		public bool IsValid =>
			this.handle != default;

		/// <summary>
		/// Represents an instance of a WebGPU device that manages the creation and disposal of GPU resources.
		/// </summary>
		[MustDisposeResource]
		public Instance()
		{
			this = InstanceNative.Create(null);
		}

		/// <summary>
		/// Represents an instance of a WebGPU device that manages the creation and disposal of GPU resources.
		/// </summary>
		/// <param name="descriptor">The descriptor describing the parameters for the instance.</param>
		[MustDisposeResource]
		public Instance(in InstanceDescriptor descriptor)
		{
			fixed (InstanceDescriptor* ptr = &descriptor)
			{
				this = InstanceNative.Create(ptr);
			}
		}

		/// <summary>
		/// Creates a new surface based on the provided descriptor.
		/// </summary>
		/// <param name="descriptor">The basic descriptor used to create the surface.</param>
		/// <returns>A newly created surface instance.</returns>
		[MustDisposeResource]
		public Surface CreateSurface(in BasicDescriptor descriptor)
		{
			Debug.Assert(this.IsValid);

			fixed (BasicDescriptor* ptr = &descriptor)
			{
				return InstanceNative.CreateSurface(this, ptr);
			}
		}

		/// <summary>
		/// Requests an adapter from the instance with specified options.
		/// </summary>
		/// <param name="options">The options to use when requesting the adapter.</param>
		/// <returns>An <see cref="Adapter"/> object representing the requested adapter.</returns>
		[MustDisposeResource]
		public Adapter RequestAdapter(in RequestAdapterOptions options)
		{
			Debug.Assert(this.IsValid);

			Adapter result = default;

			fixed (RequestAdapterOptions* optionsPtr = &options)
			{
				var callbackInfo = new RequestCallbackInfo<Adapter>
				{
					Callback = &Handler,
					UserData1 = &result,
				};

				_ = InstanceNative.RequestAdapter(this, optionsPtr, callbackInfo);
			}

			Debug.Assert(result.IsValid, "Failed to receive a valid adapter in time");

			return result;

			[UnmanagedCallersOnly]
			static void Handler(RequestStatus status, Adapter adapter, StringView message, void* userData1, void* _)
			{
				if (status == RequestStatus.Success)
				{
					Unsafe.AsRef<Adapter>(userData1) = adapter;
				}
				else
				{
					Debug.Fail($"wgpuInstanceRequestAdapter failed: {status.ToString()}", message.ToString());
				}
			}
		}

		/// <summary>
		/// Releases all resources used by the current instance of the <see cref="Instance"/> class.
		/// </summary>
		public void Dispose()
		{
			Debug.Assert(this.IsValid);

			InstanceNative.Release(this);
		}
	}
}
