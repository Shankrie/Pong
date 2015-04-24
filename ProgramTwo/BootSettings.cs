using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTwo
{
	class BootSettings
	{
		public static int windowWidth { get; set; }
		public static int windowHeight { get; set; }
		public static int FPS { get; set; }
		
		public static int maxScore { get; set; }

		public static int paddleSpeed { get; set; }
		public static int paddleWidth { get; set; }
		public static int paddleHeight { get; set; }
		public static int paddleOffset { get; set; }

		public static int ballRadius { get; set; }
		public static int minBallSpeedY { get; set; }
		public static int maxBallSpeedY { get; set; }

		public BootSettings() 
		{
			windowWidth = 800;
			windowHeight = 450;

			FPS = 70;
			
			maxScore = 3;

			paddleSpeed = 420 / FPS; 
			paddleWidth = 10;
			paddleHeight = 80;
			paddleOffset = 50;

			ballRadius = 6;
			minBallSpeedY = 280;
			maxBallSpeedY = 420;
		}
	}
}
