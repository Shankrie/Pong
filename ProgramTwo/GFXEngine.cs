using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTwo
{
	class GFXEngine
	{
		SolidBrush mainBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Silver);
		SolidBrush greyBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Gray);
		Brush redBrush = new SolidBrush(Color.FromArgb(brushCounter, 255, 0, 0));
		Pen dashedLinePen;
		Font mainFont = new System.Drawing.Font("Agency FB", 20);
		Font winnerNameFont = new System.Drawing.Font("Agency FB", 18);

		Rectangle aligningRect = new Rectangle(BootSettings.windowWidth / 2 - 100, BootSettings.windowHeight / 2 - 48, 200, 100);
		Rectangle gameOverRect = new Rectangle(BootSettings.windowWidth / 2 - 100, BootSettings.windowHeight / 2 - 48, 200, 100);
		Rectangle leftScoreRect = new Rectangle(BootSettings.windowWidth / 2 - 175, 25, 160, 100);
		Rectangle rightScoreRect = new Rectangle(BootSettings.windowWidth / 2 + 15, 25, 160, 100);
		StringFormat textAlign = new StringFormat();
		StringFormat leftScoreAlign = new StringFormat();
		StringFormat rightScoreAlign = new StringFormat();

		public static int timeCounter = 0;
		public static int brushCounter = 2;
		public static int brushCounterDirection = 2;
		float[] dashedLinePattern = { 9, 22 };

		public GFXEngine()
		{
			textAlign.Alignment = StringAlignment.Center;
			textAlign.LineAlignment = StringAlignment.Center;
			leftScoreAlign.Alignment = StringAlignment.Far;
			rightScoreAlign.Alignment = StringAlignment.Near;
			leftScoreAlign.LineAlignment = StringAlignment.Near;
			rightScoreAlign.LineAlignment = StringAlignment.Near;

			dashedLinePen = new Pen(mainBrush, 2);
		}

		public void DrawInputScreen(PaintEventArgs e)
		{
			aligningRect.Y = 50;
			e.Graphics.DrawString("PONG", new Font("Agency FB", 56), mainBrush, aligningRect, textAlign);
			aligningRect.Y = 94;
			e.Graphics.DrawString("game project by", new Font("Agency FB", 14), greyBrush, aligningRect, textAlign);
			aligningRect.Y = 122;
			e.Graphics.DrawString("HENRIKAS JASIUNAS", new Font("Agency FB", 14), mainBrush, aligningRect, textAlign);
		
			aligningRect.Y = BootSettings.windowHeight / 2 - 48;
		}

		public void DrawStartScreen(PaintEventArgs e)
		{


			string counterString;

			if (Settings.counter > 0)
			{
				counterString = Settings.counter.ToString();

				redBrush = new SolidBrush(Color.FromArgb(brushCounter, 255, 0, 0));
				if (Settings.ballSpeedX < 0)
					e.Graphics.FillRectangle(redBrush, 0, 0, BootSettings.windowWidth / 2, BootSettings.windowHeight);
				else
					e.Graphics.FillRectangle(redBrush, BootSettings.windowWidth / 2, 0, BootSettings.windowWidth / 2, BootSettings.windowHeight);
				brushCounter += brushCounterDirection;
				if (brushCounter >= 72 || brushCounter < 2)
				{
					brushCounterDirection *= -1;
				}
			}
			else
			{
				counterString = "GO!";
				timeCounter++;
				if (timeCounter >= 70)
				{
					timeCounter = 0;
					Settings.startState = false;
					brushCounter = 2;
					brushCounterDirection = 2;
				}
				Settings.playState = true;
			}

			e.Graphics.DrawString(counterString, mainFont, mainBrush, aligningRect, textAlign);
			timeCounter++;
			if (timeCounter == 70 && Settings.counter > 0)
			{
				timeCounter = 0;
				Settings.counter--;
			}
		}

		public void DrawFlashing(PaintEventArgs e)
		{
			if (Settings.ballSpeedX < 0)
				e.Graphics.FillRectangle(redBrush, 0, 0, BootSettings.windowWidth / 2, BootSettings.windowHeight);
			else
				e.Graphics.FillRectangle(redBrush, BootSettings.windowWidth / 2, 0, BootSettings.windowWidth / 2, BootSettings.windowHeight);
			brushCounter += brushCounterDirection;
			if (brushCounter >= 72 || brushCounter < 2)
			{
				brushCounterDirection *= -1;
			}
		}

		public void DrawPaddles(PaintEventArgs e)
		{
			e.Graphics.FillRectangle(mainBrush, Settings.leftPaddleX, Settings.leftPaddleY, BootSettings.paddleWidth, BootSettings.paddleHeight);
			e.Graphics.FillRectangle(mainBrush, Settings.rightPaddleX, Settings.rightPaddleY, BootSettings.paddleWidth, BootSettings.paddleHeight);
		}

		public void DrawDashedLine(PaintEventArgs e)
		{
			dashedLinePen.DashPattern = dashedLinePattern;
			e.Graphics.DrawLine(dashedLinePen, new Point(BootSettings.windowWidth / 2, 0), new Point(BootSettings.windowWidth / 2, BootSettings.windowHeight));
		}

		public void DrawBall(PaintEventArgs e)
		{
			e.Graphics.FillEllipse(mainBrush, Settings.ballX, Settings.ballY, BootSettings.ballRadius * 2, BootSettings.ballRadius * 2);
		}

		public void DrawEndScreen(PaintEventArgs e)
		{
			e.Graphics.DrawString("GAME OVER", mainFont, mainBrush, aligningRect, textAlign);

			leftScoreRect.Y = 260;
			rightScoreRect.Y = 260;
		}

		public void DrawScores(PaintEventArgs e, string leftScore, string rightScore)
		{
			string scoreString = leftScore;
			e.Graphics.DrawString(scoreString, mainFont, mainBrush, leftScoreRect, leftScoreAlign);

			scoreString = rightScore;
			e.Graphics.DrawString(scoreString, mainFont, mainBrush, rightScoreRect, rightScoreAlign);

			leftScoreRect.Y = 25;
			rightScoreRect.Y = 25;
		}
	}
}
