using JetBrains.Annotations;

namespace wgpu
{
	/// <summary>
	/// Represents a set of queries that can be used to gather information about the performance of rendering operations.
	/// </summary>
	[MustDisposeResource]
	public readonly struct QuerySet : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Releases all resources used by the QuerySet.
		/// </summary>
		public void Dispose() =>
			QuerySetNative.Release(this);
	}
}
