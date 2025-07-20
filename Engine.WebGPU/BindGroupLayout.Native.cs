using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class BindGroupLayoutNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuBindGroupLayoutRelease")]
		public static extern void Release(BindGroupLayout bindGroupLayout);
	}
}
