using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents a view of a string as a sequence of bytes.
	/// This struct provides methods to convert the byte sequence into a readable string using UTF-8 encoding.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[DebuggerTypeProxy(typeof(DebugView))]
	public readonly unsafe struct StringView
	{
		private readonly byte* ptr;
		private readonly nuint length;

		/// <summary>
		/// Gets a read-only span of bytes representing the underlying data.
		/// </summary>
		public System.ReadOnlySpan<byte> ReadOnlySpan =>
			new(this.ptr, (int)this.length);

		/// <summary>
		/// Represents a view of a string as a sequence of bytes.
		/// This struct provides methods to convert the byte sequence into a readable string using UTF-8 encoding.
		/// </summary>
		/// <param name="ptr">Pointer to the string data.</param>
		/// <param name="length">Length of the string data.</param>
		public StringView(byte* ptr, nuint length)
		{
			this.ptr = ptr;
			this.length = length;
		}

		/// <summary>
		/// Converts the byte sequence represented by this instance into a readable string using UTF-8 encoding.
		/// </summary>
		/// <returns>A string representation of the byte sequence.</returns>
		public override string ToString() =>
			Encoding.UTF8.GetString(this.ReadOnlySpan);

		/// <summary>
		/// Converts a <see cref="System.ReadOnlySpan{T}"/> to a <see cref="StringView"/>.
		/// This operator allows implicit conversion from a byte span to a string view.
		/// </summary>
		/// <param name="span">The byte span to convert.</param>
		/// <returns>A new instance of <see cref="StringView"/> representing the string view of the byte sequence.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator StringView(System.ReadOnlySpan<byte> span)
		{
			fixed (byte* src = &MemoryMarshal.GetReference(span))
			{
				return new StringView(src, (nuint)span.Length);
			}
		}

		/// <summary>
		/// Converts a StringView instance to a <see cref="System.ReadOnlySpan{T}"/>.
		/// This operator allows implicit conversion from a StringView to a byte span.
		/// </summary>
		/// <param name="value">The StringView instance to convert.</param>
		/// <returns><see cref="System.ReadOnlySpan{T}"/> representing the byte sequence of the string view.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator System.ReadOnlySpan<byte>(StringView value) =>
			value.ReadOnlySpan;

		private sealed class DebugView
		{
			public readonly string Value;

			public DebugView(StringView value)
			{
				this.Value = value.ToString();
			}
		}
	}
}
