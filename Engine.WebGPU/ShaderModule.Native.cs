using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class ShaderModuleNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuShaderModuleRelease")]
		public static extern void Release(ShaderModule shaderModule);
	}
}
