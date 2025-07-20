namespace wgpu.Enums
{
	/// <summary>
	/// Specifies the access type for a storage texture binding.
	/// </summary>
	public enum StorageTextureAccess
	{
		/// <summary>
		/// Indicates that this @ref WGPUStorageTextureBindingLayout member of
		/// its parent @ref WGPUBindGroupLayoutEntry is not used.
		/// (See also @ref SentinelValues.)
		/// </summary>
		BindingNotUsed = 0,

		/// <summary>
		/// Indicates no value is passed for this argument. See @ref SentinelValues.
		/// </summary>
		Undefined,

		/// <summary>
		/// Specifies that a storage texture can only be written to.
		/// </summary>
		WriteOnly,

		/// <summary>
		/// Specifies that the texture can only be read from in storage operations.
		/// </summary>
		ReadOnly,

		/// <summary>
		/// Indicates that the storage texture can be both read from and written to.
		/// </summary>
		ReadWrite,
	}
}
