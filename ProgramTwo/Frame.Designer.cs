namespace ProgramTwo
{
	partial class Frame
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frame));
			this.PlayButt = new System.Windows.Forms.Button();
			this.gameTimer = new System.Windows.Forms.Timer(this.components);
			this.PlayAgainButt = new System.Windows.Forms.Button();
			this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// PlayButt
			// 
			this.PlayButt.BackColor = System.Drawing.SystemColors.ControlDark;
			this.PlayButt.FlatAppearance.BorderSize = 0;
			this.PlayButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayButt.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlayButt.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.PlayButt.Location = new System.Drawing.Point(339, 244);
			this.PlayButt.Margin = new System.Windows.Forms.Padding(0);
			this.PlayButt.Name = "PlayButt";
			this.PlayButt.Size = new System.Drawing.Size(122, 36);
			this.PlayButt.TabIndex = 0;
			this.PlayButt.Text = "PLAY";
			this.PlayButt.UseVisualStyleBackColor = false;
			this.PlayButt.Click += new System.EventHandler(this.PlayButt_Click);
			// 
			// PlayAgainButt
			// 
			this.PlayAgainButt.BackColor = System.Drawing.SystemColors.ControlDark;
			this.PlayAgainButt.FlatAppearance.BorderSize = 0;
			this.PlayAgainButt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.PlayAgainButt.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PlayAgainButt.Location = new System.Drawing.Point(339, 318);
			this.PlayAgainButt.Name = "PlayAgainButt";
			this.PlayAgainButt.Size = new System.Drawing.Size(122, 36);
			this.PlayAgainButt.TabIndex = 1;
			this.PlayAgainButt.Text = "PLAY AGAIN";
			this.PlayAgainButt.UseVisualStyleBackColor = false;
			this.PlayAgainButt.Visible = false;
			this.PlayAgainButt.Click += new System.EventHandler(this.PlayAgainButt_Click);
			// 
			// Frame
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
			this.ClientSize = new System.Drawing.Size(804, 477);
			this.Controls.Add(this.PlayAgainButt);
			this.Controls.Add(this.PlayButt);
			this.Font = new System.Drawing.Font("MS Reference Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Frame";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Pong";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Frame_Paint);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frame_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Frame_KeyUp);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button PlayButt;
		private System.Windows.Forms.Timer gameTimer;
		private System.Windows.Forms.Button PlayAgainButt;
		private System.ComponentModel.BackgroundWorker backgroundWorker1;
	}
}

