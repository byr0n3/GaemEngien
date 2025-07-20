using System.Runtime.CompilerServices;

namespace Engine.Native
{
	/// <summary>
	/// Represents a pointer to an unmanaged type.
	/// </summary>
	/// <typeparam name="TValue">The unmanaged type being pointed to.</typeparam>
	public readonly unsafe struct Pointer<TValue>
		where TValue : unmanaged
	{
		private readonly TValue* value;

		/// <summary>
		/// Gets a value indicating whether the pointer is valid (i.e., not null).
		/// </summary>
		/// <value><c>true</c> if the pointer is valid; otherwise, <c>false</c>.</value>
		public bool IsValid =>
			this.value != null;

		// @todo Handle `IsValid = false`
		/// <summary>
		/// Gets a reference to the value being pointed to.
		/// </summary>
		/// <value>The referenced value.</value>
		public ref TValue Value =>
			ref *this.value;

		/// <summary>
		/// Gets the raw pointer value.
		/// </summary>
		/// <value>The pointer.</value>
		public TValue* Ref =>
			this.value;

		/// <summary>
		/// Represents a pointer to an unmanaged type.
		/// </summary>
		/// <param name="value">Pointer to the value.</param>
		public Pointer(TValue* value) =>
			this.value = value;

		/// <summary>
		/// Implicitly converts a pointer to an unmanaged type to a <see cref="Pointer{TValue}"/>.
		/// </summary>
		/// <param name="value">Pointer to the value.</param>
		/// <returns>A new instance of <see cref="Pointer{TValue}"/> pointing to the specified value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Pointer<TValue>(TValue* value) =>
			new(value);

		/// <summary>
		/// Implicitly converts a value of the unmanaged type to a <see cref="Pointer{TValue}"/>.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <returns>A new instance of <see cref="Pointer{TValue}"/> pointing to the specified value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Pointer<TValue>(in TValue value)
		{
			fixed (TValue* ptr = &value)
			{
				return new Pointer<TValue>(ptr);
			}
		}

		/// <summary>
		/// Implicitly converts a scoped <see cref="System.ReadOnlySpan{TValue}"/> to a <see cref="Pointer{TValue}"/>.
		/// </summary>
		/// <param name="value">The span of values.</param>
		/// <returns>A new instance of <see cref="Pointer{TValue}"/> pointing to the first element of the span.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator Pointer<TValue>(scoped System.ReadOnlySpan<TValue> value)
		{
			fixed (TValue* ptr = value)
			{
				return new Pointer<TValue>(ptr);
			}
		}

		/// <summary>
		/// Implicitly converts a <see cref="Pointer{TValue}"/> to its underlying value type.
		/// </summary>
		/// <param name="ptr">The pointer to convert.</param>
		/// <returns>The underlying value of the specified <see cref="Pointer{TValue}"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator TValue(Pointer<TValue> ptr) =>
			ptr.IsValid ? ptr.Value : default;

		/// <summary>
		/// Implicitly converts a <see cref="Pointer{TValue}"/> to its underlying pointer type.
		/// </summary>
		/// <param name="ptr">The pointer to convert.</param>
		/// <returns>The underlying pointer of the specified <see cref="Pointer{TValue}"/>.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator TValue*(Pointer<TValue> ptr) =>
			ptr.value;
	}
}
