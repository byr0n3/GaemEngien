using System.Runtime.InteropServices;
using glfw.Enums;

namespace glfw
{
	/// <summary>
	/// Represents a window descriptor containing the properties required to create a new GLFW window.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct WindowDescriptor
	{
		/// <summary>
		/// Gets or sets the width of the window in screen coordinates.
		/// </summary>
		public required int Width { get; init; }

		/// <summary>
		/// Gets or sets the height of the window in screen coordinates.
		/// </summary>
		public required int Height { get; init; }

		/// <summary>
		/// Gets or sets the title of the window.
		/// </summary>
		public required NativeString Title { get; init; }

		/// <summary>
		/// Gets or sets the window hints configuration.
		/// </summary>
		public WindowHints Hints { get; init; }

		/// <summary>
		/// Gets or sets the monitor to which the window will be created.
		/// </summary>
		public Monitor Monitor { get; init; }

		/// <summary>
		/// Gets or sets the window to share resources with.
		/// </summary>
		public Window Share { get; init; }
	}

	/// <summary>
	/// Represents a structure containing window creation hints for GLFW.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct WindowHints
	{
		/// <summary>
		/// Specifies the client API that will be used for rendering.
		/// </summary>
		public ClientApi Api { get; init; }

		/// <summary>
		/// Gets or sets a value indicating whether the window is resizable.
		/// </summary>
		public bool Resizable { get; init; }

		/// <summary>
		/// Gets or sets the version of the OpenGL context to be created.
		/// </summary>
		public WindowContextVersion ContextVersion { get; init; }

		/// <summary>
		/// Specifies the OpenGL profile to be used.
		/// </summary>
		public OpenGLProfile OpenGLProfile { get; init; }

		/// <summary>
		/// Gets or sets a value indicating whether the OpenGL context should be forward-compatible.
		/// </summary>
		public bool OpenGLForwardCompat { get; init; }

		/// <summary>
		/// Represents the OpenGL version of a window context.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public readonly struct WindowContextVersion
		{
			/// <summary>
			/// Gets the major version of the OpenGL context.
			/// </summary>
			public readonly int Major;

			/// <summary>
			/// Gets the minor version of the OpenGL context.
			/// </summary>
			public readonly int Minor;

			/// <summary>
			/// Represents the OpenGL version of a window context.
			/// </summary>
			public WindowContextVersion(int major, int minor)
			{
				this.Major = major;
				this.Minor = minor;
			}
		}
	}
}
