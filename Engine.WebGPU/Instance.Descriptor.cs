using System.Runtime.InteropServices;
using Engine.Native;
using JetBrains.Annotations;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Describes the parameters for creating a new WebGPU instance.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct InstanceDescriptor
	{
		/// <summary>
		/// Gets or initializes the pointer to the next structure in a chain.
		/// This property is used for chaining multiple descriptor structures together,
		/// where each structure can point to another using this property.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the capabilities of the WebGPU instance.
		/// This property specifies various features that are supported by the GPU instance,
		/// such as timed wait operations and their maximum count.
		/// </summary>
		public InstanceCapabilities Features { get; init; }
	}

	/// <summary>
	/// Represents the capabilities of a WebGPU instance.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct InstanceCapabilities
	{
		/// <summary>
		/// Gets or initializes the pointer to the next structure in a chain.
		/// This property is used for chaining multiple descriptor structures together,
		/// where each structure can point to another using this property.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes a value indicating whether timed wait any operation is enabled.
		/// This property represents the capability of a WebGPU instance to support timed wait any operations,
		/// allowing multiple wait conditions to be checked simultaneously within a specified time frame.
		/// </summary>
		public NativeBool TimedWaitAnyEnable { get; init; }

		/// <summary>
		/// Gets or initializes the maximum number of timers that can be waited on simultaneously using the TimedWaitAny operation.
		/// This property specifies the upper limit for the number of timer handles that can be passed to the TimedWaitAny function in a single call.
		/// </summary>
		public nuint TimedWaitAnyMaxCount { get; init; }
	}
}
