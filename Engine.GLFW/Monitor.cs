using System.Runtime.InteropServices;
using JetBrains.Annotations;

namespace glfw
{
	/// <summary>
	/// Represents a monitor in the GLFW library.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Monitor
	{
		/// <summary>
		/// Gets the primary monitor.
		/// </summary>
		public static Monitor Primary =>
			MonitorNative.GetPrimaryMonitor();

		private readonly nint handle;

		/// <summary>
		/// Gets a value indicating whether the monitor handle is valid.
		/// </summary>
		public bool IsValid =>
			this.handle != default;
	}
}
