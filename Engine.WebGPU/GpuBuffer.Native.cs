using System.Runtime.InteropServices;
using wgpu.Flags;
using wgpu.Internal;
using wgpu.Internal.Structs;

namespace wgpu
{
	internal static class BufferNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuBufferDestroy")]
		public static extern void Destroy(GpuBuffer buffer);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuBufferRelease")]
		public static extern void Release(GpuBuffer buffer);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuBufferGetSize")]
		public static extern ulong GetSize(GpuBuffer buffer);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuBufferMapAsync")]
		public static extern Future MapAsync(GpuBuffer buffer, MapMode mode, nint offset, nint size, BufferMapCallbackInfo callbackInfo);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuBufferGetConstMappedRange")]
		public static extern unsafe void* GetConstMappedRange(GpuBuffer buffer, nint offset, nint size);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuBufferUnmap")]
		public static extern void Unmap(GpuBuffer buffer);
	}
}
