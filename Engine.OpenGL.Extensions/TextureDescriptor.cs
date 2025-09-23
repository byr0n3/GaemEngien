using System.Runtime.InteropServices;
using Engine.OpenGL.Enums;
using JetBrains.Annotations;

namespace Engine.OpenGL.Extensions
{
	/// <summary>
	/// Describes the configuration of an OpenGL texture resource.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TextureDescriptor
	{
		/// <summary>
		/// Gets the target of the texture in OpenGL.
		/// </summary>
		public TextureTarget Target { get; init; } = TextureTarget.Texture2D;

		/// <summary>
		/// Gets the wrap mode applied to the texture's S (horizontal) coordinate.
		/// </summary>
		/// <remarks>Default value is <c>GL_REPEAT</c>.</remarks>
		public int WrapS { get; init; } = 0x2901;

		/// <summary>
		/// Gets the wrap mode applied to the texture's T (vertical) coordinate.
		/// </summary>
		/// <remarks>Default value is <c>GL_REPEAT</c>.</remarks>
		public int WrapT { get; init; } = 0x2901;

		/// <summary>
		/// Gets the texture minifying filter applied when a texture is sampled at a lower resolution than its native size.
		/// </summary>
		/// <remarks>Default value is <c>GL_LINEAR</c>.</remarks>
		public int MinFilter { get; init; } = 0x2601;

		/// <summary>
		/// Gets the texture minifying filter applied when a texture is sampled at a higher resolution than its native size.
		/// </summary>
		/// <remarks>Default value is <c>GL_LINEAR</c>.</remarks>
		public int MagFilter { get; init; } = 0x2601;

		/// <summary>
		/// Gets the internal format of the texture as defined by the <see cref="TextureFormat"/> enumeration.
		/// This property specifies how the texture’s pixel data is stored internally, influencing the number of
		/// color components and the precision of each component used by OpenGL when the texture is bound.
		/// </summary>
		public TextureFormat InternalFormat { get; init; } = TextureFormat.Rgb;

		/// <summary>
		/// Specifies the format of the pixel data for the texture.
		/// This value is passed to the OpenGL texture upload functions and determines how the pixel components are interpreted.
		/// </summary>
		public TextureFormat Format { get; init; } = TextureFormat.Rgb;

		/// <summary>
		/// Gets or sets a value that specifies whether the image data should be vertically flipped during texture loading.
		/// </summary>
		public bool Flip { get; init; }

		/// <summary>
		/// Indicates whether mipmaps should be automatically generated for the texture.
		/// </summary>
		public bool GenerateMipmap { get; init; } = true;

		/// <inheritdoc cref="TextureDescriptor"/>
		public TextureDescriptor()
		{
		}
	}
}
