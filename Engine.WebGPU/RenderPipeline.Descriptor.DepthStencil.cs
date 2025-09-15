using System.Runtime.InteropServices;
using Engine.Shared;
using JetBrains.Annotations;
using wgpu.Enums;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents a depth-stencil state used in rendering pipelines.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct DepthStencilState
	{
		/// <summary>
		/// Gets or initializes the pointer to the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Specifies the format of the depth-stencil texture.
		/// </summary>
		public TextureFormat Format { get; init; }

		/// <summary>
		/// Gets or initializes a value indicating whether depth writes are enabled.
		/// </summary>
		public OptionalBool DepthWriteEnabled { get; init; }

		/// <summary>
		/// Specifies the comparison function used for depth testing in the depth-stencil state.
		/// </summary>
		public CompareFunction DepthCompare { get; init; }

		/// <summary>
		/// Gets or initializes the stencil state for the front-facing pixels.
		/// </summary>
		public StencilFaceState StencilFront { get; init; }

		/// <summary>
		/// Defines the stencil operations and comparison for the back-facing polygons.
		/// </summary>
		public StencilFaceState StencilBack { get; init; }

		/// <summary>
		/// Gets or initializes the stencil read mask value.
		/// </summary>
		public uint StencilReadMask { get; init; }

		/// <summary>
		/// Gets or initializes the mask used to specify which bits of the stencil data can be written to.
		/// </summary>
		public uint StencilWriteMask { get; init; }

		/// <summary>
		/// Gets or sets the depth bias value used for depth testing in the rendering pipeline.
		/// </summary>
		public int DepthBias { get; init; }

		/// <summary>
		/// Gets or initializes the slope scale factor for depth bias.
		/// </summary>
		public float DepthBiasSlopeScale { get; init; }

		/// <summary>
		/// Gets or initializes the maximum depth bias value that can be applied when performing a depth test.
		/// </summary>
		public float DepthBiasClamp { get; init; }
	}

	/// <summary>
	/// Represents the stencil face state used for configuring the behavior of stencil tests.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct StencilFaceState
	{
		/// <summary>
		/// Specifies the comparison function used for stencil tests.
		/// </summary>
		public CompareFunction Compare { get; init; }

		/// <summary>
		/// Specifies the stencil operation to perform when a stencil test fails.
		/// </summary>
		public StencilOperation FailOperation { get; init; }

		/// <summary>
		/// Gets or initializes the stencil operation to perform when a depth test fails, but the stencil test passes.
		/// </summary>
		public StencilOperation DepthFailOperation { get; init; }

		/// <summary>
		/// Specifies the stencil operation to perform when both depth and stencil tests pass.
		/// </summary>
		public StencilOperation PassOperation { get; init; }
	}
}
