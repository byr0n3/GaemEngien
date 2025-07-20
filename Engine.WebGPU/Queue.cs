using JetBrains.Annotations;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents a queue that can be used to submit command buffers and write data to GPU buffers.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Queue : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Gets a value indicating whether the queue is valid.
		/// </summary>
		public bool IsValid =>
			this.handle != default;

		/// <summary>
		/// Submits a command buffer to the queue.
		/// </summary>
		/// <param name="command">The command buffer to submit.</param>
		public void Submit(CommandBuffer command) =>
			QueueNative.Submit(this, 1, command);

		/// <summary>
		/// Submits multiple command buffers to the queue.
		/// </summary>
		/// <param name="commands">The array of command buffers to submit.</param>
		public void Submit(scoped System.ReadOnlySpan<CommandBuffer> commands) =>
			QueueNative.Submit(this, commands.Length, commands.GetPinnableReference());

		/// <summary>
		/// Writes data to a GPU buffer at a specified offset.
		/// </summary>
		/// <typeparam name="TValue">The type of data elements being written. Must be unmanaged.</typeparam>
		/// <param name="buffer">The target GPU buffer.</param>
		/// <param name="bufferOffset">The starting offset in the buffer where data will be written.</param>
		/// <param name="data">A read-only span containing the data to write into the buffer.</param>
		public unsafe void WriteBuffer<TValue>(GpuBuffer buffer, ulong bufferOffset, scoped System.ReadOnlySpan<TValue> data)
			where TValue : unmanaged
		{
			var size = sizeof(TValue) * data.Length;

			fixed (void* ptr = data)
			{
				this.WriteBuffer(buffer, bufferOffset, ptr, size);
			}
		}

		/// <summary>
		/// Writes data to a GPU buffer at a specified offset.
		/// </summary>
		/// <param name="buffer">The target GPU buffer to write to.</param>
		/// <param name="bufferOffset">The byte offset within the buffer where writing starts.</param>
		/// <param name="data">The span containing the data to write to the buffer.</param>
		/// <param name="size">The total size of the data.</param>
		public unsafe void WriteBuffer(GpuBuffer buffer, ulong bufferOffset, void* data, nint size) =>
			QueueNative.WriteBuffer(this, buffer, bufferOffset, data, size);

		public unsafe void WriteTexture(TexelCopyTextureInfo destination,
										void* data,
										nint dataSize,
										TexelCopyBufferLayout dataLayout,
										Extent3D writeSize) =>
			QueueNative.WriteTexture(this, destination, data, dataSize, dataLayout, writeSize);

		/// <summary>
		/// Releases the resources held by the queue.
		/// </summary>
		public void Dispose() =>
			QueueNative.Release(this);
	}
}
