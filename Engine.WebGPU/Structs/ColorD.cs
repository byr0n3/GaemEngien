using System.Diagnostics;
using System.Runtime.InteropServices;

namespace wgpu.Structs
{
	/// <summary>
	/// Represents a color in the RGBA format.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	[DebuggerTypeProxy(typeof(ColorD.DebugView))]
	public readonly struct ColorD
	{
		/// <summary>
		/// Gets the red chanel of the color, represented as a value between 0.0 and 1.0.
		/// </summary>
		public double Red { get; init; }

		/// <summary>
		/// Gets the green chanel of the color, represented as a value between 0.0 and 1.0.
		/// </summary>
		public double Green { get; init; }

		/// <summary>
		/// Gets the blue chanel of the color, represented as a value between 0.0 and 1.0.
		/// </summary>
		public double Blue { get; init; }

		/// <summary>
		/// Gets the alpha chanel of the color, represented as a value between 0.0 and 1.0.
		/// </summary>
		public double Alpha { get; init; }

		/// <inheritdoc cref="ColorD"/>
		/// <param name="red">The red chanel of the color, represented as a value between 0.0 and 1.0.</param>
		/// <param name="green">The green chanel of the color, represented as a value between 0.0 and 1.0.</param>
		/// <param name="blue">The blue chanel of the color, represented as a value between 0.0 and 1.0.</param>
		public ColorD(double red, double green, double blue) : this(red, blue, green, 1.0d)
		{
		}

		/// <inheritdoc cref="ColorD"/>
		/// <param name="red">The red chanel of the color, represented as a value between 0.0 and 1.0.</param>
		/// <param name="green">The green chanel of the color, represented as a value between 0.0 and 1.0.</param>
		/// <param name="blue">The blue chanel of the color, represented as a value between 0.0 and 1.0.</param>
		/// <param name="alpha">The alpha chanel of the color, represented as a value between 0.0 and 1.0.</param>
		public ColorD(double red, double green, double blue, double alpha)
		{
			this.Red = red;
			this.Green = green;
			this.Blue = blue;
			this.Alpha = alpha;
		}

		/// <summary>
		/// Returns a string representation of the Color in RGBA format.
		/// </summary>
		/// <returns>A string representing the color in the format <c>rgba(red, green, blue, alpha)</c>.</returns>
		public override string ToString() =>
			string.Create(null, $"rgba({this.Red}, {this.Green}, {this.Blue}, {this.Alpha})");

		private sealed class DebugView
		{
			public readonly string Value;

			public DebugView(ColorD colorD) =>
				this.Value = colorD.ToString();
		}
	}
}
