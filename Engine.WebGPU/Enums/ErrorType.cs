namespace wgpu.Enums
{
	/// <summary>
	/// Represents various types of errors that can occur within the wgpu (WebGPU) API.
	/// </summary>
	public enum ErrorType
	{
		NoError = 1,
		Validation,
		OutOfMemory,
		Internal,
		Unknown,
	}
}
