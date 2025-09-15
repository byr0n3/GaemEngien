using System.Runtime.InteropServices;
using Engine.Shared;
using JetBrains.Annotations;
using wgpu.Flags;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents a buffer descriptor used to create a GPU buffer.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BufferDescriptor
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of descriptors.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the label for this buffer descriptor.
		/// </summary>
		public StringView Label { get; init; }

		/// <summary>
		/// Gets or initializes the usage of the buffer, which specifies how the buffer can be used.
		/// </summary>
		public BufferUsage Usage { get; init; }

		/// <summary>
		/// Gets or initializes the size of the buffer in bytes.
		/// </summary>
		public ulong Size { get; init; }

		/// <summary>
		/// Specifies whether the buffer should be mapped at creation.
		/// </summary>
		public NativeBool MappedAtCreation { get; init; }
	}
}
