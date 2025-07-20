using System.Runtime.InteropServices;
using wgpu.Enums;

namespace wgpu.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TexelCopyTextureInfo
	{
		public Texture Texture { get; init; }

		public uint MipLevel { get; init; }

		public Origin3D Origin { get; init; }

		public TextureAspect TextureAspect { get; init; }
	}
}
