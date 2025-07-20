using JetBrains.Annotations;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// A command encoder used to encode commands for submission to a device.
	/// </summary>
	public readonly struct CommandEncoder : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Begins a render pass.
		/// </summary>
		/// <param name="descriptor">The descriptor that defines the parameters for the render pass.</param>
		/// <returns>A new instance of <see cref="RenderPassEncoder"/> representing the started render pass.</returns>
		[MustDisposeResource]
		public RenderPassEncoder BeginRenderPass(in RenderPassEncoderDescriptor descriptor) =>
			CommandEncoderNative.BeginRenderPass(this, descriptor);

		/// <summary>
		/// Finishes the command encoding and returns a new command buffer.
		/// </summary>
		/// <returns>A new instance of <see cref="CommandBuffer"/> representing the finished command buffer.</returns>
		[MustDisposeResource]
		public CommandBuffer Finish() =>
			CommandEncoderNative.Finish(this, null);

		/// <summary>
		/// Finishes the command encoding and returns a new command buffer.
		/// </summary>
		/// <param name="descriptor">The descriptor that defines the parameters for finishing the command encoding.</param>
		/// <returns>A new instance of <see cref="CommandBuffer"/> representing the finished commands.</returns>
		[MustDisposeResource]
		public CommandBuffer Finish(in BasicDescriptor descriptor) =>
			CommandEncoderNative.Finish(this, descriptor);

		/// <summary>
		/// Copies data from one buffer to another.
		/// </summary>
		/// <param name="source">The source buffer from which data is copied.</param>
		/// <param name="sourceOffset">The starting offset within the source buffer from where copying begins.</param>
		/// <param name="destination">The destination buffer to which data is copied.</param>
		/// <param name="destinationOffset">The starting offset within the destination buffer where the copy operation starts.</param>
		/// <param name="size">The size of the data being copied, in bytes.</param>
		public void CopyBufferToBuffer(GpuBuffer source, ulong sourceOffset, GpuBuffer destination, ulong destinationOffset, ulong size) =>
			CommandEncoderNative.CopyBufferToBuffer(this, source, sourceOffset, destination, destinationOffset, size);

		/// <summary>
		/// Releases the resources held by this instance.
		/// </summary>
		public void Dispose() =>
			CommandEncoderNative.Release(this);
	}
}
