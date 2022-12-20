namespace spaceRace
{
    partial class spaceRaceGame
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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.plrTwoScore = new System.Windows.Forms.Label();
            this.plrOneScore = new System.Windows.Forms.Label();
            this.outputLabel = new System.Windows.Forms.Label();
            this.resetTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // plrTwoScore
            // 
            this.plrTwoScore.BackColor = System.Drawing.Color.Transparent;
            this.plrTwoScore.Font = new System.Drawing.Font("Showcard Gothic", 69.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plrTwoScore.ForeColor = System.Drawing.Color.White;
            this.plrTwoScore.Location = new System.Drawing.Point(672, 344);
            this.plrTwoScore.Name = "plrTwoScore";
            this.plrTwoScore.Size = new System.Drawing.Size(100, 104);
            this.plrTwoScore.TabIndex = 0;
            // 
            // plrOneScore
            // 
            this.plrOneScore.BackColor = System.Drawing.Color.Transparent;
            this.plrOneScore.Font = new System.Drawing.Font("Showcard Gothic", 69.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plrOneScore.ForeColor = System.Drawing.Color.White;
            this.plrOneScore.Location = new System.Drawing.Point(16, 344);
            this.plrOneScore.Name = "plrOneScore";
            this.plrOneScore.Size = new System.Drawing.Size(100, 104);
            this.plrOneScore.TabIndex = 1;
            // 
            // outputLabel
            // 
            this.outputLabel.BackColor = System.Drawing.Color.Transparent;
            this.outputLabel.Font = new System.Drawing.Font("Showcard Gothic", 54.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputLabel.ForeColor = System.Drawing.Color.White;
            this.outputLabel.Location = new System.Drawing.Point(0, 120);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(784, 104);
            this.outputLabel.TabIndex = 2;
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // resetTimer
            // 
            this.resetTimer.Interval = 20;
            this.resetTimer.Tick += new System.EventHandler(this.resetTimer_Tick);
            // 
            // spaceRaceGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.outputLabel);
            this.Controls.Add(this.plrOneScore);
            this.Controls.Add(this.plrTwoScore);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "spaceRaceGame";
            this.Text = "spaceRace";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label plrTwoScore;
        private System.Windows.Forms.Label plrOneScore;
        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.Timer resetTimer;
    }
}

