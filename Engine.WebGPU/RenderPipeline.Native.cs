using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class RenderPipelineNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuRenderPipelineRelease")]
		public static extern void Release(RenderPipeline renderPipeline);
	}
}
