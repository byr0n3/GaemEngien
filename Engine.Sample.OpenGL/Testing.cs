using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Engine.FreeType;
using Engine.FreeType.Enums;
using Engine.OpenGL;
using Engine.OpenGL.Enums;
using Engine.OpenGL.Extensions;
using Engine.Sample.OpenGL.Extensions;
using Engine.Shared;
using glfw;
using glfw.Enums;

namespace Engine.Sample.OpenGL
{
	internal static class Testing
	{
		private const int asciiCharOffset = 32;

		private static readonly float[] vertices =
		[
			// x	y	z	texX	texY
			-0.5f, -0.5f, -0.5f, 0.0f, 0.0f,
			0.5f, -0.5f, -0.5f, 1.0f, 0.0f,
			0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
			0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
			-0.5f, 0.5f, -0.5f, 0.0f, 1.0f,
			-0.5f, -0.5f, -0.5f, 0.0f, 0.0f,

			-0.5f, -0.5f, 0.5f, 0.0f, 0.0f,
			0.5f, -0.5f, 0.5f, 1.0f, 0.0f,
			0.5f, 0.5f, 0.5f, 1.0f, 1.0f,
			0.5f, 0.5f, 0.5f, 1.0f, 1.0f,
			-0.5f, 0.5f, 0.5f, 0.0f, 1.0f,
			-0.5f, -0.5f, 0.5f, 0.0f, 0.0f,

			-0.5f, 0.5f, 0.5f, 1.0f, 0.0f,
			-0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
			-0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
			-0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
			-0.5f, -0.5f, 0.5f, 0.0f, 0.0f,
			-0.5f, 0.5f, 0.5f, 1.0f, 0.0f,

			0.5f, 0.5f, 0.5f, 1.0f, 0.0f,
			0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
			0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
			0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
			0.5f, -0.5f, 0.5f, 0.0f, 0.0f,
			0.5f, 0.5f, 0.5f, 1.0f, 0.0f,

			-0.5f, -0.5f, -0.5f, 0.0f, 1.0f,
			0.5f, -0.5f, -0.5f, 1.0f, 1.0f,
			0.5f, -0.5f, 0.5f, 1.0f, 0.0f,
			0.5f, -0.5f, 0.5f, 1.0f, 0.0f,
			-0.5f, -0.5f, 0.5f, 0.0f, 0.0f,
			-0.5f, -0.5f, -0.5f, 0.0f, 1.0f,

			-0.5f, 0.5f, -0.5f, 0.0f, 1.0f,
			0.5f, 0.5f, -0.5f, 1.0f, 1.0f,
			0.5f, 0.5f, 0.5f, 1.0f, 0.0f,
			0.5f, 0.5f, 0.5f, 1.0f, 0.0f,
			-0.5f, 0.5f, 0.5f, 0.0f, 0.0f,
			-0.5f, 0.5f, -0.5f, 0.0f, 1.0f,
		];

		private static readonly Vector3[] cubePositions =
		[
			new(2.0f, 5.0f, -15.0f),
			new(-1.5f, -2.2f, -2.5f),
			new(-3.8f, -2.0f, -12.3f),
			new(2.4f, -0.4f, -3.5f),
			new(-1.7f, 3.0f, -7.5f),
			new(1.3f, -2.0f, -2.5f),
			new(1.5f, 2.0f, 2.5f),
			new(1.5f, 0.2f, 1.5f),
			new(1.3f, 1.0f, 1.5f),
		];

		private static readonly uint[] indices =
		[
			0, 1, 3,
			1, 2, 3,
		];

		private static readonly Dictionary<char, Character> asciiChars = new();

		public static int Run(int windowWidth, int windowHeight)
		{
			GLFW.OnError += Testing.OnGlfwError;

			if (!GLFW.Initialize())
			{
				return 1;
			}

			var window = new Window(new WindowDescriptor
			{
				Width = windowWidth,
				Height = windowHeight,
				Title = "Engine Sample\0"u8,
				Hints = new WindowHints
				{
					Api = ClientApi.OpenGL,
					Resizable = true,
					ContextVersion = new WindowHints.WindowContextVersion(4, 1),
					OpenGLProfile = OpenGLProfile.Core,
					// OpenGLForwardCompat = true,
				},
			});

			Debug.Assert(window.IsValid);

			// Make the newly opened window the current render context, so we can draw to it.
			window.MakeContextCurrent();

			window.CursorMode = CursorMode.Disabled;

			var firstMouse = true;
			var lastPosition = new Vector2(windowWidth / 2f, windowHeight / 2f);
			var yaw = -90f;
			var pitch = 0f;

			var cameraPosition = new Vector3(0f, 0f, 3f);
			var cameraFront = new Vector3(0f, 0f, -1f);
			var cameraUp = new Vector3(0f, 1f, 0f);

			var fov = 45f;

			// Register a callback to fix the OpenGL viewport width and height when the window is resized.
			window.AddFramebufferSizeChanged(Testing.WindowFramebufferSizeCallback);
			window.AddCursorPositionChanged((_, position) =>
			{
				const float sensitivity = 0.25f;

				if (firstMouse)
				{
					lastPosition = position;
					firstMouse = false;
				}

				var offset = new Vector2(position.X - lastPosition.X, lastPosition.Y - position.Y);
				lastPosition = position;

				offset *= sensitivity;

				yaw += offset.X;
				pitch = float.Clamp(pitch + offset.Y, -89f, 89f);

				var direction = new Vector3(
					float.Cos(float.DegreesToRadians(yaw)) * float.Cos(float.DegreesToRadians(pitch)),
					float.Sin(float.DegreesToRadians(pitch)),
					float.Sin(float.DegreesToRadians(yaw)) * float.Cos(float.DegreesToRadians(pitch))
				);

				cameraFront = Vector3.Normalize(direction);
			});
			window.AddScrollChanged((_, offset) =>
			{
				fov = float.Clamp(fov - offset.Y, 1f, 45f);
			});

			GL.Enable(Capability.DepthTest);
			GL.Enable(Capability.Blend);
			GL.BlendFunc(BlendFactor.SrcAlpha, BlendFactor.OneMinusSrcAlpha);

			// Disable vertical synchronization (v-sync).
			GLFW.SwapInterval(0);

			// Set the window's framebuffer size to the viewport of the OpenGL context.
			// We get the window's framebuffer size as it might be different from the window's size (Retina displays).
			var framebufferSize = window.FramebufferSize;
			GL.Viewport(0, 0, framebufferSize.Width, framebufferSize.Height);

			var shaderProgram = Shaders.LoadFromFiles("shaders/vertex.glsl", "shaders/fragment.glsl");

			var vertexArray = new VertexArray();
			var verticesBuffer = new Buffer();
			var indicesBuffer = new Buffer();

			vertexArray.Bind();

			// Write the vertex data to the GPU buffer.
			verticesBuffer.Bind(BufferTarget.Array);
			Buffer.BufferData(BufferTarget.Array, Testing.vertices, BufferUsage.StaticDraw);

			// Write the index data to the GPU buffer.
			indicesBuffer.Bind(BufferTarget.ElementArray);
			Buffer.BufferData(BufferTarget.ElementArray, Testing.indices, BufferUsage.StaticDraw);

			// @todo Index = shader parameter, so place this these func on shader/program?
			unsafe
			{
				GL.VertexAttribPointer(0, 3, VertexDataType.Float, false, 5 * sizeof(float), null);
				GL.EnableVertexAttribArray(0);

				GL.VertexAttribPointer(1, 2, VertexDataType.Float, false, 5 * sizeof(float), (void*)(3 * sizeof(float)));
				GL.EnableVertexAttribArray(1);
			}

			// Unbind the vertices buffer to prevent accidental overwriting.
			// DON'T unbind the indices buffer!
			Buffer.Unbind(BufferTarget.Array);
			// We CAN safely unbind the VAO for now.
			VertexArray.Unbind();

			var textureDesc = new TextureDescriptor
			{
				WrapS = 0x2901,
				WrapT = 0x2901,
				MinFilter = 0x2703,
				MagFilter = 0x2601,
				InternalFormat = TextureFormat.Rgba,
				Format = TextureFormat.Rgba,
			};

			var texture = Textures.LoadFromFile("./images/wall.jpg", in textureDesc);
			var texture2 = Textures.LoadFromFile("./images/awesomeface.png", in textureDesc);

			var model = Matrix4x4.CreateRotationX(float.DegreesToRadians(-55f));

			shaderProgram.Use();
			shaderProgram.SetUniform("texture1\0"u8, 0);
			shaderProgram.SetUniform("texture2\0"u8, 1);
			shaderProgram.SetUniform("model\0"u8, model);

			var textShaderProgram = Shaders.LoadFromFiles("shaders/text.vert", "shaders/text.frag");
			var textProjection =
				Matrix4x4.CreateOrthographicOffCenterLeftHanded(0, framebufferSize.Width, 0, framebufferSize.Height, -1f, 1f);

			textShaderProgram.Use();
			textShaderProgram.SetUniform("projection\0"u8, textProjection);

			Testing.LoadAsciiCharacterMap();

			var textVertexArray = new VertexArray();
			var textVerticesBuffer = new Buffer();

			textVertexArray.Bind();
			textVerticesBuffer.Bind(BufferTarget.Array);
			Buffer.BufferData(BufferTarget.Array, sizeof(float) * 6 * 4, null, BufferUsage.DynamicDraw);

			unsafe
			{
				GL.EnableVertexAttribArray(0);
				GL.VertexAttribPointer(0, 4, VertexDataType.Float, false, 4 * sizeof(float), null);
			}

			Buffer.Unbind(BufferTarget.Array);
			VertexArray.Unbind();

			var lastFrame = 0f;

			var labelsBuffer = new byte[32];
			var frameTimeLabelLength = 0;
			var frameRateLabelLength = 0;

			var metrics = new PerformanceMetrics();
			metrics.PerformanceUpdated += (frameTime, frameRate) =>
			{
				frameTimeLabelLength = string.Create(System.MemoryExtensions.AsSpan(labelsBuffer, 0, 16), $"{frameTime:N8}ms");
				frameRateLabelLength = string.Create(System.MemoryExtensions.AsSpan(labelsBuffer, 16), $"{frameRate} FPS");
			};

			while (!window.ShouldClose)
			{
				var currentFrame = (float)GLFW.Time;
				var deltaTime = currentFrame - lastFrame;
				lastFrame = currentFrame;

				metrics.Update(deltaTime);

				// Input
				var cameraSpeed = 2f * deltaTime;

				if (window.GetKey(Key.W))
				{
					cameraPosition += cameraSpeed * cameraFront;
				}

				if (window.GetKey(Key.S))
				{
					cameraPosition -= cameraSpeed * cameraFront;
				}

				if (window.GetKey(Key.A))
				{
					cameraPosition -= Vector3.Normalize(Vector3.Cross(cameraFront, cameraUp)) * cameraSpeed;
				}

				if (window.GetKey(Key.D))
				{
					cameraPosition += Vector3.Normalize(Vector3.Cross(cameraFront, cameraUp)) * cameraSpeed;
				}

				// @todo Too sensitive because of too fast performance
				if (window.GetKey(Key.Escape))
				{
					window.CursorMode = window.CursorMode == CursorMode.Disabled ? CursorMode.Normal : CursorMode.Disabled;
				}

				// Clear
				GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);
				GL.Clear(ClearBuffer.Color | ClearBuffer.Depth);

				// Render

				shaderProgram.Use();

				var projection = Matrix4x4.CreatePerspectiveFieldOfView(
					float.DegreesToRadians(fov),
					(float)windowWidth / windowHeight,
					0.1f,
					100f
				);
				shaderProgram.SetUniform("projection\0"u8, projection);

				var rotate = deltaTime * float.DegreesToRadians(50f);
				model *= Matrix4x4.CreateRotationX(rotate / 2f) * Matrix4x4.CreateRotationY(rotate);
				shaderProgram.SetUniform("model\0"u8, model);

				var view = Matrix4x4.CreateLookAt(cameraPosition, cameraPosition + cameraFront, cameraUp);
				shaderProgram.SetUniform("view\0"u8, view);

				Texture.Active(TextureUnit.Texture0);
				texture.Bind(TextureTarget.Texture2D);

				Texture.Active(TextureUnit.Texture1);
				texture2.Bind(TextureTarget.Texture2D);

				vertexArray.Bind();
				GL.DrawArrays(DrawMode.Triangles, 0, Testing.vertices.Length / 5);
				// GL.DrawElements(DrawMode.TriangleFan, 6, IndexType.UnsignedInt, default);

				for (var i = 0; i < Testing.cubePositions.Length; i++)
				{
					var position = Testing.cubePositions[i];
					var angle = float.DegreesToRadians(20f * i);

					var model2 = Matrix4x4.CreateTranslation(position) *
								 Matrix4x4.CreateRotationX(angle) *
								 Matrix4x4.CreateRotationY(angle * 0.3f) *
								 Matrix4x4.CreateRotationZ(angle * 0.5f);
					shaderProgram.SetUniform("model\0"u8, model2);

					GL.DrawArrays(DrawMode.Triangles, 0, Testing.vertices.Length / 5);
				}

				if (frameTimeLabelLength != 0)
				{
					Testing.RenderText(
						textShaderProgram,
						textVertexArray,
						textVerticesBuffer,
						System.MemoryExtensions.AsSpan(labelsBuffer, 0, frameTimeLabelLength),
						25f,
						25f,
						1f,
						new Vector3(0.5f, 0.8f, 0.2f)
					);
				}

				if (frameRateLabelLength != 0)
				{
					Testing.RenderText(
						textShaderProgram,
						textVertexArray,
						textVerticesBuffer,
						System.MemoryExtensions.AsSpan(labelsBuffer, 16, frameRateLabelLength),
						25f,
						75f,
						1f,
						new Vector3(0.5f, 0.8f, 0.2f)
					);
				}

				// Show
				window.SwapBuffers();

				// Poll events
				GLFW.PollEvents();
			}

			texture.Dispose();
			texture2.Dispose();

			vertexArray.Dispose();
			verticesBuffer.Dispose();
			indicesBuffer.Dispose();
			shaderProgram.Dispose();

			textVerticesBuffer.Dispose();
			textVertexArray.Dispose();
			textShaderProgram.Dispose();

			window.Dispose();

			GLFW.Terminate();

			return default;
		}

		private static void LoadAsciiCharacterMap()
		{
			var library = new Library();

			var face = library.NewFace("fonts/Arial.ttf"u8);

			face.SetPixelSizes(0, 48);

			GL.PixelStore(PixelStoreParameter.UnpackAlignment, 1);

			for (var i = Testing.asciiCharOffset; i < 127; i++)
			{
				face.LoadCharacter((ulong)i, LoadFlags.Render);

				var texture = new Texture();
				texture.Bind(TextureTarget.Texture2D);

				Texture.Image2D(
					TextureTarget.Texture2D,
					0,
					TextureFormat.Red,
					(int)face.Glyph.Bitmap.Width,
					(int)face.Glyph.Bitmap.Rows,
					TextureFormat.Red,
					TextureType.UnsignedByte,
					face.Glyph.Bitmap.Buffer
				);

				Texture.SetParameter(TextureTarget.Texture2D, TextureParameter.WrapS, 0x812D);
				Texture.SetParameter(TextureTarget.Texture2D, TextureParameter.WrapT, 0x812D);
				Texture.SetParameter(TextureTarget.Texture2D, TextureParameter.MinFilter, 0x2601);
				Texture.SetParameter(TextureTarget.Texture2D, TextureParameter.MagFilter, 0x2601);

				Testing.asciiChars[(char)i] = new Character(
					texture,
					new Vector2<int>((int)face.Glyph.Bitmap.Width, (int)face.Glyph.Bitmap.Rows),
					new Vector2<int>(face.Glyph.BitmapLeft, face.Glyph.BitmapTop),
					(uint)face.Glyph.Advance.X
				);
			}

			Texture.Unbind(TextureTarget.Texture2D);

			face.Dispose();
			library.Dispose();
		}

		// @todo Requires optimization (very slow)
		// Pref. Use SDF fonts (https://steamcdn-a.akamaihd.net/apps/valve/2007/SIGGRAPH2007_AlphaTestedMagnification.pdf)
		private static void RenderText(Engine.OpenGL.ShaderProgram shader,
									   VertexArray vao,
									   Buffer vbo,
									   NativeString text,
									   float x,
									   float y,
									   float scale,
									   Vector3 color)
		{
			shader.Use();
			shader.SetUniform("textColor\0"u8, color);
			Texture.Active(TextureUnit.Texture0);
			vao.Bind();

			// @todo Proper encoding support
			foreach (var @char in text.ReadOnlySpan)
			{
				if (!Testing.asciiChars.TryGetValue((char)@char, out var character))
				{
					// @todo Log error
					continue;
				}

				var xPos = x + (character.Bearing.X * scale);
				var yPos = y - ((character.Size.Y - character.Bearing.Y) * scale);

				var width = character.Size.X * scale;
				var height = character.Size.Y * scale;

				// @todo Don't generate new array for every character (pref. also not every frame).
				var vertices = new[]
				{
					xPos, yPos + height, 0.0f, 0.0f,
					xPos, yPos, 0.0f, 1.0f,
					xPos + width, yPos, 1.0f, 1.0f,

					xPos, yPos + height, 0.0f, 0.0f,
					xPos + width, yPos, 1.0f, 1.0f,
					xPos + width, yPos + height, 1.0f, 0.0f,
				};

				character.Texture.Bind(TextureTarget.Texture2D);

				vbo.Bind(BufferTarget.Array);
				unsafe
				{
					fixed (void* ptr = vertices)
					{
						// @todo Don't buffer for every character (pref. also not every frame).
						Buffer.BufferSubData(BufferTarget.Array, 0, vertices.Length * sizeof(float), ptr);
					}
				}

				Buffer.Unbind(BufferTarget.Array);

				GL.DrawArrays(DrawMode.Triangles, 0, 6);

				x += (character.Advance >> 6) * scale;
			}

			VertexArray.Unbind();
			Texture.Unbind(TextureTarget.Texture2D);
		}

		private static void OnGlfwError(ErrorCode errorCode, NativeString description)
		{
			System.Console.Error.WriteLine($"[GLFW] Error {errorCode.ToString()}");

			if (description.ReadOnlySpan.Length != 0)
			{
				System.Console.Error.WriteLine(description.ToString());
			}
		}

		private static void WindowFramebufferSizeCallback(Window _, int width, int height) =>
			GL.Viewport(0, 0, width, height);
	}
}
