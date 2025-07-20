namespace glfw.Enums
{
	/// <summary>
	/// Specifies the client API that the window will use.
	/// </summary>
	public enum ClientApi
	{
		/// <summary>
		/// Specifies that the window should not use any client API.
		/// The application will display pixels on the window outside GLFW.
		/// </summary>
		NoApi = 0,

		/// <summary>
		/// Specifies that the window should use OpenGL as its client API.
		/// </summary>
		OpenGL = 0x00030001,

		/// <summary>
		/// Specifies that the window should use OpenGL ES as its client API.
		/// </summary>
		OpenGLES = 0x00030002,
	}
}
