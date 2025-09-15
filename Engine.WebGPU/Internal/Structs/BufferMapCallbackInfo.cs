using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Internal.Enums;
using wgpu.Structs;

namespace wgpu.Internal.Structs
{
	/// <summary>
	/// Represents callback information used for asynchronous buffer mapping operations.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
    internal readonly struct BufferMapCallbackInfo
	{
		public Pointer<ChainedStruct> NextInChain { get; init; }

		public CallbackMode Mode { get; init; }

		public unsafe delegate*unmanaged<MapAsyncStatus, StringView, void*, void*, void> Callback { get; init; }

		public unsafe void* UserData1 { get; init; }

		public unsafe void* UserData2 { get; init; }
	}
}
