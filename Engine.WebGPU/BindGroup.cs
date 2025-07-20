using JetBrains.Annotations;

namespace wgpu
{
	/// <summary>
	/// Represents a bind group used for setting resources in the rendering pipeline.
	/// </summary>
	[MustDisposeResource]
	public readonly struct BindGroup : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Releases the resources used by this <see cref="BindGroup"/>.
		/// </summary>
		public void Dispose() =>
			BindGroupNative.Release(this);
	}
}
