using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class TextureViewNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuTextureViewRelease")]
		public static extern void Release(TextureView texture);
	}
}
