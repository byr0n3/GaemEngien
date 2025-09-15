using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Internal;
using wgpu.Structs;

namespace wgpu
{
	internal static class QueueNative
	{
		[DllImport(libwgpu.Library, EntryPoint = "wgpuQueueRelease")]
		public static extern void Release(Queue queue);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuQueueSubmit")]
		public static extern void Submit(Queue queue, nint commandCount, Pointer<CommandBuffer> commands);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuQueueWriteBuffer")]
		public static extern unsafe void WriteBuffer(Queue queue, GpuBuffer buffer, ulong bufferOffset, void* data, nint size);

		[DllImport(libwgpu.Library, EntryPoint = "wgpuQueueWriteTexture")]
		public static extern unsafe void WriteTexture(Queue queue,
													  Pointer<TexelCopyTextureInfo> destination,
													  void* data,
													  nint dataSize,
													  Pointer<TexelCopyBufferLayout> dataLayout,
													  Pointer<Extent3D> writeSize);
	}
}
