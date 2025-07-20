using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class SamplerNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuSamplerRelease")]
		public static extern void Release(Sampler sampler);
	}
}
