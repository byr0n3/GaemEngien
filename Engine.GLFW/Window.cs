using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using glfw.Enums;
using glfw.Internal;
using JetBrains.Annotations;

namespace glfw
{
	/// <summary>
	/// Represents a window in the GLFW library.
	/// </summary>
	[PublicAPI]
	[MustDisposeResource]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Window : System.IEquatable<Window>, System.IDisposable
	{
		/// <summary>
		/// Represents the method that handles framebuffer size changed events.
		/// </summary>
		/// <param name="window">The window instance that triggered the event.</param>
		/// <param name="width">The new width of the framebuffer.</param>
		/// <param name="height">The new height of the framebuffer.</param>
		public delegate void OnFramebufferSizeChanged(Window window, int width, int height);

		public delegate void OnCursorPositionChanged(Window window, Vector2 position);

		public delegate void OnScrollChanged(Window window, Vector2 position);

		private static readonly Dictionary<Window, OnFramebufferSizeChanged> framebufferSizeChangedCallbacks = new();
		private static readonly Dictionary<Window, OnCursorPositionChanged> cursorPositionChangedCallbacks = new();
		private static readonly Dictionary<Window, OnScrollChanged> scrollChangedCallbacks = new();

		private readonly nint handle;

		/// <summary>
		/// Gets a value indicating whether this window instance is valid.
		/// </summary>
		public bool IsValid =>
			this.handle != default;

		/// <summary>
		/// Gets or sets whether the window should close.
		/// </summary>
		public bool ShouldClose
		{
			get
			{
				Debug.Assert(this.IsValid);

				return WindowNative.ShouldClose(this);
			}

			set
			{
				Debug.Assert(this.IsValid);

				WindowNative.SetShouldClose(this, value);
			}
		}

		/// <summary>
		/// Gets or sets the size of the window.
		/// </summary>
		public Size Size
		{
			get
			{
				Debug.Assert(this.IsValid);

				int width = default, height = default;

				WindowNative.GetSize(this, width, height);

				return new Size(width, height);
			}

			set
			{
				Debug.Assert(this.IsValid);

				WindowNative.SetSize(this, value.Width, value.Height);
			}
		}

		/// <summary>
		/// Gets the framebuffer size of the window.
		/// </summary>
		public Size FramebufferSize
		{
			get
			{
				Debug.Assert(this.IsValid);

				int width = default, height = default;

				WindowNative.GetFramebufferSize(this, width, height);

				return new Size(width, height);
			}
		}

		/// <summary>
		/// Gets or sets the title of the window.
		/// </summary>
		public NativeString Title
		{
			get => WindowNative.GetWindowTitle(this);
			set => WindowNative.SetWindowTitle(this, value);
		}

		/// <summary>
		/// Gets the Metal Layer associated with this window.
		/// </summary>
		public nint MetalLayer
		{
			get
			{
				var layer = libobjc.msgSend(libobjc.getClass("CAMetalLayer"u8), libobjc.selRegisterName("layer"u8));
				var view = WindowNative.GetCocoaView(this);

				libobjc.msgSendVoid(view, libobjc.selRegisterName("setLayer:"u8), layer);

				return layer;
			}
		}

		/// <summary>
		/// Gets or sets a pointer to user-specified data associated with the window.
		/// </summary>
		public nint UserPointer
		{
			get => WindowNative.GetWindowUserPointer(this);
			set => WindowNative.SetWindowUserPointer(this, value);
		}

		/// <summary>
		/// Represents a window in the GLFW library.
		/// </summary>
		[MustDisposeResource]
		public Window(WindowDescriptor descriptor)
		{
			Window.SetHints(descriptor.Hints);

			this = WindowNative.Create(descriptor.Width, descriptor.Height, descriptor.Title, descriptor.Monitor, descriptor.Share);
		}

		/// <summary>
		/// Represents a window in the GLFW library.
		/// </summary>
		/// <param name="width">The width of the window.</param>
		/// <param name="height">The height of the window.</param>
		/// <param name="title">The title of the window.</param>
		/// <param name="monitor">The monitor the window should be displayed on.</param>
		/// <param name="share">Window instance to share properties with.</param>
		[MustDisposeResource]
		public Window(int width, int height, NativeString title, Monitor monitor = default, Window share = default)
		{
			this = WindowNative.Create(width, height, title, monitor, share);
		}

		// @todo Support multiple callbacks.
		/// <summary>
		/// Sets the callback to be called when the framebuffer size of the window changes.
		/// </summary>
		/// <param name="callback">The delegate that handles the framebuffer size changed event.</param>
		public unsafe void AddFramebufferSizeChanged(OnFramebufferSizeChanged callback)
		{
			Window.framebufferSizeChangedCallbacks[this] = callback;

			WindowNative.SetFramebufferSizeCallback(this, &Callback);

			[UnmanagedCallersOnly]
			static void Callback(Window window, int width, int height)
			{
				var callback = Window.framebufferSizeChangedCallbacks.GetValueOrDefault(window);

				callback?.Invoke(window, width, height);
			}
		}

		public unsafe void AddCursorPositionChanged(OnCursorPositionChanged callback)
		{
			Window.cursorPositionChangedCallbacks[this] = callback;

			WindowNative.SetCursorPosCallback(this, &Callback);

			[UnmanagedCallersOnly]
			static void Callback(Window window, double xPosition, double yPosition)
			{
				var callback = Window.cursorPositionChangedCallbacks.GetValueOrDefault(window);

				callback?.Invoke(window, new Vector2((float)xPosition, (float)yPosition));
			}
		}

		public unsafe void AddScrollChanged(OnScrollChanged callback)
		{
			Window.scrollChangedCallbacks[this] = callback;

			WindowNative.SetScrollCallback(this, &Callback);

			[UnmanagedCallersOnly]
			static void Callback(Window window, double xPosition, double yPosition)
			{
				var callback = Window.scrollChangedCallbacks.GetValueOrDefault(window);

				callback?.Invoke(window, new Vector2((float)xPosition, (float)yPosition));
			}
		}

		/// <summary>
		/// Makes the window's context current.
		/// </summary>
		public void MakeContextCurrent() =>
			WindowNative.MakeContextCurrent(this);

		/// <summary>
		/// Swaps the front and back buffers of the window.
		/// This function is used to present rendered content on the screen.
		/// </summary>
		public void SwapBuffers() =>
			WindowNative.SwapBuffers(this);

		public bool GetKey(Key key) =>
			WindowNative.GetKey(this, key);

		public void SetCursorMode(CursorMode mode) =>
			WindowNative.SetInputMode(this, Unsafe.BitCast<InputMode, int>(InputMode.Cursor), Unsafe.BitCast<CursorMode, int>(mode));

		/// <summary>
		/// Releases all resources used by the window.
		/// </summary>
		public void Dispose()
		{
			Debug.Assert(this.IsValid);

			WindowNative.Destroy(this);
		}

		/// <summary>
		/// Determines whether the specified window is equal to the current window.
		/// </summary>
		/// <param name="other">The window to compare with the current window.</param>
		/// <returns>
		/// <see langword="true"/> if the specified window is equal to the current window; otherwise, <see langword="false"/>.
		/// </returns>
		public bool Equals(Window other) =>
			this.handle == other.handle;

		/// <summary>
		/// Determines whether the specified window is equal to the current window.
		/// </summary>
		/// <param name="object">The window to compare with the current window.</param>
		/// <returns>
		/// <see langword="true"/> if the specified window is equal to the current window; otherwise, <see langword="false"/>.
		/// </returns>
		public override bool Equals(object? @object) =>
			(@object is Window other) && this.Equals(other);

		/// <summary>
		/// Serves as a hash function for the <see cref="Window"/> struct.
		/// </summary>
		/// <returns>
		/// A hash code for the current <see cref="Window"/> instance.
		/// </returns>
		public override int GetHashCode() =>
			this.handle.GetHashCode();

		/// <summary>
		/// Compares two windows for equality.
		/// </summary>
		/// <param name="left">The first window to compare.</param>
		/// <param name="right">The second window to compare.</param>
		/// <returns><see langword="true"/> if the windows are equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator ==(Window left, Window right) =>
			left.Equals(right);

		/// <summary>
		/// Determines whether the specified window is not equal to the current window.
		/// </summary>
		/// <param name="left">The first window to compare.</param>
		/// <param name="right">The second window to compare.</param>
		/// <returns><see langword="true"/> if the specified windows are not equal; otherwise, <see langword="false"/>.</returns>
		public static bool operator !=(Window left, Window right) =>
			!left.Equals(right);

		private static void SetHints(WindowHints hints)
		{
			WindowNative.SetHint(WindowHint.ClientApi, Unsafe.BitCast<ClientApi, int>(hints.Api));
			WindowNative.SetHint(WindowHint.Resizable, hints.Resizable);
			WindowNative.SetHint(WindowHint.ContextVersionMajor, hints.ContextVersion.Major);
			WindowNative.SetHint(WindowHint.ContextVersionMinor, hints.ContextVersion.Minor);
			WindowNative.SetHint(WindowHint.OpenGLProfile, Unsafe.BitCast<OpenGLProfile, int>(hints.OpenGLProfile));
			if (hints.OpenGLForwardCompat)
			{
				WindowNative.SetHint(WindowHint.OpenGLForwardCompat, hints.OpenGLForwardCompat);
			}
		}
	}
}
