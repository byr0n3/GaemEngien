using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class PipelineLayoutNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuPipelineLayoutRelease")]
		public static extern void Release(PipelineLayout pipelineLayout);
	}
}
