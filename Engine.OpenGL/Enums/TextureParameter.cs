namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Represents various texture parameters used in OpenGL.
	/// </summary>
	public enum TextureParameter
	{
		/// <summary>
		/// Represents the absence of any texture parameter.
		/// This member is typically used to indicate that no specific parameter has been set or should be applied.
		/// </summary>
		None,

		/// <summary>
		/// Represents the magnification filter parameter for textures.
		/// This member is used to specify how texture pixels are filtered when they are magnified (enlarged) on the screen.
		/// </summary>
		MagFilter = 0x2800,

		/// <summary>
		/// Specifies the method used to compute texture coordinates when a texture is minified.
		/// This parameter controls how textures are filtered when they are scaled down in size on the screen.
		/// </summary>
		MinFilter = 0x2801,

		/// <summary>
		/// Specifies the wrapping function for texture coordinate S.
		/// This parameter determines how the texture coordinates are wrapped when they exceed the range [0.0, 1.0].
		/// </summary>
		WrapS = 0x2802,

		/// <summary>
		/// Specifies the texture wrapping function for the T coordinate.
		/// This member is used to determine how the texture is wrapped when the T coordinate goes beyond the range [0, 1].
		/// </summary>
		WrapT = 0x2803,
	}
}
