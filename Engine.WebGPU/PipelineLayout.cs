using JetBrains.Annotations;

namespace wgpu
{
	/// <summary>
	/// Represents a pipeline layout used in the WebGPU API.
	/// This structure is part of the rendering pipeline and defines the layout for resources such as buffers and textures.
	/// </summary>
	[MustDisposeResource]
	public readonly struct PipelineLayout : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Releases all resources used by this instance.
		/// </summary>
		public void Dispose() =>
			PipelineLayoutNative.Release(this);
	}
}
