namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the method of presenting rendered images to a surface.
	/// </summary>
	public enum PresentMode
	{
		/// <summary>
		/// Fallback to the default presentation mode.
		/// </summary>
		Undefined = 0,

		/// <summary>
		/// The presentation of the image to the user waits for the next vertical blanking period to update in a first-in, first-out manner.
		/// Tearing cannot be observed and frame-loop will be limited to the display's refresh rate.
		/// This is the only mode that's always available.
		/// </summary>
		Fifo,

		/// <summary>
		/// The presentation of the image to the user tries to wait for the next vertical blanking period but may decide to not wait if a frame is presented late.
		/// Tearing can sometimes be observed but late-frame don't produce a full-frame stutter in the presentation.
		/// This is still a first-in, first-out mechanism so a frame-loop will be limited to the display's refresh rate.
		/// </summary>
		FifoRelaxed,

		/// <summary>
		/// The presentation of the image to the user is updated immediately without waiting for a vertical blank.
		/// Tearing can be observed but latency is minimized.
		/// </summary>
		Immediate,

		/// <summary>
		/// The presentation of the image to the user waits for the next vertical blanking period to update to the latest provided image.
		/// Tearing cannot be observed and a frame-loop is not limited to the display's refresh rate.
		/// </summary>
		Mailbox,
	}
}
