using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Enums;
using wgpu.Internal;

namespace wgpu
{
	internal static class SurfaceNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuSurfaceRelease")]
		public static extern void Release(Surface surface);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuSurfaceGetCapabilities")]
		public static extern Status GetCapabilities(Surface surface, Adapter adapter, Pointer<SurfaceCapabilities> capabilities);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuSurfaceConfigure")]
		public static extern void Configure(Surface surface, Pointer<SurfaceConfiguration> configuration);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuSurfaceGetCurrentTexture")]
		public static extern void GetCurrentTexture(Surface surface, Pointer<SurfaceTexture> texture);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuSurfacePresent")]
		public static extern void Present(Surface surface);
	}
}
