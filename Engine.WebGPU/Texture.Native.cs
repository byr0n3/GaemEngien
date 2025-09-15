using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Enums;
using wgpu.Internal;

namespace wgpu
{
	internal static class TextureNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuTextureDestroy")]
		public static extern void Destroy(Texture texture);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuTextureRelease")]
		public static extern void Release(Texture texture);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuTextureGetFormat")]
		public static extern TextureFormat GetFormat(Texture texture);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuTextureCreateView")]
		public static extern TextureView CreateView(Texture texture, Pointer<TextureViewDescriptor> descriptor);
	}
}
