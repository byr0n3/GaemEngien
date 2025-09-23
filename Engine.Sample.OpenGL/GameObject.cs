using System.Numerics;
using System.Runtime.InteropServices;
using Engine.OpenGL;

namespace Engine.Sample.OpenGL
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct GameObject : System.IEquatable<GameObject>
	{
		public byte Type;
		public Vector2 Position;
		public Vector2 Size;
		public Vector3 Color;
		public float Rotation;
		public bool Destroyed;
		public Texture Texture;

		public readonly bool Solid =>
			this.Type == 1;

		public GameObject(byte type, Vector2 position, Vector2 size, Vector3 color, float rotation, bool destroyed, Texture texture)
		{
			this.Type = type;
			this.Position = position;
			this.Size = size;
			this.Color = color;
			this.Rotation = rotation;
			this.Destroyed = destroyed;
			this.Texture = texture;
		}

		public readonly bool Collides(GameObject other) =>
			this.Collides(other.Position, other.Size);

		public readonly bool Collides(Vector2 position, Vector2 size)
		{
			var x = (this.Position.X + this.Size.X >= position.X) &&
					(position.X + size.X >= this.Position.X);

			var y = (this.Position.Y + this.Size.Y >= position.Y) &&
					(position.Y + size.Y >= this.Position.Y);

			return x && y;
		}

		public readonly void Draw(in SpriteRenderer renderer)
		{
			if (!this.Destroyed)
			{
				renderer.Draw(this.Texture, this.Position, this.Size, this.Rotation, this.Color);
			}
		}

		public readonly bool Equals(GameObject other) =>
			(this.Type == other.Type) &&
			this.Position.Equals(other.Position);

		public readonly override bool Equals(object? obj) =>
			obj is GameObject other && this.Equals(other);

		public readonly override int GetHashCode() =>
			this.Type ^ (int)this.Position.X ^ (int)this.Position.Y;

		public static bool operator ==(GameObject left, GameObject right) =>
			left.Equals(right);

		public static bool operator !=(GameObject left, GameObject right) =>
			!left.Equals(right);
	}
}
