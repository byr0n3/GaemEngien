using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Engine.Native;

namespace glfw
{
	/// <summary>
	/// Represents a C level string.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[DebuggerTypeProxy(typeof(DebugView))]
	public readonly unsafe partial struct NativeString
	{
		private readonly byte* ptr;

		/// <summary>
		/// Gets the length of the C level string in bytes.
		/// </summary>
		/// <returns>The number of bytes in the C level string, or 0 if the pointer is null.</returns>
		public int Length =>
			this.ptr != null ? (int)NativeString.strlen(this.ptr) : default;

		/// <summary>
		/// Gets a read-only span of bytes representing the C level string.
		/// </summary>
		/// <returns>A <see cref="System.ReadOnlySpan{T}"/> that contains the bytes of the C level string.</returns>
		public System.ReadOnlySpan<byte> ReadOnlySpan =>
			new(this.ptr, this.Length);

		/// <summary>
		/// Represents a C level string.
		/// </summary>
		/// <param name="ptr">Pointer to the location of the string's bytes in memory.</param>
		public NativeString(Pointer<byte> ptr) =>
			this.ptr = ptr;

		/// <summary>
		/// Creates a managed, UTF-8 string from the underlying C string.
		/// </summary>
		/// <returns>A new <see cref="string"/> containing the text encoded in UTF-8.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override string ToString() =>
			Encoding.UTF8.GetString(this.ReadOnlySpan);

		/// <summary>
		/// Converts a <see cref="System.ReadOnlySpan{T}"/> to a <see cref="NativeString"/>.
		/// </summary>
		/// <param name="span">The span containing the byte data.</param>
		/// <returns>A new <see cref="NativeString"/> representing the same data as the input.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator NativeString(System.ReadOnlySpan<byte> span)
		{
			fixed (byte* src = &MemoryMarshal.GetReference(span))
			{
				return new NativeString(src);
			}
		}

		/// <summary>
		/// Converts a <see cref="NativeString"/> to a <see cref="System.ReadOnlySpan{T}"/>.
		/// </summary>
		/// <param name="value">The <see cref="NativeString"/> instance to convert.</param>
		/// <returns>A new <see cref="System.ReadOnlySpan{T}"/> representing the same data as the input.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator System.ReadOnlySpan<byte>(NativeString value) =>
			value.ReadOnlySpan;

		[DllImport("libc")]
		[System.Diagnostics.Contracts.Pure]
		private static extern nuint strlen(byte* ptr);

		private sealed class DebugView
		{
			public readonly string Value;

			public DebugView(NativeString value)
			{
				this.Value = value.ToString();
			}
		}
	}
}
