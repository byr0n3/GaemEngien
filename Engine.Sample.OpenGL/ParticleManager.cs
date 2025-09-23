using System.Numerics;
using Engine.OpenGL;
using Engine.OpenGL.Enums;
using Engine.Sample.OpenGL.Extensions;
using JetBrains.Annotations;

namespace Engine.Sample.OpenGL
{
	// @todo Slow and stupid
	[MustDisposeResource]
	internal struct ParticleManager : System.IDisposable
	{
		private static readonly float[] particleVertices =
		[
			0.0f, 1.0f, 0.0f, 1.0f,
			1.0f, 0.0f, 1.0f, 0.0f,
			0.0f, 0.0f, 0.0f, 0.0f,

			0.0f, 1.0f, 0.0f, 1.0f,
			1.0f, 1.0f, 1.0f, 1.0f,
			1.0f, 0.0f, 1.0f, 0.0f,
		];

		private readonly Particle[] particles;
		private readonly ShaderProgram shader;
		private readonly Texture texture;
		private readonly VertexArray vao;
		private readonly Buffer buffer;

		private int current;

		public ParticleManager(ShaderProgram shader, Texture texture, int capacity)
		{
			this.shader = shader;
			this.texture = texture;
			this.particles = new Particle[capacity];
			this.vao = new VertexArray();
			this.buffer = new Buffer();

			this.Initialize();
		}

		private readonly void Initialize()
		{
			this.vao.Bind();

			this.buffer.Bind(BufferTarget.Array);
			Buffer.BufferData(BufferTarget.Array, ParticleManager.particleVertices, BufferUsage.StaticDraw);

			VertexArray.EnableAttribute(0);
			VertexArray.AttributePointer(0, 4, VertexDataType.Float, 4 * sizeof(float));

			Buffer.Unbind(BufferTarget.Array);
			VertexArray.Unbind();
		}

		public void Tick(float deltaTime, Ball ball)
		{
			for (var i = 0; i < this.particles.Length; i++)
			{
				this.particles[i].Tick(deltaTime);
			}

			this.SpawnNewParticle(ball);
			this.SpawnNewParticle(ball);
		}

		public readonly void Draw()
		{
			GL.BlendFunc(BlendFactor.SrcAlpha, BlendFactor.One);

			this.shader.Use();
			this.texture.Bind(TextureTarget.Texture2D);
			this.vao.Bind();

			// @todo Batch render
			// @todo Only loop over range that is active
			foreach (var particle in this.particles)
			{
				if (particle.Life <= 0f)
				{
					continue;
				}

				this.shader.SetUniform("offset\0"u8, particle.Position);
				this.shader.SetUniform("color\0"u8, particle.Color);

				GL.DrawArrays(DrawMode.Triangles, 0, 6);
			}

			VertexArray.Unbind();
			Texture.Unbind(TextureTarget.Texture2D);

			GL.BlendFunc(BlendFactor.SrcAlpha, BlendFactor.OneMinusSrcAlpha);
		}

		private void SpawnNewParticle(Ball ball)
		{
			var index = this.current++;

			if (this.current >= this.particles.Length)
			{
				this.current = 0;
			}

			var offset = new Vector2(ball.Radius, ball.Radius);

			var random = -((System.Random.Shared.NextSingle() * (5f - 4.9f)) + 4.9f);
			var randomColor = 0.5f + ((System.Random.Shared.NextSingle() % 100) / 100f);

			var particle = new Particle(
				position: (ball.Position + offset).Add(random),
				velocity: ball.Velocity.Multiply(0.1f),
				color: new Vector4(randomColor, randomColor, randomColor, 1f),
				life: 1f
			);

			this.particles[index] = particle;
		}

		public readonly void Dispose()
		{
			this.vao.Dispose();
			this.buffer.Dispose();
		}
	}
}
