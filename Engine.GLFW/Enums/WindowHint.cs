namespace glfw.Enums
{
	/// <summary>
	/// Specifies window creation hints.
	/// </summary>
	public enum WindowHint
	{
		/// <summary>
		/// Specifies no window creation hint.
		/// </summary>
		None = 0,

		/// <summary>
		/// Specifies whether the windowed mode window is resizable.
		/// </summary>
		Resizable = 0x00020003,

		/// <summary>
		/// Specifies the client API to be used by the created window.
		/// </summary>
		ClientApi = 0x00022001,

		/// <summary>
		/// Specifies the major version of the context to be created.
		/// </summary>
		ContextVersionMajor = 0x00022002,

		/// <summary>
		/// Specifies the minor version of the context to be created.
		/// </summary>
		ContextVersionMinor = 0x00022003,

		/// <summary>
		/// Specifies the OpenGL profile to be used.
		/// </summary>
		OpenGLProfile = 0x00022008,

		/// <summary>
		/// Specifies whether to create an OpenGL context that is forward-compatible.
		/// </summary>
		OpenGLForwardCompat = 0x00022006,

		/// <summary>
		/// Specifies the number of samples to be used for multisampling.
		/// A value of 0 disables multisampling, while a higher value enables
		/// anti‑aliasing by rendering with the specified number of samples per pixel.
		/// </summary>
		Samples = 0x0002100D,
	}
}
