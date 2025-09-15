using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Enums;
using wgpu.Flags;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Describes the parameters used to create a texture.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TextureDescriptor
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of linked structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes a label for the texture, which can be used to identify or debug it.
		/// </summary>
		public StringView Label { get; init; }

		/// <summary>
		/// Gets or sets the intended usage of the texture.
		/// </summary>
		public TextureUsage Usage { get; init; }

		/// <summary>
		/// Specifies the dimensionality of a texture.
		/// </summary>
		public TextureDimension Dimension { get; init; }

		/// <summary>
		/// Gets or initializes the size of the texture.
		/// </summary>
		public Extent3D Size { get; init; }

		/// <summary>
		/// Gets or sets the format of the texture.
		/// </summary>
		public TextureFormat Format { get; init; }

		/// <summary>
		/// Gets or initializes the number of mipmap levels for this texture.
		/// </summary>
		public uint MipLevelCount { get; init; }

		/// <summary>
		/// Gets or initializes the number of samples in a texture.
		/// </summary>
		public uint SampleCount { get; init; }

		private readonly nint viewFormatCount;

		private readonly Pointer<TextureFormat> viewFormats;

		/// <summary>
		/// Gets or initializes the array of texture formats used for views.
		/// </summary>
		public unsafe System.ReadOnlySpan<TextureFormat> ViewFormats
		{
			get => new(this.viewFormats, (int)this.viewFormatCount);
			init
			{
				this.viewFormatCount = value.Length;
				this.viewFormats = value;
			}
		}
	}
}
