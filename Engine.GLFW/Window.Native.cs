using System.Runtime.InteropServices;
using Engine.Shared;
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

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetWindowUserPointer")]
		public static extern nint SetWindowUserPointer(Window window, nint pointer);

		[DllImport(libglfw3.Library, EntryPoint = "glfwGetWindowUserPointer")]
		public static extern nint GetWindowUserPointer(Window window);

		[DllImport(libglfw3.Library, EntryPoint = "glfwMakeContextCurrent")]
		public static extern void MakeContextCurrent(Window window);

		[DllImport(libglfw3.Library, EntryPoint = "glfwGetFramebufferSize")]
		public static extern void GetFramebufferSize(Window window, Pointer<int> width, Pointer<int> height);

		[DllImport(libglfw3.Library, EntryPoint = "glfwSwapBuffers")]
		public static extern void SwapBuffers(Window window);

		[DllImport(libglfw3.Library, EntryPoint = "glfwGetKey")]
		public static extern NativeBool GetKey(Window window, Key key);

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetInputMode")]
		public static extern void SetInputMode(Window window, int mode, int value);

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetFramebufferSizeCallback")]
		public static extern unsafe void SetFramebufferSizeCallback(Window window, delegate*unmanaged<Window, int, int, void> callback);

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetCursorPosCallback")]
		public static extern unsafe void SetCursorPosCallback(Window window, delegate*unmanaged<Window, double, double, void> callback);

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetScrollCallback")]
		public static extern unsafe void SetScrollCallback(Window window, delegate*unmanaged<Window, double, double, void> callback);
	}
}
