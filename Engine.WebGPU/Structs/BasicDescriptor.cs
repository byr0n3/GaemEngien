using System.Runtime.InteropServices;
using Engine.Shared;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents a basic descriptor structure used for various operations in the wgpu library.
	/// This struct is typically used as an input parameter to create or configure resources such as command encoders, shader modules, and surfaces.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BasicDescriptor
	{
		/// <summary>
		/// Gets or initializes the next structure in a linked chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the label for the to-be-created object.
		/// </summary>
		public StringView Label { get; init; }
	}
}
