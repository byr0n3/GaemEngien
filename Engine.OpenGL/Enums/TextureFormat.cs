namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Represents the format of a texture.
	/// </summary>
	public enum TextureFormat
	{
		/// <summary>
		/// Represents a texture with no specific format. This member can be used as a default or placeholder value.
		/// </summary>
		None,

		/// <summary>
		/// Represents a texture format used for stencil indices,
		/// with each element being an index into the stencil buffer.
		/// </summary>
		StencilIndex = 0x1901,

		/// <summary>
		/// Represents a texture format that contains depth information.
		/// This is typically used for depth textures in OpenGL.
		/// </summary>
		DepthComponent = 0x1902,

		/// <summary>
		/// Represents a texture with a single red color channel.
		/// </summary>
		Red = 0x1903,

		/// <summary>
		/// Represents a texture with RGB color components.
		/// This member is used for textures that store red, green, and blue channels.
		/// </summary>
		Rgb = 0x1907,

		/// <summary>
		/// Represents a texture with red, green, blue, and alpha components.
		/// This member is used for textures that include transparency.
		/// </summary>
		Rgba = 0x1908,

		/// <summary>
		/// Represents a texture with blue-green-red color channel ordering.
		/// </summary>
		Bgr = 0x80E0,

		/// <summary>
		/// Represents a texture in BGRA (Blue, Green, Red, Alpha) format.
		/// </summary>
		Bgra = 0x80E1,

		/// <summary>
		/// Represents a texture with 2 components per pixel: red and green.
		/// This format is often used for normal maps or other textures where only two color channels are required.
		/// </summary>
		Rg = 0x8227,

		/// <summary>
		/// Represents a texture format with two color components (red and green) in integer form.
		/// </summary>
		RgInteger = 0x8228,

		/// <summary>
		/// Represents a texture format that includes both depth and stencil components.
		/// </summary>
		DepthStencil = 0x84F9,

		/// <summary>
		/// Represents a texture format that stores red color components as integers.
		/// </summary>
		RedInteger = 0x8D94,

		/// <summary>
		/// Represents a texture with RGB components in integer format.
		/// </summary>
		RgbInteger = 0x8D98,

		/// <summary>
		/// Represents a texture format where each pixel is stored as an RGBA integer.
		/// </summary>
		RgbaInteger = 0x8D99,

		/// <summary>
		/// Represents a texture with a BGR integer format.
		/// This member is used for textures that store blue, green, and red components as signed integers.
		/// </summary>
		BgrInteger = 0x8D9A,

		/// <summary>
		/// Represents a texture format with BGRA (Blue, Green, Red, Alpha) integer components.
		/// </summary>
		BgraInteger = 0x8D9B,
	}
}
