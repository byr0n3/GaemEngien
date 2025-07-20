using System.Runtime.InteropServices;
using Engine.Native;
using JetBrains.Annotations;
using wgpu.Enums;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents a descriptor for configuring the render pass that will be encoded.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct RenderPassEncoderDescriptor
	{
		/// <summary>
		/// Gets or initializes the next structure in a linked list of chained structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the label for the render pass encoder descriptor.
		/// </summary>
		public StringView Label { get; init; }

		private readonly nint colorAttachmentCount;

		private readonly Pointer<RenderPassColorAttachment> colorAttachments;

		/// <summary>
		/// Gets or initializes a pointer to the depth-stencil attachment for the render pass.
		/// </summary>
		public Pointer<RenderPassDepthStencilAttachment> DepthStencilAttachment { get; init; }

		/// <summary>
		/// Gets or initializes the set of occlusion queries to be used in the render pass.
		/// </summary>
		public QuerySet OcclusionQuerySet { get; init; }

		/// <summary>
		/// Gets or initializes the timestamp writes to be performed within a render pass.
		/// </summary>
		public Pointer<RenderPassTimestampWrites> TimestampWrites { get; init; }

		/// <summary>
		/// Gets or initializes the span of color attachments for this render pass descriptor.
		/// </summary>
		public unsafe System.ReadOnlySpan<RenderPassColorAttachment> ColorAttachments
		{
			get => new(this.colorAttachments, (int)this.colorAttachmentCount);
			init
			{
				this.colorAttachmentCount = value.Length;
				this.colorAttachments = value;
			}
		}
	}

	/// <summary>
	/// Represents a color attachment for a render pass.
	/// </summary>
	[PublicAPI]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct RenderPassColorAttachment
	{
		/// <summary>
		/// Gets or sets the next structure in a chain.
		/// </summary>
		/// <remarks>
		/// This property is used to create linked lists of structures, such as descriptor and state structures in the wgpu library.
		/// </remarks>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or sets the view of the texture to be used as a color attachment in a render pass.
		/// </summary>
		/// <remarks>
		/// This property represents the texture view that will receive the output of a fragment shader during a rendering operation. It is essential for defining how colors are written to textures in the wgpu library.
		/// </remarks>
		public TextureView View { get; init; }

		/// <summary>
		/// Gets or sets the depth slice for a color attachment in a render pass.
		/// </summary>
		/// <remarks>
		/// This property specifies which slice of a depth texture to use when rendering to multiple slices. It is commonly used in multi-layered render targets such as those found in 3D applications.
		/// </remarks>
		public int DepthSlice { get; init; }

		/// <summary>
		/// Gets or sets the texture view to which the contents of the attachment will be resolved.
		/// </summary>
		/// <remarks>
		/// This property is used in multisampled render targets to specify where the resolved image should be stored.
		/// It allows for efficient rendering techniques such as multisampling anti-aliasing (MSAA).
		/// </remarks>
		public TextureView ResolveTarget { get; init; }

		/// <summary>
		/// Specifies the operation to perform on the color attachment's data when starting a render pass.
		/// </summary>
		/// <remarks>
		/// This property defines how the contents of the color attachment are treated at the beginning of the render pass. Possible values include Undefined, Load, and Clear.
		/// </remarks>
		public LoadOperation LoadOperation { get; init; }

		/// <summary>
		/// Specifies what to do with the contents of a color attachment after rendering.
		/// </summary>
		/// <remarks>
		/// This enumeration is used in conjunction with RenderPassColorAttachment to determine whether to store, discard, or leave undefined the final content of the color attachment after the render pass has been executed.
		/// </remarks>
		public StoreOperation StoreOperation { get; init; }

		/// <summary>
		/// Gets or sets the color to clear the render target to.
		/// </summary>
		/// <remarks>
		/// This property specifies the RGBA color values used when clearing the color attachment during a render pass. The default value is black (0, 0, 0, 1).
		/// </remarks>
		public ColorD ClearColor { get; init; }
	}

	/// <summary>
	/// Represents a structure used to configure depth-stencil attachments for a render pass.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct RenderPassDepthStencilAttachment
	{
		/// <summary>
		/// Gets or initializes the view of a texture used for depth-stencil attachment.
		/// </summary>
		public TextureView View { get; init; }

		/// <summary>
		/// Specifies the operation to load depth data from a texture view when beginning a render pass.
		/// </summary>
		public LoadOperation DepthLoadOperatin { get; init; }

		/// <summary>
		/// Specifies the operation to perform on depth values when writing to a depth-stencil attachment.
		/// </summary>
		public StoreOperation DepthStoreOperation { get; init; }

		/// <summary>
		/// Gets or initializes the depth clear value for the render pass depth-stencil attachment.
		/// </summary>
		public float DepthClearValue { get; init; }

		/// <summary>
		/// Gets a value indicating whether the depth attachment is read-only during this render pass.
		/// </summary>
		public NativeBool DepthReadOnly { get; init; }

		/// <summary>
		/// Gets or initializes the load operation to be performed on the stencil attachment at the beginning of a render pass.
		/// </summary>
		public LoadOperation StencilLoadOperation { get; init; }

		/// <summary>
		/// Specifies the action to take with stencil data at the end of a render pass.
		/// </summary>
		public StoreOperation StencilStoreOperation { get; init; }

		/// <summary>
		/// Gets or initializes the value used to clear the stencil buffer during a render pass.
		/// </summary>
		public uint StencilClearValue { get; init; }

		/// <summary>
		/// Gets or initializes a value indicating whether the stencil attachment is read-only.
		/// </summary>
		public NativeBool StencilReadOnly { get; init; }
	}
}
