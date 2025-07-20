using System.Runtime.InteropServices;
using Engine.Native;
using wgpu.Enums;
using wgpu.Internal;
using wgpu.Internal.Structs;
using wgpu.Structs;

namespace wgpu
{
	internal static class AdapterNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuAdapterRelease")]
		public static extern void Release(Adapter adapter);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuAdapterRequestDevice")]
		public static extern Future RequestDevice(Adapter adapter,
												  Pointer<DeviceDescriptor> descriptor,
												  RequestCallbackInfo<Device> callbackInfo);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuAdapterGetLimits")]
		public static extern Status GetLimits(Adapter adapter, Pointer<Limits> limits);
	}
}
