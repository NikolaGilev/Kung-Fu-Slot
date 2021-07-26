using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proekt_test2_VP
{
    public partial class Scroll : Form
    {
        int Timer = 0;
        PlayerClass player;
        Randomizer random = new Randomizer();

        public Scroll(PlayerClass Player)
        {
            InitializeComponent();
            DoubleBuffered = true;
            player = Player;
            label1.Text = "Congratulations! You Won " + player.SpinsLeft.ToString() + " Free Spins! \n" + "Click The Button Bellow to Pick your Bonus Character";
        }

        private void SpinButton_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(Timer < 4)
            {
                Timer++;
                player.BonusPicture = random.getRand(9, 15);
                pictureBox1.Image = Image.FromFile("Pictures/" + player.BonusPicture.ToString() + ".png");
            }
            else
            {
                timer1.Stop();
                ParadiseButton.Enabled = true;
            }
        }

        private void ParadiseButton_Click(object sender, EventArgs e)
        {
            BonusSpins bonusSpins = new BonusSpins(player);
            this.Hide();
            bonusSpins.ShowDialog();
            this.Close();
        }
    }
}
