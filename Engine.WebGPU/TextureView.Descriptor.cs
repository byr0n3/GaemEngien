using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Enums;
using wgpu.Flags;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Describes the parameters for creating a new texture view.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TextureViewDescriptor
	{
		/// <summary>
		/// Gets or sets a pointer to the next structure in the chain.
		/// This is used for extending the <see cref="TextureViewDescriptor"/> with additional data.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or sets the label for this texture view descriptor.
		/// This is typically used to name or identify a resource when debugging or encountering errors.
		/// </summary>
		public StringView Label { get; init; }

		/// <summary>
		/// Gets or sets the texture format of the view.
		/// </summary>
		public TextureFormat Format { get; init; }

		/// <summary>
		/// Gets or sets the dimension of the texture view. This determines how the texture data is interpreted.
		/// </summary>
		public TextureViewDimension Dimension { get; init; }

		/// <summary>
		/// Gets or sets the base mip level of the texture view.
		/// </summary>
		public uint BaseMipLevel { get; init; }

		/// <summary>
		/// Gets or sets the number of mip levels in the texture view.
		/// This value determines how many different resolutions are accessible through the texture view.
		/// </summary>
		public uint MipLevelCount { get; init; }

		/// <summary>
		/// Gets or sets the base array layer of the texture view.
		/// This property specifies the first mip level used in the texture view.
		/// </summary>
		public uint BaseArrayLayer { get; init; }

		/// <summary>
		/// Gets or sets the number of layers in the array texture.
		/// </summary>
		public uint ArrayLayerCount { get; init; }

		/// <summary>
		/// Specifies which aspect of a texture is to be used.
		/// This determines the subset of mip levels and array layers that are accessed.
		/// </summary>
		public TextureAspect Aspect { get; init; }

		/// <summary>
		/// Gets or sets the usage of the texture view.
		/// This field specifies how the texture will be used, such as for copying, rendering, or binding to shaders.
		/// </summary>
		public TextureUsage Usage { get; init; }
	}
}
