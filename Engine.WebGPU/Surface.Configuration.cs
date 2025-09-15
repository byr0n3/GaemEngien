using System.Drawing;
using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Enums;
using wgpu.Flags;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents the configuration for a surface used in rendering.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SurfaceConfiguration
	{
		/// <summary>
		/// Represents the next structure in a chain of chained structures, allowing for linked lists of various descriptor and state structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Represents the device associated with this surface configuration, which is used for rendering operations.
		/// </summary>
		public Device Device { get; init; }

		/// <summary>
		/// The pixel format of the textures used by this surface configuration.
		/// </summary>
		public TextureFormat Format { get; init; }

		/// <summary>
		/// Specifies the intended usage of the texture in the surface configuration.
		/// </summary>
		public TextureUsage Usage { get; init; }

		/// <summary>
		/// The width of the surface configuration.
		/// </summary>
		public int Width { get; init; }

		/// <summary>
		/// The height of the surface configuration.
		/// </summary>
		public int Height { get; init; }

		private readonly nint viewFormatCount;

		private readonly Pointer<TextureFormat> viewFormats;

		/// <summary>
		/// Specifies the alpha mode to be used for surface configuration.
		/// </summary>
		public CompositeAlphaMode AlphaMode { get; init; }

		/// <summary>
		/// Specifies the presentation mode to be used for surface configuration.
		/// </summary>
		public PresentMode PresentMode { get; init; }

		/// <summary>
		/// Gets or sets the size of the surface in pixels.
		/// </summary>
		public Size Size
		{
			get => new(this.Width, this.Height);
			init
			{
				this.Width = value.Width;
				this.Height = value.Height;
			}
		}

		/// <summary>
		/// Gets or sets a read-only span of texture formats supported by the view.
		/// </summary>
		public unsafe System.ReadOnlySpan<TextureFormat> ViewFormats
		{
			get => new(this.viewFormats, (int)this.viewFormatCount);
			init
			{
				fixed (TextureFormat* ptr = value)
				{
					this.viewFormats = ptr;
				}

				this.viewFormatCount = value.Length;
			}
		}
	}
}
