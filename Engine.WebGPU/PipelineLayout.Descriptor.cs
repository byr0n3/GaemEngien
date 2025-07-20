using System.Runtime.InteropServices;
using Engine.Native;
using JetBrains.Annotations;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Describes the properties of a pipeline layout.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct PipelineLayoutDescriptor
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of descriptor structures.
		/// </summary>
		/// <remarks>
		/// This property is used to link multiple descriptor structures together,
		/// forming a linked list of descriptors for further processing.
		/// The <see cref="Pointer{ChainedStruct}"/> type represents an unmanaged pointer
		/// to another instance of <see cref="ChainedStruct"/>, allowing for chaining.
		/// </remarks>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes a human-readable label for the pipeline layout descriptor.
		/// </summary>
		/// <remarks>
		/// This property is used to assign a descriptive name to the pipeline layout,
		/// which can be helpful for debugging and logging purposes. The label is represented
		/// as an instance of <see cref="StringView"/>, which provides a safe, read-only view
		/// into a string. This allows for efficient handling of strings in scenarios where mutability
		/// or allocation on the heap should be minimized.
		/// </remarks>
		public StringView Label { get; init; }

		private readonly nint bindGroupLayoutCount;

		private readonly Pointer<BindGroupLayout> bindGroupLayouts;

		/// <summary>
		/// Gets or initializes the collection of bind group layouts.
		/// </summary>
		/// <remarks>
		/// This property represents a span of <see cref="BindGroupLayout"/> instances,
		/// defining the layout for each bind group used in the pipeline. The length
		/// of this span determines the number of bind groups associated with the layout.
		/// When initializing, the collection is set along with its count, ensuring
		/// proper configuration of the pipeline's bind groups.
		/// </remarks>
		public unsafe System.ReadOnlySpan<BindGroupLayout> BindGroupLayouts
		{
			get => new(this.bindGroupLayouts, (int)this.bindGroupLayoutCount);
			init
			{
				this.bindGroupLayoutCount = value.Length;
				this.bindGroupLayouts = value;
			}
		}
	}
}
