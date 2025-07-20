using JetBrains.Annotations;

namespace wgpu.Enums
{
	/// <summary>
	/// Specifies various types used within the wgpu library.
	/// </summary>
	[PublicAPI]
	public enum SType
	{
		/// <summary>
		/// Specifies a shader source type using SPIR-V.
		/// </summary>
		ShaderSourceSPIRV = 1,

		/// <summary>
		/// Specifies a shader source type using WGSL (WebGPU Shading Language).
		/// </summary>
		ShaderSourceWGSL,

		/// <summary>
		/// Specifies the maximum number of draw commands that can be executed within a render pass.
		/// </summary>
		RenderPassMaxDrawCount,

		/// <summary>
		/// Specifies a surface source type using Metal Layer.
		/// </summary>
		SurfaceSourceMetalLayer,

		/// <summary>
		/// Specifies a surface source type using a Windows HWND handle.
		/// </summary>
		SurfaceSourceWindowsHWND,

		/// <summary>
		/// Specifies a surface source type using an Xlib window.
		/// </summary>
		SurfaceSourceXlibWindow,

		/// <summary>
		/// Specifies a surface source type using Wayland native window.
		/// </summary>
		SurfaceSourceWaylandSurface,

		/// <summary>
		/// Specifies a surface source type using an Android native window.
		/// </summary>
		SurfaceSourceAndroidNativeWindow,

		/// <summary>
		/// Specifies a surface source type using XCB window.
		/// </summary>
		SurfaceSourceXCBWindow,
	}
}
