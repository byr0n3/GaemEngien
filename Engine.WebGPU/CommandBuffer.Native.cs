using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class CommandBufferNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuCommandBufferRelease")]
		public static extern void Release(CommandBuffer commandBuffer);
	}
}
