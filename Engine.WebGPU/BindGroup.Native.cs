using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class BindGroupNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuBindGroupRelease")]
		public static extern void Release(BindGroup bindGroup);
	}
}
