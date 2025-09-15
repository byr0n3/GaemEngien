using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Engine.Shared;
using wgpu.Enums;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents a base structure for chaining other structures.
	/// This struct is used to create linked lists of various descriptor and state structures in the wgpu library.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct ChainedStruct
	{
		/// <summary>
		/// Gets or initializes the next structure in a chain of linked structures.
		/// </summary>
		public Pointer<ChainedStruct> Next { get; init; }

		/// <summary>
		/// Specifies the type of structure that follows in a chain of linked structures.
		/// </summary>
		public required SType SType { get; init; }

		/// <inheritdoc cref="ChainedStruct"/>
		/// <param name="sType">The type of the struct that's chained.</param>
		[SetsRequiredMembers]
		public ChainedStruct(SType sType) : this(default, sType)
		{
		}

		/// <inheritdoc cref="ChainedStruct"/>
		/// <param name="next">Pointer to the struct that's chained.</param>
		/// <param name="sType">The type of the struct that's chained.</param>
		[SetsRequiredMembers]
		public ChainedStruct(Pointer<ChainedStruct> next, SType sType)
		{
			this.Next = next;
			this.SType = sType;
		}
	}
}
