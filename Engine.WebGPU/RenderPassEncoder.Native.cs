using System.Runtime.InteropServices;
using Engine.Native;
using wgpu.Enums;
using wgpu.Internal;

namespace wgpu
{
	internal static class RenderPassEncoderNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuRenderPassEncoderRelease")]
		public static extern void Release(RenderPassEncoder renderPassEncoder);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuRenderPassEncoderEnd")]
		public static extern void End(RenderPassEncoder renderPassEncoder);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuRenderPassEncoderSetPipeline")]
		public static extern void SetPipeline(RenderPassEncoder renderPassEncoder, RenderPipeline pipeline);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuRenderPassEncoderDraw")]
		public static extern void Draw(RenderPassEncoder renderPassEncoder,
									   uint vertexCount,
									   uint instanceCount,
									   uint firstVertex,
									   uint firstInstance);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuRenderPassEncoderSetVertexBuffer")]
		public static extern void SetVertexBuffer(RenderPassEncoder renderPassEncoder,
												  uint slot,
												  GpuBuffer buffer,
												  ulong offset,
												  ulong size);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuRenderPassEncoderSetIndexBuffer")]
		public static extern void SetIndexBuffer(RenderPassEncoder renderPassEncoder,
												 GpuBuffer buffer,
												 IndexFormat format,
												 ulong offset,
												 ulong size);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuRenderPassEncoderSetBindGroup")]
		public static extern void SetBindGroup(RenderPassEncoder renderPassEncoder,
											   uint groupIndex,
											   BindGroup group,
											   nint dynamicOffsetCount,
											   Pointer<uint> dynamicOffsets);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuRenderPassEncoderDrawIndexed")]
		public static extern void DrawIndexed(RenderPassEncoder renderPassEncoder,
											  uint indexCount,
											  uint instanceCount,
											  uint firstIndex,
											  uint baseVertex,
											  uint firstInstance);
	}
}
