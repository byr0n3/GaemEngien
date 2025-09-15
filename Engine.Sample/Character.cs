using System.Runtime.InteropServices;
using Engine.Shared;
using Engine.OpenGL;

namespace Engine.Sample
{
	[StructLayout(LayoutKind.Sequential)]
	internal readonly struct Character
	{
		public readonly Texture Texture;
		public readonly Vector2<int> Size;
		public readonly Vector2<int> Bearing;
		public readonly uint Advance;

		public Character(Texture texture, Vector2<int> size, Vector2<int> bearing, uint advance)
		{
			this.Texture = texture;
			this.Size = size;
			this.Bearing = bearing;
			this.Advance = advance;
		}
	}
}
