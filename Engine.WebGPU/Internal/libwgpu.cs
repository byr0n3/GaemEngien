using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

[assembly: DisableRuntimeMarshalling]

namespace wgpu.Internal
{
	// ReSharper disable once InconsistentNaming
	internal static class libwgpu
	{
		public const string Library = $"{nameof(libwgpu)}_native";

		[DllImport(libwgpu.Library, EntryPoint = "wgpuGetVersion")]
		public static extern uint GetVersion();
	}
}
