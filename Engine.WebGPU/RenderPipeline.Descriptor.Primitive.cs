using System.Runtime.InteropServices;
using Engine.Native;
using JetBrains.Annotations;
using wgpu.Enums;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents the state of a primitive in the render pipeline.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PrimitiveState
	{
		/// <summary>
		/// Gets or initializes the next structure in the chain.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the type of primitive to render, specifying how vertices are interpreted.
		/// </summary>
		public PrimitiveTopology Topology { get; init; }

		/// <summary>
		/// Gets or initializes the index format for strip primitives.
		/// </summary>
		public IndexFormat StripIndexFormat { get; init; }

		/// <summary>
		/// Gets or initializes the orientation of the front face for primitive rendering.
		/// </summary>
		public FrontFace FrontFace { get; init; }

		/// <summary>
		/// Specifies the culling mode for primitive rendering.
		/// </summary>
		public CullMode CullMode { get; init; }

		/// <summary>
		/// Gets or initializes a value indicating whether the depth values are unclipped.
		/// </summary>
		public NativeBool UnclippedDepth { get; init; }
	}
}
