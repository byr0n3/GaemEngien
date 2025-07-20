namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the type of backend used for rendering.
	/// </summary>
	public enum BackendType
	{
		Undefined = 0,
		Null,
		WebGPU,
		D3D11,
		D3D12,
		Metal,
		Vulkan,
		OpenGL,
		OpenGLES,
	}
}
