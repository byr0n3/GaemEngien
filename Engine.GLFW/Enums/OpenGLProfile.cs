namespace glfw.Enums
{
	/// <summary>
	/// Specifies the OpenGL profile to create.
	/// </summary>
	public enum OpenGLProfile
	{
		/// <summary>
		/// Specifies no preference for the OpenGL profile.
		/// </summary>
		Any,

		/// <summary>
		/// Specifies the use of the core OpenGL profile, which excludes deprecated features.
		/// </summary>
		Core = 0x00032001,

		/// <summary>
		/// Specifies the OpenGL compatibility profile.
		/// </summary>
		Compat = 0x00032002,
	}
}
