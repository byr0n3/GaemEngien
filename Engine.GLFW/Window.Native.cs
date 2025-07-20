using System.Runtime.InteropServices;
using Engine.Native;
using glfw.Enums;
using glfw.Internal;

namespace glfw
{
	internal static class WindowNative
	{
		[DllImport(libglfw3.Library, EntryPoint = "glfwWindowHint")]
		public static extern void SetHint(WindowHint hint, int value);

		[DllImport(libglfw3.Library, EntryPoint = "glfwWindowHint")]
		public static extern void SetHint(WindowHint hint, NativeBool value);

		[DllImport(libglfw3.Library, EntryPoint = "glfwCreateWindow")]
		public static extern Window Create(int width, int height, NativeString title, Monitor monitor, Window share);

		[DllImport(libglfw3.Library, EntryPoint = "glfwDestroyWindow")]
		public static extern void Destroy(Window window);

		[DllImport(libglfw3.Library, EntryPoint = "glfwWindowShouldClose")]
		public static extern NativeBool ShouldClose(Window window);

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetWindowShouldClose")]
		public static extern void SetShouldClose(Window window, NativeBool value);

		[DllImport(libglfw3.Library, EntryPoint = "glfwGetWindowSize")]
		public static extern void GetSize(Window window, Pointer<int> width, Pointer<int> height);

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetWindowSize")]
		public static extern void SetSize(Window window, int width, int height);

		[DllImport(libglfw3.Library, EntryPoint = "glfwGetWindowTitle")]
		public static extern NativeString GetWindowTitle(Window window);

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetWindowTitle")]
		public static extern void SetWindowTitle(Window window, NativeString title);

		[DllImport(libglfw3.Library, EntryPoint = "glfwGetCocoaView")]
		public static extern nint GetCocoaView(Window window);
	}
}
