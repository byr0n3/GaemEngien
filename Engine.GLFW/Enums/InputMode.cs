namespace glfw.Enums
{
	/// <summary>
	/// Specifies the input modes for a window.
	/// </summary>
	public enum InputMode
	{
		/// <summary>
		/// Specifies that no input mode is set.
		/// </summary>
		None = 0,

		/// <summary>
		/// Specifies the input mode for the cursor.
		/// </summary>
		Cursor = 0x00033001,

		/// <summary>
		/// Specifies that the sticky keys input mode is set.
		/// </summary>
		StickyKeys = 0x00033002,

		/// <summary>
		/// Specifies that the mouse button state should remain "pressed" until the
		/// mouse button is physically released.
		/// </summary>
		StickyMouseButtons = 0x00033003,

		/// <summary>
		/// Specifies the input mode for locking key modifiers.
		/// </summary>
		LockKeyMods = 0x00033004,

		/// <summary>
		/// Specifies that the window receives raw mouse motion events.
		/// </summary>
		RawMouseMotion = 0x00033005,
	}
}
