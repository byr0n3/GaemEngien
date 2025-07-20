using System.Runtime.InteropServices;

namespace wgpu.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct TexelCopyBufferLayout
	{
		public ulong Offset { get; init; }

		public uint BytesPerRow { get; init; }

		public uint RowsPerImage { get; init; }
	}
}
