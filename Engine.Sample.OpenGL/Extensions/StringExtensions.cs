using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Engine.Sample.OpenGL.Extensions
{
	internal static class StringExtensions
	{
		extension(string)
		{
			public static int Create(System.Span<byte> buffer,
									 [InterpolatedStringHandlerArgument(nameof(buffer))]
									 InterpolatedByteStringHandler handler) =>
				handler.Position;
		}

		[InterpolatedStringHandler]
		[StructLayout(LayoutKind.Sequential)]
		public ref struct InterpolatedByteStringHandler
		{
			public int Position { get; private set; }

			private readonly System.Span<byte> buffer;

			public InterpolatedByteStringHandler(int literalCount, int formattedCount, System.Span<byte> buffer)
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
