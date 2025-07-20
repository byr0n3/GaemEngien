using System.Runtime.InteropServices;
using Engine.Native;
using wgpu.Enums;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents the options used to request an adapter from a WGPU instance.
	/// This struct is used to configure various parameters that influence the creation of an adapter.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct RequestAdapterOptions
	{
		/// <summary>
		/// Gets the next structure in a chain of structures.
		/// This property allows for chaining additional structures that modify or extend the options used to request an adapter from a WGPU instance.
		/// </summary>
		public Pointer<ChainedStruct> NextInChain { get; init; }

		/// <summary>
		/// Gets or initializes the feature level for the adapter.
		/// This property specifies the minimum set of features required by the application, influencing the creation of an adapter with the appropriate capabilities.
		/// </summary>
		public FeatureLevel FeatureLevel { get; init; }

		/// <summary>
		/// Gets or sets the power preference for the requested adapter.
		/// This property indicates whether the application prefers a low-power or high-performance GPU when requesting an adapter from a WGPU instance.
		/// </summary>
		public PowerPreference PowerPreference { get; init; }

		/// <summary>
		/// Specifies whether to force the use of a fallback adapter.
		/// A fallback adapter is used when the preferred or default adapter cannot be created for some reason.
		/// Setting this property to true will prioritize using the fallback adapter over other available adapters.
		/// </summary>
		public NativeBool ForceFallbackAdapter { get; init; }

		/// <summary>
		/// Specifies the graphics backend type to be used by the WGPU instance.
		/// This property determines which graphics API will be utilized for rendering, such as Direct3D, Metal, Vulkan, or OpenGL/ES.
		/// </summary>
		public BackendType BackendType { get; init; }

		/// <summary>
		/// Gets or initializes the surface to be used with the requested adapter.
		/// This property specifies the target surface for rendering, which is an essential component when creating a graphics adapter in WGPU.
		/// </summary>
		public Surface CompatibleSurface { get; init; }
	}
}
