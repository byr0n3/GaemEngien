using System.Runtime.InteropServices;

namespace glfw.Internal
{
	// ReSharper disable once InconsistentNaming
	internal static class libobjc
	{
		[DllImport("libobjc", EntryPoint = "sel_registerName")]
		public static extern nint selRegisterName(NativeString name);

		[DllImport("libobjc", EntryPoint = "objc_getClass")]
		public static extern nint getClass(NativeString name);

		[DllImport("libobjc", EntryPoint = "objc_msgSend")]
		public static extern nint msgSend(nint id, nint sel);

		[DllImport("libobjc", EntryPoint = "objc_msgSend")]
		public static extern nint msgSend(nint id, nint sel, nint arg);

		[DllImport("libobjc", EntryPoint = "objc_msgSend")]
		public static extern void msgSendVoid(nint id, nint sel, nint arg);

		[DllImport("libobjc", EntryPoint = "objc_msgSend")]
		public static extern void msgSendVoid(nint id, nint sel);
	}
}
