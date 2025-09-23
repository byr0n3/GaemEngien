using System.Runtime.InteropServices;
using Engine.OpenGL.Enums;

namespace Engine.OpenGL.Extensions
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TextureDescriptor
	{
		public TextureTarget Target { get; init; } = TextureTarget.Texture2D;

		public int WrapS { get; init; } = 0x2901;

		public int WrapT { get; init; } = 0x2901;

		public int MinFilter { get; init; } = 0x2601;

		public int MagFilter { get; init; } = 0x2601;

		public TextureFormat InternalFormat { get; init; } = TextureFormat.Rgb;

		public TextureFormat Format { get; init; } = TextureFormat.Rgb;

		public bool Flip { get; init; }

		public bool GenerateMipmap { get; init; } = true;

		public TextureDescriptor()
		{
		}
	}
}
