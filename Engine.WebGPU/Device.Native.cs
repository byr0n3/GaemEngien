using System.Runtime.InteropServices;
using Engine.Native;
using wgpu.Internal;
using wgpu.Structs;

namespace wgpu
{
	internal static class DeviceNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceRelease")]
		public static extern void Release(Device device);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceGetQueue")]
		public static extern Queue GetQueue(Device device);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceCreateCommandEncoder")]
		public static extern CommandEncoder CreateCommandEncoder(Device device, Pointer<BasicDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceCreateRenderPipeline")]
		public static extern RenderPipeline CreateRenderPipeline(Device device, Pointer<RenderPipelineDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceCreateShaderModule")]
		public static extern ShaderModule CreateShaderModule(Device device, Pointer<BasicDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceCreateBuffer")]
		public static extern GpuBuffer CreateBuffer(Device device, Pointer<BufferDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceCreateBindGroupLayout")]
		public static extern BindGroupLayout CreateBindGroupLayout(Device device, Pointer<BindGroupLayoutDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceCreatePipelineLayout")]
		public static extern PipelineLayout CreatePipelineLayout(Device device, Pointer<PipelineLayoutDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceCreateBindGroup")]
		public static extern BindGroup CreateBindGroup(Device device, Pointer<BindGroupDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDeviceCreateTexture")]
		public static extern Texture CreateTexture(Device device, Pointer<TextureDescriptor> descriptor);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuDevicePoll")]
		public static extern NativeBool Poll(Device device, NativeBool wait, Pointer<ulong> submissionIndex);
	}
}
