using JetBrains.Annotations;

namespace wgpu
{
	/// <summary>
	/// Represents a layout for a bind group, which defines the structure of resources that can be bound to it.
	/// </summary>
	[MustDisposeResource]
	public readonly struct BindGroupLayout : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Releases the unmanaged resources used by this instance.
		/// </summary>
		public void Dispose() =>
			BindGroupLayoutNative.Release(this);
	}
}
