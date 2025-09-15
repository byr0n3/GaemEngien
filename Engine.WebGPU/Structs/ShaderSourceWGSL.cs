using System.Runtime.InteropServices;
using Engine.Shared;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents a shader source in WGSL format.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct ShaderSourceWGSL
	{
		/// <summary>
		/// Gets or initializes a value indicating the chain for this shader source.
		/// </summary>
		public ChainedStruct Chain { get; init; }

		/// <summary>
		/// Gets or initializes the code for this WGSL shader source.
		/// </summary>
		public StringView Code { get; init; }

		/// <summary>
		/// Implicitly converts a <see cref="ShaderSourceWGSL"/> instance to a pointer of type <see cref="ChainedStruct"/>.
		/// </summary>
		/// <param name="value">The <see cref="ShaderSourceWGSL"/> instance to convert.</param>
		/// <returns>A pointer of type <see cref="ChainedStruct"/> pointing to the underlying unmanaged memory of the <see cref="ShaderSourceWGSL"/> instance.</returns>
		public static unsafe implicit operator Pointer<ChainedStruct>(in ShaderSourceWGSL value)
		{
			fixed (ShaderSourceWGSL* ptr = &value)
			{
				return (ChainedStruct*)ptr;
			}
		}
	}
}
