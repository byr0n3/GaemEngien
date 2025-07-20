using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class SurfaceCapabilitiesNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuSurfaceCapabilitiesFreeMembers")]
		public static extern void FreeMembers(SurfaceCapabilities capabilities);
	}
}
