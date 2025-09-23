using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Engine.OpenGL;

namespace Engine.Sample.OpenGL
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct Ball
	{
		public bool Stuck;
		public Vector2 Velocity;

		private GameObject gameObject;

		public readonly float Radius;

		public Vector2 Position
		{
			readonly get => this.gameObject.Position;
			set => this.gameObject.Position = value;
		}

		public readonly Vector2 Size =>
			this.gameObject.Size;

		public Ball() : this(Vector2.Zero, 12.5f, Vector2.Zero, default)
		{
		}

		public Ball(Vector2 position, float radius, Vector2 velocity, Texture texture)
		{
			this.Radius = radius;

			this.Velocity = velocity;

			this.gameObject = new GameObject(
				default,
				position: position,
				size: new Vector2(radius * 2f),
				color: Vector3.One,
				rotation: 0f,
				destroyed: false,
				texture: texture
			);

			this.Stuck = true;
		}

		public readonly CollisionResult Collides(GameObject other) =>
			this.Collides(other.Position, other.Size);

		public readonly CollisionResult Collides(Vector2 position, Vector2 size)
		{
			var center = new Vector2(this.Position.X + this.Radius, this.Position.Y + this.Radius);
			var aabbHalfExtents = new Vector2(size.X / 2f, size.Y / 2f);
			var aabbCenter = position + aabbHalfExtents;

			var diff = Vector2.Clamp(center - aabbCenter, -aabbHalfExtents, aabbHalfExtents);
			var closest = aabbCenter + diff;
			diff = closest - center;

			var collides = diff.Length() < this.Radius;

			if (!collides)
			{
				return default;
			}

			return new CollisionResult(Ball.VectorDirection(diff), diff);
		}

		private static readonly Vector2[] compass =
		[
			new(0f, 1f),
			new(1f, 0f),
			new(0f, -1f),
			new(-1f, 0f),
		];

		private static Direction VectorDirection(Vector2 vector)
		{
			var max = 0f;
			var result = Direction.Invalid;

			for (var i = 0; i < Ball.compass.Length; i++)
			{
				var direction = Ball.compass[i];

				var dot = Vector2.Dot(direction, vector);

				if (dot <= max)
				{
					continue;
				}

				max = dot;
				result = Unsafe.BitCast<int, Direction>(i);
			}

			return result;
		}

		public readonly void Draw(in SpriteRenderer renderer) =>
			this.gameObject.Draw(in renderer);

		public void Move(float deltaTime, int windowWidth)
		{
			if (this.Stuck)
			{
				return;
			}

			this.Position += this.Velocity * deltaTime;

			if (this.Position.X <= 0f)
			{
				this.Velocity.X = -this.Velocity.X;
				this.Position = new Vector2(0f, this.Position.Y);
			}
			else if ((this.Position.X + this.gameObject.Size.X) >= windowWidth)
			{
				this.Velocity.X = -this.Velocity.X;
				this.Position = new Vector2(windowWidth - this.gameObject.Size.X, this.Position.Y);
			}

			if (this.Position.Y <= 0f)
			{
				this.Velocity.Y = -this.Velocity.Y;
				this.Position = new Vector2(this.Position.X, 0f);
			}
		}

		public void Reset(Vector2 position, Vector2 velocity)
		{
			this.Position = position;
			this.Velocity = velocity;
			this.Stuck = true;
		}
	}

	[StructLayout(LayoutKind.Sequential)]
	internal readonly struct CollisionResult : System.IEquatable<CollisionResult>
	{
		public readonly Direction Direction;

		public readonly Vector2 Difference;

		public CollisionResult(Direction direction, Vector2 difference)
		{
			this.Direction = direction;
			this.Difference = difference;
		}

		public bool Equals(CollisionResult other) =>
			(this.Direction == other.Direction) &&
			this.Difference.Equals(other.Difference);

		public override bool Equals(object? @object) =>
			(@object is CollisionResult other) && this.Equals(other);

		public override int GetHashCode() =>
			System.HashCode.Combine(Unsafe.BitCast<Direction, int>(this.Direction), this.Difference);

		public static bool operator ==(CollisionResult left, CollisionResult right) =>
			left.Equals(right);

		public static bool operator !=(CollisionResult left, CollisionResult right) =>
			!left.Equals(right);
	}
}
