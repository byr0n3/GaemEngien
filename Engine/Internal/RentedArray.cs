using System.Buffers;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using JetBrains.Annotations;

namespace Engine.Internal
{
	[MustDisposeResource]
	internal readonly struct RentedArray<TType> : System.IDisposable
		where TType : unmanaged
	{
		private readonly TType[]? buffer;

		public bool IsValid
		{
			[MemberNotNullWhen(true, nameof(this.buffer))]
			get => this.buffer is not null;
		}

		public TType[] Value
		{
			get
			{
				Debug.Assert(this.IsValid);

				return this.buffer;
			}
		}

		[System.Obsolete("Add length parameter", true)]
		public RentedArray()
		{
		}

		[MustDisposeResource]
		public RentedArray(int minLength) =>
			this.buffer = ArrayPool<TType>.Shared.Rent(minLength);

		public void Dispose()
		{
			Debug.Assert(this.IsValid);

			ArrayPool<TType>.Shared.Return(this.buffer);
		}

		public static implicit operator TType[](RentedArray<TType> value)
		{
			Debug.Assert(value.IsValid);

			return value.buffer;
		}
	}
}
