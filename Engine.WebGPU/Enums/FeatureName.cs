namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the names of features that can be required for a device.
	/// </summary>
	public enum FeatureName
	{
		Undefined = 0,
		DepthClipControl,
		Depth32FloatStencil8,
		TimestampQuery,
		TextureCompressionBC,
		TextureCompressionBCSliced3D,
		TextureCompressionETC2,
		TextureCompressionASTC,
		TextureCompressionASTCSliced3D,
		IndirectFirstInstance,
		ShaderF16,
		RG11B10UfloatRenderable,
		BGRA8UnormStorage,
		Float32Filterable,
		Float32Blendable,
		ClipDistances,
		DualSourceBlending,
	}
}
