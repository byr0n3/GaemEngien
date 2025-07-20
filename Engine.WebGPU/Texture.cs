using JetBrains.Annotations;
using wgpu.Enums;

namespace wgpu
{
	/// <summary>
	/// Represents a texture resource in the WebGPU API.
	/// This structure provides access to the format of the texture and allows creating views for it.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Texture : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Gets the format of the texture.
		/// </summary>
		public TextureFormat Format =>
			TextureNative.GetFormat(this);

		/// <summary>
		/// Creates a new view for the current texture.
		/// </summary>
		/// <param name="descriptor">The descriptor defining the properties of the view to be created.</param>
		/// <returns>A new instance of <see cref="TextureView"/> representing the created view.</returns>
		[MustDisposeResource]
		public TextureView CreateView(in TextureViewDescriptor descriptor) =>
			TextureNative.CreateView(this, descriptor);

		/// <summary>
		/// Releases the resources held by this texture.
		/// </summary>
		public void Dispose()
		{
			TextureNative.Destroy(this);
			TextureNative.Release(this);
		}
	}
}
