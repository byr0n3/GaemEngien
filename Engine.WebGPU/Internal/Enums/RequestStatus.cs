namespace wgpu.Internal.Enums
{
	/// <summary>
	/// Represents the status of a request in the WebGPU API.
	/// </summary>
	internal enum RequestStatus
	{
		Success = 1,
		InstanceDropped,
		Error,
		Unknown,
	}
}
