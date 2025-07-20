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
	}
}
