using System.Runtime.InteropServices;
using Engine.Native;
using JetBrains.Annotations;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents the description of a bind group used in WebGPU.
	/// A bind group describes a set of resources and their bindings to be used together for rendering or compute operations.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BindGroupDescriptor
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of structures.
		/// This property is used to link multiple descriptor or state structures together in the wgpu library, forming a linked list.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the label for this bind group descriptor.
		/// The label is a string view that can be used to identify and debug the descriptor.
		/// </summary>
		public StringView Label { get; init; }

		/// <summary>
		/// Gets or initializes the layout for this bind group descriptor.
		/// This property specifies which bind group layout is used to create the bind group,
		/// defining how resources are bound and accessed during rendering.
		/// </summary>
		public BindGroupLayout Layout { get; init; }

		private readonly nint entryCount;

		private readonly Pointer<BindGroupEntry> entries;

		/// <summary>
		/// Gets or initializes a read-only span of entries that describe the resources to be bound in a bind group.
		/// This property represents an array of <see cref="BindGroupEntry"/> structures, each defining a specific resource binding within the bind group.
		/// </summary>
		public unsafe System.ReadOnlySpan<BindGroupEntry> Entries
		{
			get => new(this.entries, (int)this.entryCount);
			init
			{
				this.entryCount = value.Length;
				this.entries = value;
			}
		}
	}

	/// <summary>
	/// Represents an entry in a bind group, specifying the resource and its binding location.
	/// A bind group entry defines how to bind resources such as buffers, samplers, or texture views into a bind group for use in rendering or compute operations.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct BindGroupEntry
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of structures using a pointer to an unmanaged type.
		/// This property is used to link multiple descriptor or state structures together, forming a linked list within the wgpu library.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Represents a binding index within a bind group.
		/// </summary>
		public uint Binding { get; init; }

		/// <summary>
		/// Represents a GPU buffer object.
		/// </summary>
		public GpuBuffer Buffer { get; init; }

		/// <summary>
		/// Gets or initializes the byte offset within the buffer that the resource data starts at.
		/// This property is used to specify where the data for a bind group entry begins in the buffer, allowing for precise control over resource binding in the wgpu library.
		/// </summary>
		public ulong Offset { get; init; }

		/// <summary>
		/// Gets or initializes the size of the bind group entry in bytes.
		/// This property represents the total size required for the data associated with this bind group entry.
		/// </summary>
		public ulong Size { get; init; }

		/// <summary>
		/// Represents a sampler object used in graphics processing.
		/// </summary>
		public Sampler Sampler { get; init; }

		/// <summary>
		/// Represents a view of a texture resource in the WebGPU API.
		/// This structure allows accessing and manipulating specific portions or aspects of a texture.
		/// </summary>
		public TextureView TextureView { get; init; }
	}
}
