using System.Runtime.InteropServices;
using Engine.Native;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents a descriptor for a Metal layer used as a surface source in WebGPU.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct SurfaceSourceMetalLayerDescriptor
	{
		/// <summary>
		/// Represents a chain structure used to link multiple structures together in the wgpu library.
		/// </summary>
		public required ChainedStruct Chain { get; init; }

		/// <summary>
		/// Pointer to a Metal layer used as a source for creating surfaces in the wgpu library.
		/// </summary>
		public required nint Layer { get; init; }

		/// <summary>
		/// Implicitly converts a <see cref="SurfaceSourceMetalLayerDescriptor"/> instance to a <see cref="Engine.Native.Pointer{TValue}"/> of type <see cref="ChainedStruct"/>.
		/// </summary>
		/// <param name="value">The <see cref="SurfaceSourceMetalLayerDescriptor"/> instance to convert.</param>
		/// <returns>A pointer to the <see cref="ChainedStruct"/> part of the <see cref="SurfaceSourceMetalLayerDescriptor"/>.</returns>
		public static unsafe implicit operator Pointer<ChainedStruct>(in SurfaceSourceMetalLayerDescriptor value)
		{
			fixed (SurfaceSourceMetalLayerDescriptor* ptr = &value)
			{
				return (ChainedStruct*)ptr;
			}
		}
	}
}
