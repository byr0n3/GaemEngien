namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the feature level required by a WGPU adapter.
	/// </summary>
	public enum FeatureLevel
	{
		/// <summary>
		/// 'Compatibility' profile which can be supported on OpenGL ES 3.1.
		/// </summary>
		Compatibility = 1,

		/// <summary>
		/// 'Core' profile which can be supported on Vulkan/Metal/D3D12.
		/// </summary>
		Core = 2,
	}
}
