using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTwo
{
	public partial class Frame : Form
	{
		GFXEngine GFX;
		ScoreManager SM;
		
		public Frame()
		{
			InitializeComponent();

			new BootSettings();

			this.DoubleBuffered = true;
			this.ClientSize = new Size(BootSettings.windowWidth, BootSettings.windowHeight);

			Settings.inputState = true;

			GFX = new GFXEngine();
			SM = new ScoreManager();
			SM.Ended += new ScoredEventHandler(EndGame);
			SM.Scored += delegate(object sender, EventArgs e) { new Settings(); Settings.startState = true; };
		}

		private void UpdateScreen(object sender, EventArgs ea)
		{
			if (Settings.playState)
				MoveElements();

			this.Invalidate();
			this.Update();
		}

		private void Frame_Paint(object sender, PaintEventArgs e)
		{
			if (Settings.inputState)
			{
				GFX.DrawInputScreen(e);
			}

			if (Settings.startState)
			{
				GFX.DrawStartScreen(e);
			}

			if (Settings.startState || Settings.playState)
			{
				GFX.DrawPaddles(e);
				GFX.DrawDashedLine(e);
			}

			if (Settings.playState)
			{
				GFX.DrawBall(e);
			}

			if (Settings.endState)
			{
				GFX.DrawEndScreen(e);
			}

			if (Settings.startState || Settings.playState || Settings.endState)
			{
				GFX.DrawScores(e, SM.LeftPlayerScore.ToString(), SM.RightPlayerScore.ToString());
			}
		}

		private void MoveElements()
		{
			//move left paddle
			if (Input.KeyPressed(Keys.W) && Settings.leftPaddleY > 0)
			{
				Settings.leftPaddleY -= BootSettings.paddleSpeed;
			}
			else if (Input.KeyPressed(Keys.S) && Settings.leftPaddleY + BootSettings.paddleHeight < BootSettings.windowHeight)
			{
				Settings.leftPaddleY += BootSettings.paddleSpeed;
			}

			//move right paddle
			if (Input.KeyPressed(Keys.NumPad8) && Settings.rightPaddleY > 0)
			{
				Settings.rightPaddleY -= BootSettings.paddleSpeed;
			}
			else if (Input.KeyPressed(Keys.NumPad2) && Settings.rightPaddleY + BootSettings.paddleHeight < BootSettings.windowHeight)
			{
				Settings.rightPaddleY += BootSettings.paddleSpeed;
			}

			//if ball hits the bottom wall
			if (Settings.ballY + (BootSettings.ballRadius * 2) >= BootSettings.windowHeight)
				BounceOffWall(1);

			//if ball hits the top wall
			if (Settings.ballY - BootSettings.ballRadius <= 0)
				BounceOffWall(-1);
				

			//if ball hits the left paddle
			if (Settings.ballX <= Settings.leftPaddleX + BootSettings.paddleWidth &&
			   Settings.ballY + (BootSettings.ballRadius * 2) >= Settings.leftPaddleY &&
			   Settings.ballY <= Settings.leftPaddleY + BootSettings.paddleHeight &&
			   Settings.ballX > Settings.leftPaddleX - 10)
			{
				BounceOffPaddle();
			}

			//if ball hits the right paddle
			if (Settings.ballX + BootSettings.ballRadius * 2 >= Settings.rightPaddleX &&
			   Settings.ballY + (BootSettings.ballRadius * 2) >= Settings.rightPaddleY &&
			   Settings.ballY <= Settings.rightPaddleY + BootSettings.paddleHeight &&
			   Settings.ballX + (BootSettings.ballRadius * 2) < Settings.rightPaddleX + 10)
			{
				BounceOffPaddle();
			}

			//if ball goes out of board (right wall)
			if (Settings.ballX - BootSettings.ballRadius >= BootSettings.windowWidth)
				SM.LeftPlayerScore++;

			//if ball goes out of board (left wall)
			if (Settings.ballX + BootSettings.ballRadius <= 0)
				SM.RightPlayerScore++;	

			//move ball
			Settings.ballX += Settings.ballSpeedX;
			Settings.ballY += Settings.ballSpeedY;
		}

		private void BounceOffPaddle()
		{
			if (Settings.ballSpeedY > 0)
				Settings.ballSpeedY = new Random().Next(BootSettings.minBallSpeedY, BootSettings.maxBallSpeedY) / BootSettings.FPS;
			else
				Settings.ballSpeedY = new Random().Next(-BootSettings.maxBallSpeedY, -BootSettings.minBallSpeedY) / BootSettings.FPS;

			Settings.ballSpeedX *= -1;
		}

		private void BounceOffWall(int direction)
		{
			Settings.ballSpeedY = direction * new Random().Next(BootSettings.minBallSpeedY, BootSettings.maxBallSpeedY) / BootSettings.FPS;
			Settings.ballSpeedY *= -1;
		}

		private void PlayButt_Click(object sender, EventArgs e)
		{
			new Settings();

			PlayButt.Dispose();

			gameTimer.Interval = 13;
			gameTimer.Tick += UpdateScreen;
			gameTimer.Start();

			Settings.startState = true;
		}

		private void PlayAgainButt_Click(object sender, EventArgs e)
		{
			PlayAgainButt.Visible = false;
			SM.LeftPlayerScore = 0;
			SM.RightPlayerScore = 0;

			new Settings();
			Settings.startState = true;
			this.Focus();
			this.Invalidate();
			this.Update();
		}

		private void Frame_KeyDown(object sender, KeyEventArgs e)
		{
			Input.ChangeState(e.KeyCode, true);
		}

		private void Frame_KeyUp(object sender, KeyEventArgs e)
		{
			Input.ChangeState(e.KeyCode, false);
		}

		public void EndGame(object sender, EventArgs e)
		{
			new Settings();
			Settings.endState = true;
			PlayAgainButt.Visible = true;
		}
	}
}
