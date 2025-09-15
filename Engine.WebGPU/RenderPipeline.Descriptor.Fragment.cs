using System.Runtime.InteropServices;
using Engine.Shared;
using JetBrains.Annotations;
using wgpu.Enums;
using wgpu.Flags;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents the state of a fragment shader stage in a render pipeline.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct FragmentState
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the shader module used for fragment processing.
		/// </summary>
		public ShaderModule Module { get; init; }

		/// <summary>
		/// Gets or sets the entry point for the fragment shader.
		/// </summary>
		public StringView EntryPoint { get; init; }

		private readonly nint constantCount;

		private readonly Pointer<ConstantEntry> constants;

		private readonly nint targetCount;

		private readonly Pointer<ColorTargetState> targets;

		/// <summary>
		/// Gets or initializes the span of vertex constants.
		/// </summary>
		public unsafe System.ReadOnlySpan<ConstantEntry> Constants
		{
			get => new(this.constants, (int)this.constantCount);
			init
			{
				this.constantCount = value.Length;
				this.constants = value;
			}
		}

		/// <summary>
		/// Gets or initializes the span of color target states used in the fragment state.
		/// </summary>
		public unsafe System.ReadOnlySpan<ColorTargetState> Targets
		{
			get => new(this.targets, (int)this.targetCount);
			init
			{
				this.targetCount = value.Length;
				this.targets = value;
			}
		}
	}

	/// <summary>
	/// Represents the state of a color target in a fragment shader stage within a render pipeline.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct ColorTargetState
	{
		/// <summary>
		/// Gets or sets the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the texture format for the color target.
		/// </summary>
		public TextureFormat Format { get; init; }

		/// <summary>
		/// Gets or initializes the blend state pointer for color target blending operations.
		/// </summary>
		public Pointer<BlendState> Blend { get; init; }

		/// <summary>
		/// Gets or initializes the color write mask for this target state.
		/// </summary>
		public ColorWriteMask WriteMask { get; init; }
	}

	/// <summary>
	/// Represents the blend state for a render pipeline, defining how source and destination colors are blended.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BlendState
	{
		/// <summary>
		/// Gets or initializes the color component in a blend state.
		/// </summary>
		public Component Color { get; init; }

		/// <summary>
		/// Represents the alpha component of a blend state.
		/// </summary>
		public Component Alpha { get; init; }

		/// <summary>
		/// Represents a component of blend state in a render pipeline, used for blending operations.
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public readonly struct Component
		{
			/// <summary>
			/// Specifies the blend operation to be performed when blending source and destination colors.
			/// </summary>
			public BlendOperation Operation { get; init; }

			/// <summary>
			/// Gets or initializes the source blending factor.
			/// </summary>
			public BlendFactor SrcFactor { get; init; }

			/// <summary>
			/// Gets or initializes the destination blend factor.
			/// </summary>
			public BlendFactor DstFactor { get; init; }
		}
	}
}
