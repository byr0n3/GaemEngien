using Engine.Shared;
using JetBrains.Annotations;
using wgpu.Enums;

namespace wgpu
{
	/// <summary>
	/// A struct representing a render pass encoder used to record draw and dispatch commands.
	/// </summary>
	[MustDisposeResource]
	public readonly struct RenderPassEncoder : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Sets the rendering pipeline for the render pass encoder.
		/// </summary>
		/// <param name="pipeline">The render pipeline to set.</param>
		public void SetPipeline(RenderPipeline pipeline) =>
			RenderPassEncoderNative.SetPipeline(this, pipeline);

		/// <summary>
		/// Sets the vertex buffer for a specific slot in the render pass encoder.
		/// </summary>
		/// <param name="slot">The index of the vertex buffer slot to set.</param>
		/// <param name="buffer">The GPU buffer containing the vertex data.</param>
		public void SetVertexBuffer(uint slot, GpuBuffer buffer) =>
			RenderPassEncoderNative.SetVertexBuffer(this, slot, buffer, 0, buffer.Size);

		/// <summary>
		/// Sets the vertex buffer for a specific slot in the render pass encoder.
		/// </summary>
		/// <param name="slot">The index of the vertex buffer slot to set.</param>
		/// <param name="buffer">The GPU buffer containing the vertex data.</param>
		/// <param name="offset">The offset from the start of the buffer where the data begins.</param>
		/// <param name="size">The size in bytes of the vertex data to be used.</param>
		public void SetVertexBuffer(uint slot, GpuBuffer buffer, ulong offset, ulong size) =>
			RenderPassEncoderNative.SetVertexBuffer(this, slot, buffer, offset, size);

		/// <summary>
		/// Sets the index buffer for the render pass encoder.
		/// </summary>
		/// <param name="buffer">The GPU buffer to set as the index buffer.</param>
		/// <param name="format">The format of the indices in the buffer.</param>
		public void SetIndexBuffer(GpuBuffer buffer, IndexFormat format) =>
			RenderPassEncoderNative.SetIndexBuffer(this, buffer, format, 0, buffer.Size);

		/// <summary>
		/// Sets the index buffer for the render pass encoder.
		/// </summary>
		/// <param name="buffer">The GPU buffer to set as the index buffer.</param>
		/// <param name="format">The format of the index data in the buffer (e.g., Uint16, Uint32).</param>
		/// <param name="offset">The byte offset within the buffer where the index data begins.</param>
		/// <param name="size">The size in bytes of the memory range containing the index data to use for drawing.</param>
		public void SetIndexBuffer(GpuBuffer buffer, IndexFormat format, ulong offset, ulong size) =>
			RenderPassEncoderNative.SetIndexBuffer(this, buffer, format, offset, size);

		/// <summary>
		/// Sets the bind group for a specific index in the render pass encoder.
		/// </summary>
		/// <param name="groupIndex">The index of the bind group to set.</param>
		/// <param name="group">The bind group to set.</param>
		/// <param name="dynamicOffsets">A span containing dynamic offsets for the bind group.</param>
		public unsafe void SetBindGroup(uint groupIndex, BindGroup group, scoped System.ReadOnlySpan<uint> dynamicOffsets)
		{
			fixed (uint* pDynamicOffsets = dynamicOffsets)
			{
				RenderPassEncoderNative.SetBindGroup(this, groupIndex, group, dynamicOffsets.Length, dynamicOffsets);
			}
		}

		/// <summary>
		/// Sets the bind group for the render pass encoder.
		/// </summary>
		/// <param name="groupIndex">The index of the bind group to set.</param>
		/// <param name="group">The bind group to set.</param>
		/// <param name="dynamicOffsetCount">The number of dynamic offsets.</param>
		/// <param name="dynamicOffsets">A pointer to an array of dynamic offsets.</param>
		public void SetBindGroup(uint groupIndex, BindGroup group, nint dynamicOffsetCount = 0, Pointer<uint> dynamicOffsets = default) =>
			RenderPassEncoderNative.SetBindGroup(this, groupIndex, group, dynamicOffsetCount, dynamicOffsets);

		/// <summary>
		/// Issues a draw command for the render pass encoder.
		/// </summary>
		/// <param name="vertexCount">The number of vertices to draw.</param>
		/// <param name="instanceCount">The number of instances to draw.</param>
		/// <param name="firstVertex">The starting vertex index to draw from.</param>
		/// <param name="firstInstance">The starting instance index to draw from.</param>
		public void Draw(uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance) =>
			RenderPassEncoderNative.Draw(this, vertexCount, instanceCount, firstVertex, firstInstance);

		/// <summary>
		/// Draws indexed geometry.
		/// </summary>
		/// <param name="indexCount">The number of indices to draw.</param>
		/// <param name="instanceCount">The number of instances to draw.</param>
		/// <param name="firstIndex">The starting index within the index buffer.</param>
		/// <param name="baseVertex">The base vertex offset for indexing into the vertex buffer.</param>
		/// <param name="firstInstance">The instance ID of the first instance to draw.</param>
		public void DrawIndexed(uint indexCount, uint instanceCount, uint firstIndex, uint baseVertex, uint firstInstance) =>
			RenderPassEncoderNative.DrawIndexed(this, indexCount, instanceCount, firstIndex, baseVertex, firstInstance);

		/// <summary>
		/// Finalizes the current render pass encoder.
		/// </summary>
		public void End() =>
			RenderPassEncoderNative.End(this);

		/// <summary>
		/// Releases the unmanaged resources used by the render pass encoder.
		/// </summary>
		public void Dispose() =>
			RenderPassEncoderNative.Release(this);
	}
}
