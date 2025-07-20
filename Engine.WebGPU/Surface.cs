using System.Diagnostics;
using JetBrains.Annotations;
using wgpu.Enums;

namespace wgpu
{
	/// <summary>
	/// Represents a surface that can be used for rendering. This struct encapsulates the native surface handle and provides methods to interact with it.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Surface : System.IDisposable
	{
		private readonly nint handle;

		/// <summary>
		/// Gets a value indicating whether this surface is valid.
		/// </summary>
		public bool IsValid =>
			this.handle != default;

		/// <summary>
		/// Gets the current texture associated with this surface.
		/// </summary>
		public SurfaceTexture CurrentTexture
		{
			get
			{
				SurfaceTexture texture = default;

				SurfaceNative.GetCurrentTexture(this, texture);

				return texture;
			}
		}

		/// <summary>
		/// Retrieves the capabilities of a surface for a given adapter.
		/// </summary>
		/// <param name="adapter">The adapter to get the capabilities for.</param>
		/// <returns>A <see cref="SurfaceCapabilities"/> object containing the capabilities of the surface.</returns>
		[MustDisposeResource]
		public SurfaceCapabilities GetCapabilities(Adapter adapter)
		{
			SurfaceCapabilities capabilities = default;

			var status = SurfaceNative.GetCapabilities(this, adapter, capabilities);

			Debug.Assert(status == Status.Success);

			return capabilities;
		}

		/// <summary>
		/// Configures the surface with a given configuration.
		/// </summary>
		/// <param name="configuration">The configuration to apply to the surface.</param>
		public void Configure(in SurfaceConfiguration configuration) =>
			SurfaceNative.Configure(this, configuration);

		/// <summary>
		/// Presents the contents of the surface to the display.
		/// </summary>
		public void Present() =>
			SurfaceNative.Present(this);

		/// <summary>
		/// Releases the resources used by this instance.
		/// </summary>
		public void Dispose() =>
			SurfaceNative.Release(this);
	}
}
