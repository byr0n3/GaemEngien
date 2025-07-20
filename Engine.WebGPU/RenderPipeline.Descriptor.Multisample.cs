using System.Runtime.InteropServices;
using Engine.Native;
using JetBrains.Annotations;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents the multisample state used in rendering.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct MultisampleState
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the number of samples per pixel used for multisampling.
		/// </summary>
		public uint Count { get; init; }

		/// <summary>
		/// Gets or initializes the mask used for multisampling.
		/// </summary>
		public uint Mask { get; init; }

		/// <summary>
		/// Gets or initializes a value indicating whether alpha-to-coverage is enabled.
		/// </summary>
		public NativeBool AlphaToCoverageEnabled { get; init; }
	}
}
