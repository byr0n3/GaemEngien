using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using Engine.FreeType.Internal;
using glfw;
using JetBrains.Annotations;

namespace Engine.FreeType
{
	[MustDisposeResource]
	public readonly struct Library : System.IDisposable
	{
		[SuppressMessage("Roslynator", "RCS1213")]
		private readonly nint handle;

		public Library()
		{
			var error = libfreetype.InitFreeType(this);

			Debug.Assert(!error, "Unable to initialize FreeType library.");
		}

		[MustDisposeResource]
		public Face NewFace(NativeString path, int faceIndex = default)
		{
			Face face = default;

			var error = libfreetype.NewFace(this, path, faceIndex, face);

			Debug.Assert(!error, "Unable to create a new FreeType face.");

			return face;
		}

		public void Dispose() =>
			libfreetype.DoneFreeType(this);
	}
}
