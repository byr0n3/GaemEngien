using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Engine.OpenGL;
using Engine.OpenGL.Enums;
using Engine.OpenGL.Extensions;
using Engine.Sample.OpenGL.Extensions;
using glfw;
using glfw.Enums;
using JetBrains.Annotations;

namespace Engine.Sample.OpenGL
{
	[MustDisposeResource]
	[StructLayout(LayoutKind.Sequential)]
	internal struct Breakout : System.IDisposable
	{
		private const float ballRadius = 12.5f;

		private static readonly TextureDescriptor spriteTextureDescriptor = new()
		{
			Target = TextureTarget.Texture2D,
			WrapS = 0x2901,
			WrapT = 0x2901,
			MinFilter = 0x2703,
			MagFilter = 0x2601,
			InternalFormat = TextureFormat.Rgba,
			Format = TextureFormat.Rgba,
		};

		private static readonly Vector2 initialBallVelocity = new(100f, -350f);

		private static bool globallyInitialized;

		private readonly Window window;
		private readonly SpriteRenderer spriteRenderer;
		private readonly ResourceManager resourceManager;

		public GameState State { get; private set; } = GameState.Active;

		public readonly bool Running =>
			!this.window.ShouldClose;

		private GameObject player;
		private Ball ball;
		private Level level;
		private ParticleManager particleManager;

		private float lastFrame;
		private PerformanceMetrics metrics;

		public Breakout(int windowWidth, int windowHeight)
		{
			if (!Breakout.globallyInitialized)
			{
				Breakout.GlobalInitialize();
			}

			this.window = new Window(new WindowDescriptor
			{
				Width = windowWidth,
				Height = windowHeight,
				Title = "Breakout\0"u8,
				Hints = new WindowHints
				{
					Api = ClientApi.OpenGL,
					Resizable = true,
					ContextVersion = new WindowHints.WindowContextVersion(4, 1),
					OpenGLProfile = OpenGLProfile.Core,
					Samples = 4,
					// OpenGLForwardCompat = true,
				},
			});

			Debug.Assert(this.window.IsValid);

			// Activate the OpenGL context of the window.
			this.window.MakeContextCurrent();

			// Register a callback to handle framebuffer size changes, for example when the window is resized.
			this.window.AddFramebufferSizeChanged(Breakout.OnFramebufferSizeChanged);

			// @todo Register a callback to handle input.

			// Disable vertical synchronization (v-sync).
			GLFW.SwapInterval(0);

			GL.Enable(Capability.Multisample);

			// Enable blending and change the blending function.
			GL.Enable(Capability.Blend);
			GL.BlendFunc(BlendFactor.SrcAlpha, BlendFactor.OneMinusSrcAlpha);

			// Manually resize the framebuffer once.
			// We get the window's framebuffer size as it might be different from the window's size (Retina displays).
			var framebufferSize = this.window.FramebufferSize;
			GL.Viewport(0, 0, framebufferSize.Width, framebufferSize.Height);

			this.resourceManager = new ResourceManager();

			var projection = Matrix4x4.CreateOrthographicOffCenter(0, windowWidth, windowHeight, 0, -1f, 1f);

			var spriteShader = Shaders.LoadFromFiles("./shaders/breakout/sprite.vert", "./shaders/breakout/sprite.frag");

			spriteShader.Use();
			spriteShader.SetUniform("image\0"u8, 0);
			spriteShader.SetUniform("projection\0"u8, projection);

			this.resourceManager.TryAdd(ShaderKey.Sprite, spriteShader);

			var particleShader = Shaders.LoadFromFiles("./shaders/breakout/particle.vert", "./shaders/breakout/particle.frag");

			particleShader.Use();
			particleShader.SetUniform("projection\0"u8, projection);

			this.resourceManager.TryAdd(ShaderKey.Particle, particleShader);

			this.spriteRenderer = new SpriteRenderer(spriteShader);

			this.resourceManager.TryAdd(TextureKey.Background,
										Textures.LoadFromFile("./images/background.jpg", in Breakout.spriteTextureDescriptor));
			this.resourceManager.TryAdd(TextureKey.Paddle,
										Textures.LoadFromFile("./images/paddle.png", in Breakout.spriteTextureDescriptor));
			this.resourceManager.TryAdd(TextureKey.Ball,
										Textures.LoadFromFile("./images/awesomeface.png", in Breakout.spriteTextureDescriptor));
			this.resourceManager.TryAdd(TextureKey.Block,
										Textures.LoadFromFile("./images/block.png", in Breakout.spriteTextureDescriptor));
			this.resourceManager.TryAdd(TextureKey.SolidBlock,
										Textures.LoadFromFile("./images/block_solid.png", in Breakout.spriteTextureDescriptor));
			this.resourceManager.TryAdd(TextureKey.Particle,
										Textures.LoadFromFile("./images/particle.png", in Breakout.spriteTextureDescriptor));

			this.particleManager = new ParticleManager(this.resourceManager.Get(ShaderKey.Particle),
													   this.resourceManager.Get(TextureKey.Particle), 500);

			this.level = Level.ReadLevelFile("./levels/one.lvl",
											 windowWidth,
											 windowHeight / 2,
											 this.resourceManager.Get(TextureKey.Block),
											 this.resourceManager.Get(TextureKey.SolidBlock));

			var playerSize = new Vector2(100f, 20f);

			this.player = new GameObject(
				default,
				new Vector2((windowWidth / 2f) - (playerSize.X / 2f), windowHeight - playerSize.Y - 10f),
				playerSize,
				new Vector3(1f, 1f, 1f),
				0f,
				false,
				this.resourceManager.Get(TextureKey.Paddle)
			);

			this.ball = new Ball(
				this.player.Position + new Vector2((playerSize.X / 2f) - Breakout.ballRadius, -Breakout.ballRadius * 2f),
				Breakout.ballRadius,
				Breakout.initialBallVelocity,
				this.resourceManager.Get(TextureKey.Ball)
			);

			this.metrics = new PerformanceMetrics();
			this.metrics.PerformanceUpdated += this.UpdateWindowTitle;

			GL.ClearColor(0.123f, 0.456f, 0.789f, 1f);
		}

		private readonly void UpdateWindowTitle(float frameTime, int frameRate)
		{
			System.Span<byte> buffer = stackalloc byte[48];

			var length = string.Create(buffer, $"Breakout | {frameTime:N8}ms | {frameRate} FPS");

			this.window.Title = buffer.Slice(0, length);
		}

		public void Update()
		{
			if (this.State == GameState.Invalid)
			{
				return;
			}

			var currentFrame = (float)GLFW.Time;
			var deltaTime = currentFrame - this.lastFrame;
			this.lastFrame = currentFrame;

			this.metrics.Update(deltaTime);

			GLFW.PollEvents();

			this.Input(deltaTime);
			this.Tick(deltaTime);
			this.Render();
		}

		private void Input(float deltaTime)
		{
			const float playerSpeed = 250f;

			if (this.State != GameState.Active)
			{
				return;
			}

			if ((this.window.GetKey(Key.A) || this.window.GetKey(Key.Left)) &&
				this.player.Position.X >= 0f)
			{
				this.player.Position.X -= playerSpeed * deltaTime;

				if (this.ball.Stuck)
				{
					this.ball.Position = new Vector2(this.ball.Position.X - (playerSpeed * deltaTime), this.ball.Position.Y);
				}
			}

			if ((this.window.GetKey(Key.D) || this.window.GetKey(Key.Right)) &&
				(this.player.Position.X <= (this.window.Size.Width - this.player.Size.X)))
			{
				this.player.Position.X += playerSpeed * deltaTime;

				if (this.ball.Stuck)
				{
					this.ball.Position = new Vector2(this.ball.Position.X + (playerSpeed * deltaTime), this.ball.Position.Y);
				}
			}

			if (this.window.GetKey(Key.Space))
			{
				this.ball.Stuck = false;
			}
		}

		private void Tick(float deltaTime)
		{
			this.ball.Move(deltaTime, this.window.Size.Width);

			if (this.ball.Position.Y >= this.window.Size.Height)
			{
				// @todo Don't re-read from file
				this.level = Level.ReadLevelFile("./levels/one.lvl",
												 this.window.Size.Width,
												 this.window.Size.Height / 2,
												 this.resourceManager.Get(TextureKey.Block),
												 this.resourceManager.Get(TextureKey.SolidBlock));

				this.player.Position = new Vector2(
					(this.window.Size.Width / 2f) - (this.player.Size.X / 2f),
					this.window.Size.Height - this.player.Size.Y - 10f
				);

				this.ball.Reset(
					this.player.Position + new Vector2((this.player.Size.X / 2f) - Breakout.ballRadius, -Breakout.ballRadius * 2f),
					Breakout.initialBallVelocity
				);
			}

			this.CheckCollisions();

			this.particleManager.Tick(deltaTime, this.ball);
		}

		private readonly void Render()
		{
			GL.Clear(ClearBuffer.Color);

			this.spriteRenderer.Draw(
				this.resourceManager.Get(TextureKey.Background),
				default,
				new Vector2(this.window.Size.Width, this.window.Size.Height)
			);

			this.level.Draw(in this.spriteRenderer);

			this.particleManager.Draw();

			this.ball.Draw(in this.spriteRenderer);

			this.player.Draw(in this.spriteRenderer);

			this.window.SwapBuffers();
		}

		private void CheckCollisions()
		{
			if (this.ball.Stuck)
			{
				return;
			}

			for (var row = 0; row < this.level.Objects.GetLength(0); row++)
			for (var column = 0; column < this.level.Objects.GetLength(1); column++)
			{
				var @object = this.level.Objects[row, column];

				if (@object.Destroyed)
				{
					continue;
				}

				var collision = this.ball.Collides(@object);

				if (collision == default)
				{
					continue;
				}

				if (!@object.Solid)
				{
					@object.Destroyed = true;

					this.level.Objects[row, column] = @object;
				}

				// Horizontal collision
				if (collision.Direction is Direction.Right or Direction.Left)
				{
					this.ball.Velocity.X = -this.ball.Velocity.X;

					var pen = this.ball.Radius - float.Abs(collision.Difference.X);

					this.ball.Position = new Vector2(
						this.ball.Position.X + ((collision.Direction is Direction.Left) ? pen : -pen),
						this.ball.Position.Y
					);
				}
				// Vertical collision
				else
				{
					this.ball.Velocity.Y = -this.ball.Velocity.Y;

					var pen = this.ball.Radius - float.Abs(collision.Difference.Y);

					this.ball.Position = new Vector2(
						this.ball.Position.X,
						this.ball.Position.Y - ((collision.Direction is Direction.Up) ? pen : -pen)
					);
				}
			}

			this.PaddleCollision();
		}

		private void PaddleCollision()
		{
			const float strength = 2f;

			var collision = this.ball.Collides(this.player);

			if (collision == default)
			{
				return;
			}

			var center = this.player.Position.X + (this.player.Size.X / 2f);
			var distance = (this.ball.Position.X + this.ball.Radius) - center;
			var percentage = distance / (this.player.Size.X / 2f);

			var prevVelocity = this.ball.Velocity;

			this.ball.Velocity.X = Breakout.initialBallVelocity.X * percentage * strength;
			// Don't just invert the velocity, but make it always a negative direction.
			// This prevents you from being able to bounce the ball back after making it hit the bottom of the paddle somehow.
			this.ball.Velocity.Y = -float.Abs(this.ball.Velocity.Y);
			this.ball.Velocity = Vector2.Normalize(this.ball.Velocity) * prevVelocity.Length();
		}

		public readonly void Dispose()
		{
			this.spriteRenderer.Dispose();
			this.resourceManager.Dispose();
			this.window.Dispose();

			Unsafe.AsRef(in this) = default;
		}

		private static void GlobalInitialize()
		{
			GLFW.OnError += Breakout.OnGlfwError;

			if (!GLFW.Initialize())
			{
				Debug.Fail("Failed to initialize GLFW.");
			}

			Breakout.globallyInitialized = true;
		}

		private static void OnGlfwError(ErrorCode errorCode, NativeString description)
		{
			System.Console.Error.WriteLine($"[GLFW] Error {errorCode.ToString()}");

			if (description.ReadOnlySpan.Length != 0)
			{
				System.Console.Error.WriteLine(description.ToString());
			}
		}

		private static void OnFramebufferSizeChanged(Window _, int width, int height) =>
			GL.Viewport(0, 0, width, height);

		public enum GameState
		{
			Invalid = 0,
			Active,
			Menu,
			Won,
		}
	}
}
