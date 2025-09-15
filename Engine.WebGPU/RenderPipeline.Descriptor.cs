using System.Runtime.InteropServices;
using Engine.Shared;
using JetBrains.Annotations;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Describes the configuration of a render pipeline.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct RenderPipelineDescriptor
	{
		/// <summary>
		/// Gets or sets the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or sets the label for this pipeline descriptor.
		/// </summary>
		public StringView Label { get; init; }

		/// <summary>
		/// Gets or sets the pipeline layout used by this render pipeline.
		/// </summary>
		public PipelineLayout Layout { get; init; }

		/// <summary>
		/// Represents the state of vertex data used in a render pipeline.
		/// </summary>
		public VertexState Vertex { get; init; }

		/// <summary>
		/// Defines the state of a primitive, including its topology and strip index format.
		/// </summary>
		public PrimitiveState Primitive { get; init; }

		/// <summary>
		/// Gets or sets a pointer to the depth-stencil state used in rendering pipelines.
		/// </summary>
		public Pointer<DepthStencilState> DepthStencil { get; init; }

		/// <summary>
		/// Gets or sets the multisampling state for the render pipeline.
		/// </summary>
		public MultisampleState Multisample { get; init; }

		/// <summary>
		/// Gets or sets the fragment state configuration for the render pipeline.
		/// </summary>
		public Pointer<FragmentState> Fragment { get; init; }
	}

	/// <summary>
	/// Represents a single entry in the constants array for shader stages.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct ConstantEntry
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the key representing a single entry in the constants array for shader stages.
		/// </summary>
		public StringView Key { get; init; }

		/// <summary>
		/// Gets or initializes the value associated with this constant entry.
		/// </summary>
		public double Value { get; init; }
	}
}
