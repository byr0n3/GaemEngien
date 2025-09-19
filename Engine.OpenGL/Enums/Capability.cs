namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Represents OpenGL capabilities that can be enabled or disabled.
	/// </summary>
	public enum Capability
	{
		/// <summary>
		/// Represents no specific OpenGL capability.
		/// </summary>
		None,

		/// <summary>
		/// Represents the depth test capability in OpenGL.
		/// </summary>
		DepthTest = 0x0B71,

		/// <summary>
		/// Enables or disables blending of pixel colors.
		/// </summary>
		Blend = 0x0BE2,
	}
}
