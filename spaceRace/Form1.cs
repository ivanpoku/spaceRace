using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace spaceRace
{
    public partial class spaceRaceGame : Form
    {
        Random randGen = new Random();
        int playerSpeed = 5;
        int playerSize = 48;
        int astroidSpeed = 5;
        int rocketYPos = 400;
        int currentTime = 0;
        int resetTimeCounter = 0;
        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        Rectangle player1 = new Rectangle(300, 400, 48, 48);
        Rectangle player2 = new Rectangle(500, 400, 48, 48);
        List<Rectangle> astroids = new List<Rectangle>();
        List<Rectangle> astroidsRight = new List<Rectangle>();
        Image rocketImage = Properties.Resources.rocket_icon;
        SolidBrush blackBrush = new SolidBrush(Color.White);
        int generateRecValue;
        int plr1Score = 0;
        int plr2Score = 0;
        SoundPlayer crashSound = new SoundPlayer(Properties.Resources._521620__lucas_post__electronic_bomb);
        SoundPlayer winSound = new SoundPlayer(Properties.Resources._391539__unlistenable__electro_win_sound);
        public spaceRaceGame()
        {
            InitializeComponent();
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(rocketImage, player1);
            e.Graphics.DrawImage(rocketImage, player2);
            for (int i = 0; i < astroids.Count; i++)
            {
                e.Graphics.FillRectangle(blackBrush, astroids[i]);
            }
            for (int i = 0; i < astroidsRight.Count; i++)
            {
                e.Graphics.FillRectangle(blackBrush, astroidsRight[i]);
            }
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Current Time
            currentTime++;

            //Game Start Countdown
            if (currentTime == 20)
            {
                outputLabel.Text = "5";
            }
            else if (currentTime == 40)
            {
                outputLabel.Text = "4";
            }
            else if (currentTime == 60)
            {
                outputLabel.Text = "3";
            }
            else if (currentTime == 80)
            {
                outputLabel.Text = "2";
            }
            else if (currentTime == 100)
            {
                outputLabel.Text = "1";
            }
            else if (currentTime == 120)
            {
                outputLabel.Text = "GO";
            }
            else if (currentTime == 140)
            {
                outputLabel.Text = "";
            }


            //Display Score
            plrTwoScore.Text = $"{plr2Score}";
            plrOneScore.Text = $"{plr1Score}";

            //Player Move
            if (wDown == true && currentTime >= 100)
            {
                player1.Y -= playerSpeed;
            }
            if (sDown == true && currentTime >= 100)
            {
                player1.Y += playerSpeed;
            }
            if (upArrowDown == true && currentTime >= 100)
            {
                player2.Y -= playerSpeed;
            }
            if (downArrowDown == true && currentTime >= 100)
            {
                player2.Y += playerSpeed;
            }

            //Border Collisions
            if (player1.Y <= 0)
            {
                player1.Y = 1;
            }
            if (player1.Y >= 465 - playerSize)
            {
                player1.Y = 465 - playerSize - 1;
            }
            if (player2.Y <= 0)
            {
                player2.Y = 1;
            }
            if (player2.Y >= 465 - playerSize)
            {
                player2.Y = 465 - playerSize - 1;
            }

            //Generate Astroids
            generateRecValue = randGen.Next(1, 101);
            if (generateRecValue < 11)
            {
                astroids.Add(new Rectangle(0, randGen.Next(0, 350), 5, 5));
                astroidsRight.Add(new Rectangle(this.Width - 5, randGen.Next(0, 350), 5, 5));
            }

            //move astroids
            for (int i = 0; i < astroids.Count; i++)
            {
                int x = astroids[i].X + astroidSpeed;
                astroids[i] = new Rectangle(x, astroids[i].Y, 5, 5);
            }
            for (int i = 0; i < astroidsRight.Count; i++)
            {
                int x = astroidsRight[i].X - astroidSpeed;
                astroidsRight[i] = new Rectangle(x, astroidsRight[i].Y, 5, 5);
            }

            //Remove Astroids
            for (int i = 0; i < astroids.Count; i++)
            {
                if (astroids[i].X >= this.Width)
                {
                    astroids.RemoveAt(i);
                }
            }
            for (int i = 0; i < astroidsRight.Count; i++)
            {
                if (astroidsRight[i].X <= 0)
                {
                    astroidsRight.RemoveAt(i);
                }  
            }

            //Check Player & Astroid Collisions
            for (int i = 0; i < astroidsRight.Count; i++)
            {
                if (player1.IntersectsWith(astroids[i]) || player1.IntersectsWith(astroidsRight[i]))
                {
                    player1.Y = rocketYPos;
                    crashSound.Play();
                }
                else if (player2.IntersectsWith(astroids[i]) || player2.IntersectsWith(astroidsRight[i]))
                {
                    player2.Y = rocketYPos;
                    crashSound.Play();
                }
            }
           
            //Check if player is at top
            if (player1.Y <= 5)
            {
                plr1Score++;
                player1.Y = rocketYPos;
                winSound.Play();
                if (plr1Score == 3)
                {
                    winSound.Play();
                    outputLabel.Text = "Player 1 Wins!!!";
                    plrOneScore.Text = "3";
                    astroids.Clear();
                    astroidsRight.Clear();
                    player1.Y = rocketYPos;
                    player2.Y = rocketYPos;
                    playerSpeed = 0;
                    gameTimer.Stop();
                    resetTimer.Enabled = true;
                }
            }
            if (player2.Y <= 5)
            {
                plr2Score++;
                player2.Y = rocketYPos;
                winSound.Play();
                if (plr2Score == 3)
                {
                    winSound.Play();
                    outputLabel.Text = "Player 2 Wins!!!";
                    plrTwoScore.Text = "3";
                    astroids.Clear();
                    astroidsRight.Clear();
                    player1.Y = rocketYPos;
                    player2.Y = rocketYPos;
                    playerSpeed = 0;
                    gameTimer.Stop();
                    resetTimer.Enabled = true; 
                }
            }

            this.Refresh();
        }

        private void resetTimer_Tick(object sender, EventArgs e)
        {
            resetTimeCounter++;
            if (resetTimeCounter == 20)
            {
                outputLabel.Text = "Reseting";
            }

            if (resetTimeCounter == 40)
            {
                Application.Restart();
            }
            this.Refresh();
        }
    }
}