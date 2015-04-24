using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTwo
{
	class Settings
	{
		public static bool inputState { get; set; }
		public static bool startState { get; set; }
		public static bool playState { get; set; }
		public static bool endState { get; set; }
		public static bool scoreState { get; set; }
		public static int leftPaddleX { get; set; }
		public static int leftPaddleY { get; set; }
		public static int rightPaddleX { get; set; }
		public static int rightPaddleY { get; set; }
		public static int ballSpeedX { get; set; }
		public static int ballSpeedY { get; set; }
		public static int ballX { get; set; }
		public static int ballY { get; set; }
		public static int counter { get; set; }

		public Settings()
		{
			inputState = false;
			startState = false;
			playState = false;
			endState = false;
			scoreState = false;
			counter = 3;

			leftPaddleX = BootSettings.paddleOffset;
			leftPaddleY = BootSettings.windowHeight / 2 - BootSettings.paddleHeight / 2;
			rightPaddleX = BootSettings.windowWidth - BootSettings.paddleOffset - BootSettings.paddleWidth;
			rightPaddleY = BootSettings.windowHeight / 2 - BootSettings.paddleHeight / 2;

			ballSpeedX = (new Random().Next(0, 2) * 2 - 1) * (770 / BootSettings.FPS);
			ballSpeedY = (new Random().Next(0, 2) * 2 - 1) * (new Random().Next(BootSettings.minBallSpeedY, BootSettings.maxBallSpeedY) / BootSettings.FPS);

			if (ballSpeedX < 0)
			{
				ballX = rightPaddleX - BootSettings.paddleWidth - (BootSettings.ballRadius * 2) - 1;
			}
			else
			{
				ballX = leftPaddleX + BootSettings.paddleWidth + (BootSettings.ballRadius * 2) + 1;
			}
			ballY = BootSettings.windowHeight / 2 - BootSettings.ballRadius;
		}
	}
}
