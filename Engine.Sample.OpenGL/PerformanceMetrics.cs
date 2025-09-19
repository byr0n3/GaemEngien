using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Engine.Sample.OpenGL
{
	[StructLayout(LayoutKind.Sequential)]
	internal ref struct PerformanceMetrics
	{
		private float ticks;
		private int frameTimeLength;
		private int frameRateLength;

		private readonly System.Span<byte> buffer;
		private readonly int bufferOffset;

		public System.ReadOnlySpan<byte> FrameTime =>
			this.buffer.Slice(0, this.frameTimeLength);

		public System.ReadOnlySpan<byte> FrameRate =>
			this.buffer.Slice(this.bufferOffset, this.frameRateLength);

		public PerformanceMetrics(System.Span<byte> buffer)
		{
			this.buffer = buffer;
			this.bufferOffset = this.buffer.Length / 2;
		}

		public void Update(float deltaTime)
		{
			this.ticks += deltaTime;

			if (this.ticks < 1f)
			{
				return;
			}

			var frameRate = (int)(1f / deltaTime);

			this.frameTimeLength = PerformanceMetrics.Write(this.buffer.Slice(0, this.bufferOffset), $"{(deltaTime * 1000):F6}ms\0");
			this.frameRateLength = PerformanceMetrics.Write(this.buffer.Slice(this.bufferOffset), $"{frameRate} FPS\0");

			this.ticks = 0;
		}

		private static int Write(scoped System.Span<byte> buffer,
								 [InterpolatedStringHandlerArgument(nameof(buffer))]
								 CustomInterpolatedStringHandler handler)
		{
			return handler.Position;
		}

		[InterpolatedStringHandler]
		[StructLayout(LayoutKind.Sequential)]
		private ref struct CustomInterpolatedStringHandler
		{
			public int Position { get; private set; }

			private readonly System.Span<byte> buffer;

			public CustomInterpolatedStringHandler(int literalCount, int formattedCount, System.Span<byte> buffer)
			{
				this.buffer = buffer;
			}

			public void AppendLiteral(string value)
			{
				var slice = this.buffer.Slice(this.Position);

				var done = Encoding.UTF8.TryGetBytes(value, slice, out var written);

				Debug.Assert(done);

				this.Position += written;
			}

			public void AppendFormatted<T>(T value, System.ReadOnlySpan<char> format = default)
				where T : System.IUtf8SpanFormattable
			{
				var slice = this.buffer.Slice(this.Position);

				var done = value.TryFormat(slice, out var written, format, null);

				Debug.Assert(done);

				this.Position += written;
			}
		}
	}
}
