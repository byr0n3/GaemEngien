namespace wgpu.Enums
{
	/// <summary>
	/// Represents the operations that can be performed when storing data.
	/// </summary>
	public enum StoreOperation
	{
		/// <summary>
		/// Represents an undefined store operation. This value is used when no specific store operation has been defined.
		/// </summary>
		Undefined = 0,

		/// <summary>
		/// Indicates that the store operation should save the data to a storage buffer. This is typically used when you want to retain the results of a computation for later use or transfer.
		/// </summary>
		Store,

		/// <summary>
		/// Represents a store operation where the data is discarded. This value indicates that no data should be written to storage.
		/// </summary>
		Discard,
	}
}
