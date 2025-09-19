namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Represents the target of a texture in OpenGL.
	/// </summary>
	public enum TextureTarget
	{
		/// <summary>
		/// Specifies that no texture target is selected.
		/// </summary>
		None,

		/// <summary>
		/// Specifies a one-dimensional texture target.
		/// </summary>
		Texture1D = 0x0DE0,

		/// <summary>
		/// Specifies the target for a two-dimensional texture.
		/// </summary>
		Texture2D = 0x0DE1,

		/// <summary>
		/// Specifies a three-dimensional texture target.
		/// </summary>
		Texture3D = 0x806F,

		/// <summary>
		/// Specifies a rectangle texture target in OpenGL.
		/// </summary>
		TextureRectangle = 0x84F5,

		/// <summary>
		/// Specifies the target for a cube map texture.
		/// </summary>
		TextureCubeMap = 0x8513,

		/// <summary>
		/// Specifies a one-dimensional texture array target in OpenGL.
		/// </summary>
		Texture1DArray = 0x8C18,

		/// <summary>
		/// Specifies a two-dimensional texture array target.
		/// </summary>
		Texture2DArray = 0x8C1A,

		/// <summary>
		/// Specifies the texture buffer target, which is used for buffer textures in OpenGL.
		/// </summary>
		TextureBuffer = 0x8C2A,

		/// <summary>
		/// Specifies the target for a texture that is an array of cube maps.
		/// </summary>
		TextureCubeMapArray = 0x9009,

		/// <summary>
		/// Represents a texture target for a multisample 2D texture in OpenGL.
		/// </summary>
		Texture2DMultisample = 0x9100,

		/// <summary>
		/// Specifies that the texture target is a 2D multisample array.
		/// </summary>
		Texture2DMultisampleArray = 0x9102,
	}
}
