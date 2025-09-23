using System.IO;
using System.Runtime.CompilerServices;
using Engine.OpenGL.Enums;
using JetBrains.Annotations;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace Engine.OpenGL.Extensions
{
	/// <summary>
	/// Provides static methods for working with OpenGL textures.
	/// </summary>
	public static class Textures
	{
		/// <summary>
		/// Loads a texture from the specified file path using the provided descriptor.
		/// </summary>
		/// <param name="filePath">The path to the image file to load.</param>
		/// <param name="descriptor">A descriptor that specifies texture parameters such as target, wrap mode, filtering, etc.</param>
		/// <returns>A <see cref="Texture"/> instance representing the loaded texture.</returns>
		/// <exception cref="System.ArgumentException">
		/// Thrown if the file does not exist at the specified <paramref name="filePath"/>.
		/// </exception>
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
