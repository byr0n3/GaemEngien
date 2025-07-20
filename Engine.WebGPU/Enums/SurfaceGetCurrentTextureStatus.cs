namespace wgpu.Enums
{
	/// <summary>
	/// Represents the status of obtaining the current surface texture.
	/// </summary>
	public enum SurfaceGetCurrentTextureStatus
	{
		/// <summary>
		/// Yay! Everything is good and we can render this frame.
		/// </summary>
		SuccessOptimal = 1,

		/// <summary>
		/// Still OK - the <see cref="Surface"/> can present the frame, but suboptimally.
		/// The <see cref="Surface"/> may need reconfiguration.
		/// </summary>
		SuccessSuboptimal,

		/// <summary>
		/// Some operation timed out while trying to acquire the frame.
		/// </summary>
		Timeout,

		/// <summary>
		/// The <see cref="Surface"/> is too different to be used, compared to when it was originally created.
		/// </summary>
		Outdated,

		/// <summary>
		/// The connection to whatever owns the <see cref="Surface"/> was lost.
		/// </summary>
		Lost,

		/// <summary>
		/// The system ran out of memory.
		/// </summary>
		OutOfMemory,

		/// <summary>
		/// The <see cref="Device"/> configured on the <see cref="Surface"/> was lost.
		/// </summary>
		DeviceLost,

		/// <summary>
		/// The <see cref="Surface"/> is not configured, or there was an OutStructChainError.
		/// </summary>
		Error,
	}
}
