using System.Runtime.InteropServices;

namespace Engine.Sample.OpenGL
{
	[StructLayout(LayoutKind.Sequential)]
	internal struct PerformanceMetrics
	{
		public delegate void OnPerformanceUpdated(float frameTime, int fps);

		public event OnPerformanceUpdated? PerformanceUpdated;

		private float ticks;
		private int frameTimeLength;
		private int frameRateLength;

		public void Update(float deltaTime)
		{
			this.ticks += deltaTime;

			if (this.ticks < 1f)
			{
				return;
			}

			var frameTime = deltaTime * 1000f;
			var frameRate = (int)(1f / deltaTime);

			this.PerformanceUpdated?.Invoke(frameTime, frameRate);

			this.ticks = 0;
		}
	}
}
