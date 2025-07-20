namespace glfw.Enums
{
	/// <summary>
	/// Represents error codes used by GLFW to indicate the type of error that has occurred.
	/// </summary>
	public enum ErrorCode
	{
		/// <summary>
		/// Represents the absence of an error.
		/// </summary>
		None = 0,

		/// <summary>
		/// Indicates that the GLFW library has not been initialized.
		/// </summary>
		NotInitialized = 0x00010000 | 1,

		/// <summary>
		/// Indicates that there is no current OpenGL or OpenGL ES context.
		/// </summary>
		NoCurrentContext = 0x00010000 | 2,

		/// <summary>
		/// Represents an invalid enum value error.
		/// </summary>
		InvalidEnum = 0x00010000 | 3,

		/// <summary>
		/// Represents an error code indicating that an invalid value has been passed to a GLFW function.
		/// </summary>
		InvalidValue = 0x00010000 | 4,

		/// <summary>
		/// Indicates that GLFW has run out of memory and cannot continue.
		/// </summary>
		OutOfMemory = 0x00010000 | 5,

		/// <summary>
		/// Indicates that the requested API is not available.
		/// </summary>
		ApiUnavailable = 0x00010000 | 6,

		/// <summary>
		/// Indicates that the requested version of GLFW is not available.
		/// </summary>
		VersionUnavailable = 0x00010000 | 7,

		/// <summary>
		/// Represents a platform-specific error.
		/// </summary>
		PlatformError = 0x00010000 | 8,

		/// <summary>
		/// Indicates that the requested format is not available.
		/// </summary>
		FormatUnavailable = 0x00010000 | 9,

		/// <summary>
		/// Indicates that a GLFW operation was attempted without a window context.
		/// </summary>
		NoWindowContext = 0x00010000 | 10,
	}
}
