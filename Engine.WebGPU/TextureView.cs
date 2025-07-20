using JetBrains.Annotations;

namespace wgpu
{
	/// <summary>
	/// Represents a view of a texture resource in the WebGPU API.
	/// This structure allows accessing and manipulating specific portions or aspects of a texture.
	/// </summary>
	[MustDisposeResource]
	public readonly struct TextureView : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Releases the resources held by this texture view.
		/// </summary>
		public void Dispose() =>
			TextureViewNative.Release(this);
	}
}
