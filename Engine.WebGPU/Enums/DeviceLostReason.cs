namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the reason why a GPU device was lost.
	/// </summary>
	public enum DeviceLostReason
	{
		Unknown = 1,
		Destroyed,
		InstanceDropped,
		FailedCreation,
	}
}
