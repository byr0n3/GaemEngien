using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Engine.Shared
{
	/// <summary>
	/// Represents a rentable array of unmanaged types using ArrayPool for efficient memory management.
	/// </summary>
	/// <typeparam name="TType">The type of elements in the array, which must be an unmanaged type.</typeparam>
	[MustDisposeResource]
	public readonly struct RentedArray<TType> : System.IDisposable
		where TType : unmanaged
	{
		private readonly TType[]? buffer;

		/// <summary>
		/// Gets a value indicating whether this instance is valid and has a rented buffer.
		/// </summary>
		public bool IsValid
		{
			[MemberNotNullWhen(true, nameof(this.buffer))]
			get => this.buffer is not null;
		}

		/// <summary>
		/// Gets the rented array buffer.
		/// </summary>
		/// <remarks>
		/// The buffer is only valid if the instance is currently in use (i.e., not disposed).
		/// </remarks>
		public TType[] Value
		{
			get
			{
				Debug.Assert(this.IsValid);

				return this.buffer;
			}
		}

		/// <inheritdoc cref="RentedArray{TType}"/>
		[System.Obsolete("Add length parameter", true)]
		public RentedArray()
		{
		}

		/// <inheritdoc cref="RentedArray{TType}"/>
		/// <param name="minLength">The minimum length of the array.</param>
		[MustDisposeResource]
		public RentedArray(int minLength) =>
			this.buffer = ArrayPool<TType>.Shared.Rent(minLength);

		/// <summary>
		/// Creates a read-only span from the rented array starting at a specified index and with an optional length.
		/// </summary>
		/// <param name="start">The zero-based starting index of the slice.</param>
		/// <param name="length">
		/// The number of elements in the slice.
		/// If set to 0, the slice will extend to the end of the array from the start index.
		/// </param>
		/// <returns>A read-only span representing a contiguous segment of the rented array.</returns>
		public System.ReadOnlySpan<TType> Slice(int start = 0, int length = 0)
		{
			if (length <= 0)
			{
				length = this.Value.Length - start;
			}

			return new System.ReadOnlySpan<TType>(this.Value, start, length);
		}

		/// <summary>
		/// Releases the unmanaged memory of the rented array back to the pool.
		/// </summary>
		public void Dispose()
		{
			Debug.Assert(this.IsValid);

			ArrayPool<TType>.Shared.Return(this.buffer, true);
		}

		/// <summary>
		/// Implicitly converts a <see cref="RentedArray{TType}"/> to an array of <typeparamref name="TType"/>.
		/// </summary>
		/// <param name="value">The rented array to convert.</param>
		/// <returns>An array containing the elements from the rented array.</returns>
		public static implicit operator TType[](RentedArray<TType> value)
		{
			Debug.Assert(value.IsValid);

			return value.buffer;
		}
	}
}
