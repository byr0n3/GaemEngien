using JetBrains.Annotations;

namespace wgpu
{
	/// <summary>
	/// Represents a sampler object used in graphics processing.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Sampler : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Releases all resources used by the current instance of the Sampler.
		/// </summary>
		public void Dispose() =>
			SamplerNative.Release(this);
	}
}
