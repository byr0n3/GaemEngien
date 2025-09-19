using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Engine.FreeType.Internal;
using glfw;
using JetBrains.Annotations;

namespace Engine.FreeType
{
	/// <summary>
	/// Represents a FreeType library instance that can be used to create faces and perform font operations.
	/// </summary>
	[MustDisposeResource]
	public readonly struct Library : System.IDisposable
	{
		[SuppressMessage("Roslynator", "RCS1213")]
		private readonly nint handle;

		/// <summary>
		/// Represents a handle to the FreeType library.
		/// </summary>
		public Library()
		{
			var error = libfreetype.InitFreeType(this);

			Debug.Assert(!error, "Unable to initialize FreeType library.");
		}

		/// <summary>
		/// Creates a new FreeType face from the specified path and face index.
		/// </summary>
		/// <param name="path">The path to the font file.</param>
		/// <param name="faceIndex">The face index within the font file. Default is 0.</param>
		/// <returns>A handle to the newly created face.</returns>
		[MustDisposeResource]
		public Face NewFace(NativeString path, int faceIndex = default)
		{
			Face face = default;

			var error = libfreetype.NewFace(this, path, faceIndex, face);

			Debug.Assert(!error, "Unable to create a new FreeType face.");

			return face;
		}

		/// <summary>
		/// Releases the unmanaged resources used by this instance and optionally releases the managed resources.
		/// </summary>
		public void Dispose() =>
			libfreetype.DoneFreeType(this);
	}
}
