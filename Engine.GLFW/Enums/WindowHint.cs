namespace glfw.Enums
{
	/// <summary>
	/// Specifies window creation hints.
	/// </summary>
	public enum WindowHint
	{
		/// <summary>
		/// Specifies no window creation hint.
		/// </summary>
		None = 0,

		/// <summary>
		/// Specifies whether the windowed mode window is resizable.
		/// </summary>
		Resizable = 0x00020003,

		/// <summary>
		/// Specifies the client API to be used by the created window.
		/// </summary>
		ClientApi = 0x00022001,
	}
}
