using System.Runtime.CompilerServices;

namespace Engine.Native
{
	/// <summary>
	/// Represents a pointer to an unkown unmanaged type.
	/// </summary>
	public readonly unsafe struct VoidPointer
	{
		private readonly void* value;

		/// <summary>
		/// Gets a value indicating whether the pointer is valid.
		/// </summary>
		public bool IsValid =>
			this.value != null;

		/// <summary>
		/// Represents a pointer to an unmanaged type.
		/// </summary>
		/// <param name="value">Pointer to the value.</param>
		public VoidPointer(void* value) =>
			this.value = value;

		/// <summary>
		/// Converts the unmanaged pointer to a pointer of type <typeparamref name="TValue"/>.
		/// </summary>
		/// <typeparam name="TValue">The type to convert the pointer to.</typeparam>
		/// <returns>A pointer of type <typeparamref name="TValue"/> pointing to the same address as this VoidPointer.</returns>
		public TValue* As<TValue>()
			where TValue : unmanaged =>
			(TValue*)this.value;

		/// <summary>
		/// Implicitly converts an unmanaged pointer to a VoidPointer.
		/// </summary>
		/// <param name="value">The unmanaged pointer.</param>
		/// <returns>A new instance of VoidPointer initialized with the provided pointer value.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator VoidPointer(void* value) =>
			new(value);

		/// <summary>
		/// Implicitly converts a VoidPointer to an unmanaged pointer.
		/// </summary>
		/// <param name="ptr">The VoidPointer instance to convert.</param>
		/// <returns>The unmanaged pointer value contained in the VoidPointer.</returns>
		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static implicit operator void*(VoidPointer ptr) =>
			ptr.value;
	}
}
