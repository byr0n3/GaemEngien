using System.Runtime.InteropServices;

namespace Engine.Shared
{
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct Vector2<TValue>
		where TValue : unmanaged
	{
		public readonly TValue X;
		public readonly TValue Y;

		public Vector2(TValue value) : this(value, value)
		{
		}

		public Vector2(TValue x, TValue y)
		{
			this.X = x;
			this.Y = y;
		}
	}
}
