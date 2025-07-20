namespace wgpu.Internal.Enums
{
	/// <summary>
	/// Represents the status of an asynchronous map operation.
	/// </summary>
	internal enum MapAsyncStatus
	{
		Success = 1,
		InstanceDropped,
		Error,
		Aborted,
		Unknown,
	}
}
