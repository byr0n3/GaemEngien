namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Represents the set of buffers that can be transferred in a framebuffer blit operation.
	/// </summary>
	[System.Flags]
	public enum BlitMask
	{
		/// <summary>
		/// Indicates that no buffers are selected for the blit operation.
		/// </summary>
		None = 0,

		/// <summary>
		/// Includes the depth component of the framebuffer in the blit operation.
		/// </summary>
		Depth = 0x00000100,

		/// <summary>
		/// Includes the stencil component of the framebuffer in the blit operation.
		/// </summary>
		Stencil = 0x00000400,

		/// <summary>
		/// Includes the color component of the framebuffer in the blit operation.
		/// </summary>
		Color = 0x00004000,
	}
}
