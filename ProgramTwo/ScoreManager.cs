using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;

namespace ProgramTwo
{
	public delegate void ScoredEventHandler(object sender, EventArgs e);

	[Serializable()]
	class ScoreManager
	{
		public event ScoredEventHandler Ended;
		public event ScoredEventHandler Scored;

		private int _leftPlayerScore;
		private int _rightPlayerScore;

		public ScoreManager()
		{
			LeftPlayerScore = 0;
			RightPlayerScore = 0;
		}

		
		public int LeftPlayerScore
		{
			get
			{
				return _leftPlayerScore;
			}
			set
			{
				_leftPlayerScore = value;
				OnScored(EventArgs.Empty);
				if (_leftPlayerScore == BootSettings.maxScore)
				{
					OnEndGame(EventArgs.Empty);
				}
			}
		}

		public int RightPlayerScore
		{
			get
			{
				return _rightPlayerScore;
			}
			set
			{
				_rightPlayerScore = value;
				OnScored(EventArgs.Empty);
				if (_rightPlayerScore == BootSettings.maxScore)
				{
					OnEndGame(EventArgs.Empty);
				}
			}
		}

		private void OnEndGame(EventArgs e)
		{		 
			if (Ended != null)
			{
				Ended(this, e);
			}
		}

		private void OnScored(EventArgs e)
		{
			if (Scored != null)
			{
				Scored(this, e);
			}
		}
	}
}
