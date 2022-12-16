using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace spaceRace
{
    public partial class spaceRaceGame : Form
    {
        int playerSpeed = 5;
        int playerSize = 48;
        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;
        Rectangle player1 = new Rectangle(300, 400, 48, 48);
        Rectangle player2 = new Rectangle(500, 400, 48, 48);
        Image rocketImage = Properties.Resources.rocket_icon;

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
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Player Move
            if (wDown == true)
            {
                player1.Y -= playerSpeed;
            }
            if (sDown == true)
            {
                player1.Y += playerSpeed;
            }
            if (upArrowDown == true)
            {
                player2.Y -= playerSpeed;
            }
            if (downArrowDown == true)
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
            this.Refresh();
        }
    }
}
