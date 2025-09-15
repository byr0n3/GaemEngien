using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Internal.Enums;
using wgpu.Structs;

namespace wgpu.Internal.Structs
{
	/// <summary>
	/// Represents a structure used to pass callback information for asynchronous operations.
	/// </summary>
	/// <typeparam name="TObject">The type of object that the callback will handle.</typeparam>
	[StructLayout(LayoutKind.Sequential)]
	internal readonly unsafe struct RequestCallbackInfo<TObject>
		where TObject : struct
	{
		public Pointer<ChainedStruct> NextInChain { get; init; }

		public CallbackMode Mode { get; init; }

		public required delegate*unmanaged<RequestStatus, TObject, StringView, void*, void*, void> Callback { get; init; }

		public void* UserData1 { get; init; }

		public void* UserData2 { get; init; }
	}
}
