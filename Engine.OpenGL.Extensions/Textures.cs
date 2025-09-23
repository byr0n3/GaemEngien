using System.IO;
using System.Runtime.CompilerServices;
using Engine.OpenGL.Enums;
using JetBrains.Annotations;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Engine.OpenGL.Extensions
{
	public static class Textures
	{
		[MustDisposeResource]
		public static Texture LoadFromFile(string filePath, in TextureDescriptor descriptor)
		{
			if (!File.Exists(filePath))
			{
				throw new System.ArgumentException($"File doesn't exist at: {Path.GetFullPath(filePath)}", nameof(filePath));
			}

			var texture = new Texture();

			texture.Bind(descriptor.Target);

			Texture.SetParameter(descriptor.Target, TextureParameter.WrapS, descriptor.WrapS);
			Texture.SetParameter(descriptor.Target, TextureParameter.WrapT, descriptor.WrapT);
			Texture.SetParameter(descriptor.Target, TextureParameter.MinFilter, descriptor.MinFilter);
			Texture.SetParameter(descriptor.Target, TextureParameter.MagFilter, descriptor.MagFilter);

			using (var image = Image.Load<Rgba32>(filePath))
			{
				System.Span<byte> buffer = stackalloc byte[image.Width * image.Height * Unsafe.SizeOf<Rgba32>()];

				if (descriptor.Flip)
				{
					image.Mutate(static (x) => x.Flip(FlipMode.Vertical));
				}

				image.CopyPixelDataTo(buffer);

				Texture.Image2D<byte>(descriptor.Target,
									  0,
									  descriptor.InternalFormat,
									  image.Width,
									  image.Height,
									  descriptor.Format,
									  TextureType.UnsignedByte,
									  buffer);
			}

			if (descriptor.GenerateMipmap)
			{
				Texture.GenerateMipmap(descriptor.Target);
			}

			Texture.Unbind(descriptor.Target);

			return texture;
		}
	}
}
