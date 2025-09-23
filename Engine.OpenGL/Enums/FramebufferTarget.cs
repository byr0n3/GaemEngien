namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Specifies the binding target for framebuffer operations.
	/// </summary>
	public enum FramebufferTarget
	{
		/// <summary>
		/// None.
		/// </summary>
		None = 0,

		/// <summary>
		/// Specifies the binding target for framebuffer read operations.
		/// </summary>
		Read = 0x8CA8,

		/// <summary>
		/// Specifies the binding target for framebuffer draw operations.
		/// </summary>
		Draw = 0x8CA9,

		/// <summary>
		/// Specifies the binding target for framebuffer read- and write operations.
		/// </summary>
		ReadAndWrite = 0x8D40,
	}
}
