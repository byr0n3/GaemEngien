using System.Runtime.InteropServices;
using Engine.Native;
using JetBrains.Annotations;
using wgpu.Enums;
using wgpu.Flags;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents the capabilities of a surface for a given adapter.
	/// </summary>
	[MustDisposeResource]
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SurfaceCapabilities : System.IDisposable
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Specifies the intended usage for textures in a surface.
		/// </summary>
		public TextureUsage Usages { get; init; }

		private readonly nint formatCount;

		private readonly Pointer<TextureFormat> formats;

		private readonly nint presentModeCount;

		private readonly Pointer<PresentMode> presentModes;

		private readonly nint alphaModeCount;

		private readonly Pointer<CompositeAlphaMode> alphaModes;

		/// <summary>
		/// Represents the texture formats supported by a surface.
		/// </summary>
		public unsafe System.ReadOnlySpan<TextureFormat> Formats =>
			new(this.formats, (int)this.formatCount);

		/// <summary>
		/// Represents the present modes supported by a surface.
		/// </summary>
		public unsafe System.ReadOnlySpan<PresentMode> PresentModes =>
			new(this.presentModes, (int)this.presentModeCount);

		/// <summary>
		/// Represents the alpha modes supported by a surface.
		/// </summary>
		public unsafe System.ReadOnlySpan<CompositeAlphaMode> AlphaModes =>
			new(this.alphaModes, (int)this.alphaModeCount);

		/// <summary>
		/// Releases unmanaged resources associated with this instance.
		/// </summary>
		public void Dispose() =>
			SurfaceCapabilitiesNative.FreeMembers(this);
	}
}
