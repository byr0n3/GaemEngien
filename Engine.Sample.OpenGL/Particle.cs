using System.Numerics;
using System.Runtime.InteropServices;

namespace Engine.Sample.OpenGL
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct Particle : System.IEquatable<Particle>
	{
		public Vector2 Position { get; private set; }
		public Vector2 Velocity { get; private set; }
		public Vector4 Color { get; private set; }
		public float Life { get; private set; }

		public Particle() : this(Vector2.Zero, Vector2.Zero, Vector4.One, 0f)
		{
		}

		public Particle(Vector2 position, Vector2 velocity, Vector4 color, float life)
		{
			this.Position = position;
			this.Velocity = velocity;
			this.Color = color;
			this.Life = life;
		}

		public void Tick(float deltaTime)
		{
			this.Life -= deltaTime;

			if (this.Life <= 0f)
			{
				return;
			}

			this.Position -= this.Velocity * deltaTime;
			this.Color = new Vector4(this.Color.AsVector3(), this.Color.W - (deltaTime * 2.5f));
		}

		public readonly bool Equals(Particle other) =>
			this.Position.Equals(other.Position) &&
			this.Velocity.Equals(other.Velocity) &&
			this.Color.Equals(other.Color) &&
			this.Life.Equals(other.Life);

		public readonly override bool Equals(object? @object) =>
			(@object is Particle other) && this.Equals(other);

		public readonly override int GetHashCode() =>
			System.HashCode.Combine(this.Position, this.Velocity, this.Color, this.Life);

		public static bool operator ==(Particle left, Particle right) =>
			left.Equals(right);

		public static bool operator !=(Particle left, Particle right) =>
			!left.Equals(right);
	}
}
