using System.Runtime.InteropServices;
using glfw.Internal;

namespace glfw
{
	internal static class MonitorNative
	{
		[DllImport(libglfw3.Library, EntryPoint = "glfwGetPrimaryMonitor")]
		public static extern Monitor GetPrimaryMonitor();
	}
}
