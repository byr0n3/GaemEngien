namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Represents the possible status values returned by <see cref="Framebuffer.CheckStatus"/>.
	/// </summary>
	public enum FramebufferStatus
	{
		/// <summary>
		/// None.
		/// </summary>
		None = 0,

		/// <summary>
		/// Indicates that the framebuffer status is undefined,
		/// meaning the framebuffer is not properly bound or has been deleted, and its current state cannot be determined.
		/// </summary>
		Undefined = 0x8219,

		/// <summary>
		/// Indicates that the framebuffer is complete and ready for rendering.
		/// </summary>
		Complete = 0x8CD5,

		/// <summary>
		/// Indicates that the framebuffer is incomplete because one or more attachments are missing or otherwise incomplete.
		/// </summary>
		IncompleteAttachment = 0x8CD6,

		/// <summary>
		/// The framebuffer is incomplete because it has no attachment point configured.
		/// </summary>
		IncompleteMissingAttachment = 0x8CD7,

		/// <summary>
		/// Indicates that the framebuffer is incomplete because a specified draw buffer is invalid or missing.
		/// </summary>
		IncompleteDrawBuffer = 0x8CDB,

		/// <summary>
		/// Indicates that the framebuffer’s read buffer attachment is incomplete,
		/// meaning it does not have a valid color buffer for read operations.
		/// </summary>
		IncompleteReadBuffer = 0x8CDC,

		/// <summary>
		/// Indicates that the framebuffer status is unsupported.
		/// </summary>
		Unsupported = 0x8CDD,

		/// <summary>
		/// Indicates that the framebuffer is incomplete because its multisample attachments are not compatible.
		/// This may occur when the sample counts of attached images differ, when an attachment has zero samples, or when a multisample attachment is missing.
		/// </summary>
		IncompleteMultisample = 0x8D56,

		/// <summary>
		/// Indicates that the framebuffer is incomplete because one or more of its attachments are layered, but the
		/// number of layers does not match among the attached images.
		/// </summary>
		IncompleteLayerTargets = 0x8DA8,
	}
}
