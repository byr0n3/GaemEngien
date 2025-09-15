namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Enum used to specify which buffers are to be cleared.
	/// </summary>
	[System.Flags]
	public enum ClearBuffer
	{
		/// <summary>
		/// Represents no buffers to be cleared.
		/// </summary>
		None,

		/// <summary>
		/// Specifies that the depth buffer should be cleared.
		/// </summary>
		Depth = 0x00000100,

		/// <summary>
		/// Specifies that the stencil buffer should be cleared.
		/// </summary>
		Stencil = 0x00000400,

		/// <summary>
		/// Specifies that the color buffer should be cleared.
		/// </summary>
		Color = 0x00004000,
	}
}
