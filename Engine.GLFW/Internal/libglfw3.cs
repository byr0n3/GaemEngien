using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Engine.Native;
using glfw.Enums;

[assembly: DisableRuntimeMarshalling]

namespace glfw.Internal
{
	// ReSharper disable once InconsistentNaming
	internal static class libglfw3
	{
		public const string Library = nameof(libglfw3);

		[DllImport(libglfw3.Library, EntryPoint = "glfwInit")]
		public static extern NativeBool Init();

		[DllImport(libglfw3.Library, EntryPoint = "glfwTerminate")]
		public static extern void Terminate();

		[DllImport(libglfw3.Library, EntryPoint = "glfwGetTime")]
		public static extern double GetTime();

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetTime")]
		public static extern void SetTime(double time);

		[DllImport(libglfw3.Library, EntryPoint = "glfwSetErrorCallback")]
		public static extern unsafe void SetErrorCallback(delegate* unmanaged<ErrorCode, NativeString, void> callback);

		[DllImport(libglfw3.Library, EntryPoint = "glfwPollEvents")]
		public static extern void PollEvents();
	}
}
