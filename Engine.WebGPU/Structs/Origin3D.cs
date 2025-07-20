using System.Runtime.InteropServices;

namespace wgpu.Structs
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Origin3D
	{
		public readonly uint X;
		public readonly uint Y;
		public readonly uint Z;

		public Origin3D(uint x, uint y, uint z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}
	}
}
