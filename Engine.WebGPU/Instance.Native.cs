using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Internal;
using wgpu.Internal.Structs;
using wgpu.Structs;

namespace wgpu
{
	internal static class InstanceNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuCreateInstance")]
		public static extern Instance Create(Pointer<InstanceDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuInstanceRelease")]
		public static extern void Release(Instance instance);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuInstanceCreateSurface")]
		public static extern Surface CreateSurface(Instance instance, Pointer<BasicDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuInstanceRequestAdapter")]
		public static extern Future RequestAdapter(Instance instance,
												   Pointer<RequestAdapterOptions> options,
												   RequestCallbackInfo<Adapter> callbackInfo);
	}
}
