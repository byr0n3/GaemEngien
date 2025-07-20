using System.Diagnostics;
using System.Drawing;
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
	public readonly struct Window : System.IDisposable
	{
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

		/// <summary>
		/// Releases all resources used by the window.
		/// </summary>
		public void Dispose()
		{
			Debug.Assert(this.IsValid);

			WindowNative.Destroy(this);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static void SetHints(WindowHints hints)
		{
			WindowNative.SetHint(WindowHint.ClientApi, Unsafe.BitCast<ClientApi, int>(hints.Api));
			WindowNative.SetHint(WindowHint.Resizable, hints.Resizable);
		}
	}
}
