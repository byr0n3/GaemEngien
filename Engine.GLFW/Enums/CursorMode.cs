namespace glfw.Enums
{
	/// <summary>
	/// Specifies the input mode for the cursor.
	/// </summary>
	public enum CursorMode
	{
		/// <summary>
		/// Represents the default cursor mode where the cursor is visible and behaves normally.
		/// </summary>
		None = 0,

		/// <summary>
		/// Represents the cursor mode where the cursor is visible and behaves normally.
		/// </summary>
		Normal = 0x00034001,

		/// <summary>
		/// Represents the cursor mode where the cursor is hidden and does not appear on the screen.
		/// </summary>
		Hidden = 0x00034002,

		/// <summary>
		/// Represents the cursor mode where the cursor is hidden and does not affect window events.
		/// </summary>
		Disabled = 0x00034003,

		/// <summary>
		/// Indicates that the cursor is captured and confined to the window. This mode hides the cursor and disables its normal behavior.
		/// </summary>
		Captured = 0x00034004,
	}
}
