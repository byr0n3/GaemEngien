using System.Runtime.InteropServices;
using glfw.Enums;
using glfw.Internal;

namespace glfw
{
	/// <summary>
	/// Provides a wrapper for the GLFW library to create windows, contexts and surfaces, receive input and events.
	/// </summary>
	public static class GLFW
	{
		/// <summary>
		/// Represents a delegate that handles error events in the GLFW library.
		/// </summary>
		/// <param name="errorCode">The error code associated with the error.</param>
		/// <param name="description">A description of the error.</param>
		public delegate void ErrorHandler(ErrorCode errorCode, NativeString description);

		/// <summary>
		/// Event that is triggered when a GLFW error occurs.
		/// </summary>
		public static event ErrorHandler? OnError;

		/// <summary>
		/// Returns the GLFW time.
		/// This function returns the current GLFW time in seconds.
		/// Unless the time has been set manually, it measures time elapsed since GLFW was initialized.
		/// </summary>
		public static double Time
		{
			get => libglfw3.GetTime();
			set => libglfw3.SetTime(value);
		}

		/// <summary>
		/// Initializes the GLFW library.
		/// </summary>
		/// <returns>
		/// Returns true if the GLFW library was initialized successfully, false otherwise.
		/// </returns>
		public static unsafe bool Initialize()
		{
			libglfw3.SetErrorCallback(&GLFW.OnGlfwError);

			return libglfw3.Init();
		}

		/// <summary>
		/// Terminates the GLFW library.
		/// </summary>
		public static void Terminate() =>
			libglfw3.Terminate();

		/// <summary>
		/// Processes only those events that have already been posted to the event queue.
		/// </summary>
		public static void PollEvents() =>
			libglfw3.PollEvents();

		[UnmanagedCallersOnly]
		private static void OnGlfwError(ErrorCode code, NativeString description) =>
			GLFW.OnError?.Invoke(code, description);
	}
}
