using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents the size of a texture in 3D space.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Extent3D
	{
		/// <summary>
		/// Gets or initializes the width of the texture.
		/// </summary>
		public required uint Width { get; init; }

		/// <summary>
		/// Gets or initializes the height of a texture.
		/// </summary>
		public required uint Height { get; init; }

		/// <summary>
		/// Gets or sets the depth of a texture in 3D format, or the number of layers in an array texture.
		/// </summary>
		public required uint DepthOrArrayLayers { get; init; }

		/// <inheritdoc cref="Extent3D"/>
		/// <param name="width">The width of the texture.</param>
		/// <param name="height">The height of the texture.</param>
		/// <param name="depthOrArrayLayers">
		/// The amount of dimensions the texture has:
		/// 1 = color, 2 = image, 3 = grid of voxels
		/// </param>
		[SetsRequiredMembers]
		public Extent3D(uint width, uint height, uint depthOrArrayLayers = 1)
		{
			this.Width = width;
			this.Height = height;
			this.DepthOrArrayLayers = depthOrArrayLayers;
		}
	}
}
