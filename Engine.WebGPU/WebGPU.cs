using JetBrains.Annotations;
using wgpu.Internal;

namespace wgpu
{
	/// <summary>
	/// Provides access to the WebGPU API.
	/// </summary>
	[PublicAPI]
	public static class WebGPU
	{
		/// <summary>
		/// Gets the version of WebGPU.
		/// </summary>
		public static uint Version =>
			libwgpu.GetVersion();
	}
}
