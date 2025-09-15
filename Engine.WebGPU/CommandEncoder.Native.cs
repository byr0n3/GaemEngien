using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Internal;
using wgpu.Structs;

namespace wgpu
{
	internal static class CommandEncoderNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuCommandEncoderRelease")]
		public static extern void Release(CommandEncoder encoder);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuCommandEncoderBeginRenderPass")]
		public static extern RenderPassEncoder BeginRenderPass(CommandEncoder encoder, Pointer<RenderPassEncoderDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuCommandEncoderFinish")]
		public static extern CommandBuffer Finish(CommandEncoder encoder, Pointer<BasicDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuCommandEncoderCopyBufferToBuffer")]
		public static extern void CopyBufferToBuffer(CommandEncoder encoder,
													 GpuBuffer source,
													 ulong sourceOffset,
													 GpuBuffer destination,
													 ulong destinationOffset,
													 ulong size);
	}
}
