using System.Numerics;
using System.Runtime.InteropServices;
using Engine.OpenGL;
using Engine.OpenGL.Enums;
using JetBrains.Annotations;

namespace Engine.Sample.OpenGL
{
	[MustDisposeResource]
	[StructLayout(LayoutKind.Sequential)]
	internal readonly struct SpriteRenderer : System.IDisposable
	{
		// @todo use indexing?
		private static readonly float[] vertices =
		[
			// position|texture
			0.0f, 1.0f, 0.0f, 1.0f,
			1.0f, 0.0f, 1.0f, 0.0f,
			0.0f, 0.0f, 0.0f, 0.0f,

			0.0f, 1.0f, 0.0f, 1.0f,
			1.0f, 1.0f, 1.0f, 1.0f,
			1.0f, 0.0f, 1.0f, 0.0f,
		];

		private readonly Buffer buffer;
		private readonly VertexArray vertexArray;
		private readonly Engine.OpenGL.ShaderProgram shader;

		public SpriteRenderer(Engine.OpenGL.ShaderProgram shader)
		{
			this.shader = shader;
			this.buffer = new Buffer();
			this.vertexArray = new VertexArray();

			this.InitializeVertices();
		}

		public void Draw(Texture texture,
						 Vector2 position,
						 Vector2 size = default,
						 float rotation = default,
						 Vector3 color = default)
		{
			if (size == default)
			{
				size = Vector2.One;
			}

			if (color == default)
			{
				color = Vector3.One;
			}

			var model = Matrix4x4.Identity;
			// The following instructions should be read BACKWARDS.
			{
				// Apply scaling.
				model *= Matrix4x4.CreateScale(new Vector3(size, 1f));

				// Apply rotation.
				// We give HALF the sprite's size as the center point to rotate around the center of the sprite, instead of the top-left.
				model *= Matrix4x4.CreateRotationZ(float.DegreesToRadians(rotation), new(size / 2f, 0f));

				// Apply position changes.
				model *= Matrix4x4.CreateTranslation(new Vector3(position, 0f));
			}

			this.shader.Use();

			this.shader.SetUniform("model\0"u8, model);
			this.shader.SetUniform("spriteColor\0"u8, color);

			Texture.Active(TextureUnit.Texture0);
			texture.Bind(TextureTarget.Texture2D);

			this.vertexArray.Bind();
			GL.DrawArrays(DrawMode.Triangles, 0, SpriteRenderer.vertices.Length / 4);
			VertexArray.Unbind();
		}

		private void InitializeVertices()
		{
			this.buffer.Bind(BufferTarget.Array);
			Buffer.BufferData(BufferTarget.Array, SpriteRenderer.vertices, BufferUsage.StaticDraw);

			this.vertexArray.Bind();

			VertexArray.EnableAttribute(0);
			VertexArray.AttributePointer(0, 4, VertexDataType.Float, 4 * sizeof(float));

			Buffer.Unbind(BufferTarget.Array);
			VertexArray.Unbind();
		}

		public void Dispose()
		{
			this.buffer.Dispose();
			this.vertexArray.Dispose();
		}
	}
}
