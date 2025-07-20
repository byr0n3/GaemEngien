using System.Runtime.InteropServices;
using wgpu.Internal;

namespace wgpu
{
	internal static class QuerySetNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuQuerySetRelease")]
		public static extern void Release(QuerySet querySet);
	}
}
