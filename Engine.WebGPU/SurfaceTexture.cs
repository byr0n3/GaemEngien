using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Enums;
using wgpu.Structs;

namespace wgpu
{
	/// <summary>
	/// Represents the texture and status of a surface.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SurfaceTexture
	{
		/// <summary>
		/// Gets the next structure in a chain of structures.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets the texture associated with the surface.
		/// </summary>
		public Texture Texture { get; init; }

		/// <summary>
		/// Gets the status of the last attempt to get the current texture.
		/// </summary>
		public SurfaceGetCurrentTextureStatus Status { get; init; }
	}
}
