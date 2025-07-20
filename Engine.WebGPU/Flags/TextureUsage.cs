namespace wgpu.Flags
{
	/// <summary>
	/// Represents various usage types for textures.
	/// </summary>
	[System.Flags]
	public enum TextureUsage : ulong
	{
		/// <summary>
		/// Represents that no usage is specified for the texture.
		/// </summary>
		None = 0,

		/// <summary>
		/// Represents that the texture can be used as a source for copy operations.
		/// </summary>
		CopySrc = 1 << 0,

		/// <summary>
		/// Represents that the texture can be used as a destination for copy operations.
		/// </summary>
		CopyDst = 1 << 1,

		/// <summary>
		/// Represents that the texture is used for binding resources.
		/// </summary>
		TextureBinding = 1 << 2,

		/// <summary>
		/// Represents that the texture is used as a storage binding.
		/// </summary>
		StorageBinding = 1 << 3,

		/// <summary>
		/// Represents that the texture is used as a render attachment.
		/// </summary>
		RenderAttachment = 1 << 4,
	}
}
