namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Defines the texture target used when attaching a texture to a framebuffer object.
	/// </summary>
	public enum FramebufferTextureTarget
	{
		/// <summary>
		/// Represents the absence of a specific texture target when attaching a texture to a framebuffer object.
		/// </summary>
		None = 0,

		/// <summary>
		/// Indicates that the framebuffer texture attachment targets a 2‑dimensional texture.
		/// </summary>
		Texture2D = 0x0DE1,

		/// <summary>
		/// Specifies the positive X face of a cube‑map texture when attaching it to a framebuffer object.
		/// </summary>
		TextureCubeMapPositiveX = 0x8515,

		/// <summary>
		/// Specifies the negative X face of a cube‑map texture when attaching it to a framebuffer object.
		/// </summary>
		TextureCubeMapNegativeX = 0x8516,

		/// <summary>
		/// Specifies the positive Y face of a cube‑map texture when attaching it to a framebuffer object.
		/// </summary>
		TextureCubeMapPositiveY = 0x8517,

		/// <summary>
		/// Specifies the negative Y face of a cube‑map texture when attaching it to a framebuffer object.
		/// </summary>
		TextureCubeMapNegativeY = 0x8518,

		/// <summary>
		/// Specifies the positive Z face of a cube‑map texture when attaching it to a framebuffer object.
		/// </summary>
		TextureCubeMapPositiveZ = 0x8519,

		/// <summary>
		/// Specifies the negative Z face of a cube‑map texture when attaching it to a framebuffer object.
		/// </summary>
		TextureCubeMapNegativeZ = 0x851A,
	}
}
