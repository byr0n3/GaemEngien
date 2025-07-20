using JetBrains.Annotations;

namespace wgpu
{
	/// <summary>
	/// Represents a render pipeline used for rendering commands.
	/// </summary>
	[MustDisposeResource]
	public readonly struct RenderPipeline : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Releases the resources used by this instance.
		/// </summary>
		public void Dispose() =>
			RenderPipelineNative.Release(this);
	}
}
