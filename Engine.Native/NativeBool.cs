using System.Runtime.CompilerServices;

namespace Engine.Native
{
	/// <summary>
	/// Represents a boolean value in native format, enabling efficient interoperation with native APIs.
	/// </summary>
	public readonly struct NativeBool : System.IEquatable<NativeBool>
	{
		/// <summary>
		/// Represents the constant value of true for the NativeBool structure.
		/// </summary>
		public static readonly NativeBool True = true;

		/// <summary>
		/// Represents the constant value of false for the NativeBool structure.
		/// </summary>
		public static readonly NativeBool False = false;

		private readonly int value;

		/// <summary>
		/// Represents a boolean value in native format, enabling efficient interoperation with native APIs.
		/// </summary>
		public NativeBool(bool value) =>
			this.value = Unsafe.BitCast<bool, byte>(value);

		/// <summary>
		/// Gets the managed representation of this native boolean.
		/// </summary>
		public bool Managed =>
			Unsafe.BitCast<byte, bool>((byte)this.value);

		/// <summary>
		/// Determines whether the specified NativeBool object is equal to this instance.
		/// </summary>
		/// <param name="other">The other NativeBool object to compare with this instance.</param>
		/// <returns>true if the specified NativeBool object is equal to this instance; otherwise, false.</returns>
		public bool Equals(NativeBool other) =>
			this.value == other.value;

		/// <summary>
		/// Determines whether the specified object is equal to this instance.
		/// </summary>
		/// <param name="object">The object to compare with this instance.</param>
		/// <returns>true if the specified object is equal to this instance; otherwise, false.</returns>
		public override bool Equals(object? @object) =>
			(@object is NativeBool other) && this.Equals(other);

		/// <summary>
		/// Serves as the hash function for this NativeBool instance.
		/// </summary>
		/// <return>An integer hash code that represents this NativeBool.</return>
		public override int GetHashCode() =>
			this.value.GetHashCode();

		/// <summary>
		/// Determines whether two specified instances of NativeBool are equal.
		/// </summary>
		/// <param name="left">The first instance to compare.</param>
		/// <param name="right">The second instance to compare.</param>
		/// <returns>true if the instances are equal; otherwise, false.</returns>
		public static bool operator ==(NativeBool left, NativeBool right) =>
			left.Equals(right);

		/// <summary>
		/// Determines whether two specified instances of NativeBool are not equal.
		/// </summary>
		/// <param name="left">The first instance to compare.</param>
		/// <param name="right">The second instance to compare.</param>
		/// <returns>true if the instances are not equal; otherwise, false.</returns>
		public static bool operator !=(NativeBool left, NativeBool right) =>
			!left.Equals(right);

		/// <summary>
		/// Defines an explicit conversion from a NativeBool instance to a System.Boolean.
		/// This enables the use of a NativeBool object where a boolean is expected, facilitating seamless interoperation with native APIs and managed code.
		/// </summary>
		/// <param name="value">The NativeBool value to be converted.</param>
		/// <returns>A bool representation of the provided NativeBool instance.</returns>
		public static implicit operator bool(NativeBool value) =>
			value.Managed;

		/// <summary>
		/// Converts a boolean value to a NativeBool instance.
		/// </summary>
		/// <param name="value">The boolean value to convert.</param>
		/// <returns>A new NativeBool instance representing the converted boolean value.</returns>
		public static implicit operator NativeBool(bool value) =>
			new(value);

		/// <summary>
		/// Converts a NativeBool instance to a boolean value, representing the managed equivalent.
		/// </summary>
		/// <param name="value">The NativeBool instance to convert.</param>
		/// <returns>The managed boolean representation of the NativeBool instance.</returns>
		public static bool operator true(NativeBool value) =>
			value.value > 0;

		/// <summary>
		/// Determines whether the specified instance of NativeBool is false.
		/// </summary>
		/// <param name="value">The instance to evaluate.</param>
		/// <returns>true if the instance is false; otherwise, false.</returns>
		public static bool operator false(NativeBool value) =>
			value.value == 0;
	}
}
