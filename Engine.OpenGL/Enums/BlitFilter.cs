namespace Engine.OpenGL.Enums
{
	/// <summary>
	/// Defines the filtering method used when performing a blit operation in OpenGL.
	/// The filter determines how pixel values are sampled during the copy or scaling process.
	/// </summary>
	public enum BlitFilter
	{
		/// <summary>
		/// Indicates that no filtering is applied during a blit operation.
		/// </summary>
		None = 0,

		/// <summary>
		/// Uses nearest-neighbor sampling to determine pixel values during a blit operation.
		/// </summary>
		Nearest = 0x2600,

		/// <summary>
		/// Uses linear sampling to determine pixel values during a blit operation.
		/// </summary>
		Linear = 0x2601,
	}
}
