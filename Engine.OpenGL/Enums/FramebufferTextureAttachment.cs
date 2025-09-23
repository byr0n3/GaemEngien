namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Represents the type of texture attachment that can be bound to a framebuffer when using <see cref="Framebuffer.Texture2D"/>.
	/// </summary>
	public enum FramebufferTextureAttachment
	{
		/// <summary>
		/// Represents the absence of a specific texture attachment.
		/// </summary>
		None = 0,

		/// <summary>
		/// Represents a color texture attachment.
		/// </summary>
		Color = 0x8CE0,

		/// <summary>
		/// Represents a depth texture attachment.
		/// </summary>
		Depth = 0x8D00,

		/// <summary>
		/// Represents a stencil texture attachment.
		/// </summary>
		Stencil = 0x8D20,
	}
}
