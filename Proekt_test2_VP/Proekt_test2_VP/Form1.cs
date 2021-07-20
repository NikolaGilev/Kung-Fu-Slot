using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Proekt_test2_VP
{
    public partial class Form1 : Form
    {
        WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();
        public PlayerClass player = new PlayerClass();

        public Form1()
        {
            InitializeComponent();
            Randomizer Randomizer = new Randomizer();
            DoubleBuffered = true;
            musicImage.Image = Image.FromFile("mute.png");
            musicImage.Tag = "mute.png";
            creditLabel.Text = "Credits: " + player.Credits.ToString();
        }

        public static int[] p = new int[12];

        private void Form1_Load(object sender, EventArgs e)
            {
            pictureBox1.Image = Image.FromFile("Pictures/1.png");
            pictureBox2.Image = Image.FromFile("Pictures/2.png");
            pictureBox3.Image = Image.FromFile("Pictures/3.png");
            pictureBox4.Image = Image.FromFile("Pictures/1.png");

            pictureBox5.Image = Image.FromFile("Pictures/2.png");
            pictureBox6.Image = Image.FromFile("Pictures/3.png");
            pictureBox7.Image = Image.FromFile("Pictures/1.png");
            pictureBox8.Image = Image.FromFile("Pictures/2.png");

            pictureBox9.Image = Image.FromFile("Pictures/3.png");
            pictureBox10.Image = Image.FromFile("Pictures/1.png");
            pictureBox11.Image = Image.FromFile("Pictures/2.png");
            pictureBox12.Image = Image.FromFile("Pictures/3.png");
            creditLabel.Text = "Credits: " + player.Credits.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (player.Credits >= player.Bet || timer1.Enabled)
            {
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    Pay();
                }
                else
                {
                    player.Spin();
                    creditLabel.Text = "Credits: " + player.Credits.ToString();
                    timer1.Start();
                }
                player.Total = 0;

            }

        }
        private void Pay()
        {
            // GET RESULTS FROM PAYTABLE
            // CHECK IF 1, 2, 3 or 4 OCCURANCES

            // for 3 and 4 connections :
            int couter = 1;
            bool connect3 = false;
            int px = 0;

            for (int i = 1; i < 12; i += 4)
            {
                for (int j = i; j < i + 3; j++)
                {
                    if (p[j - 1] == p[j])
                    {
                        couter++;
                        px = p[j];
                    }
                    else
                    {
                        break;
                    }
                    if (couter == 3) connect3 = true; // minimum 3 se konektiraat

                    if (couter == 4)
                    {
                        player.getConnected4(px);
                        connect3 = false;
                    }


                }

                if (connect3) // povika funkcija za da isplati 3 spoeni
                {
                    player.getConnected3(px);

                }

                px = 0;
                couter = 1;
                connect3 = false;
            }

            // for zig-zag 4 connections :
            if (p[0] == p[5] & p[10] == p[7] & p[5] == p[10] & p[0] != 8)
            {
                player.getZigZag(px);
            }
            if (p[1] == p[4] & p[6] == p[11] & p[4] == p[6] & p[1] != 8)
            {
                player.getZigZag(px);
            }
            if (p[2] == p[5] & p[8] == p[7] & p[5] == p[8] & p[2] != 8)
            { 
                player.getZigZag(px);
            }
            if (p[3] == p[6] & p[9] == p[4] & p[6] == p[9] & p[3] != 8)
            {
                player.getZigZag(px);
            }

            player.getCredit();

            WinLabel.Text = "Win: " + player.Total.ToString();
            creditLabel.Text = "Credits: " + player.Credits.ToString();
            BetLabel.Text = "Bet: " + player.Bet.ToString();
        }

        private void Rolling()
        {
            for (int i = 0; i < 12; i++)
            {
                p[i] = Randomizer.getRand(1, 9);

                if (i >= 4)
                {
                    if (p[i] == p[i - 4] & p[i] == 8)
                    {
                        p[i] = Randomizer.getRand(1, 8);
                    }
                    if(i >= 8)
                    {
                        if (p[i] == p[i - 8] & p[i] == 8)
                        {
                            p[i] = Randomizer.getRand(1, 8);
                        }
                    }
                }
            }

            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = Image.FromFile("Pictures/" + p[0].ToString() + ".png");
            if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
            pictureBox2.Image = Image.FromFile("Pictures/" + p[1].ToString() + ".png");
            if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
            pictureBox3.Image = Image.FromFile("Pictures/" + p[2].ToString() + ".png");
            if (pictureBox4.Image != null) pictureBox4.Image.Dispose();
            pictureBox4.Image = Image.FromFile("Pictures/" + p[3].ToString() + ".png");

            if (pictureBox5.Image != null) pictureBox5.Image.Dispose();
            pictureBox5.Image = Image.FromFile("Pictures/" + p[4].ToString() + ".png");
            if (pictureBox6.Image != null) pictureBox6.Image.Dispose();
            pictureBox6.Image = Image.FromFile("Pictures/" + p[5].ToString() + ".png");
            if (pictureBox7.Image != null) pictureBox7.Image.Dispose();
            pictureBox7.Image = Image.FromFile("Pictures/" + p[6].ToString() + ".png");
            if (pictureBox8.Image != null) pictureBox8.Image.Dispose();
            pictureBox8.Image = Image.FromFile("Pictures/" + p[7].ToString() + ".png");

            if (pictureBox9.Image != null) pictureBox9.Image.Dispose();
            pictureBox9.Image = Image.FromFile("Pictures/" + p[8].ToString() + ".png");
            if (pictureBox10.Image != null) pictureBox10.Image.Dispose();
            pictureBox10.Image = Image.FromFile("Pictures/" + p[9].ToString() + ".png");
            if (pictureBox11.Image != null) pictureBox11.Image.Dispose();
            pictureBox11.Image = Image.FromFile("Pictures/" + p[10].ToString() + ".png");
            if (pictureBox12.Image != null) pictureBox12.Image.Dispose();
            pictureBox12.Image = Image.FromFile("Pictures/" + p[11].ToString() + ".png");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rolling();
            if (musicImage.Tag.Equals("unmute.png") && musicPlayer.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                musicPlayer.URL = "OogwayAscends.mp3";
                musicPlayer.controls.play();
            }
        }

        private void BetAmountNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (BetAmountNumeric.Value > Convert.ToInt32(player.Credits))
            {
                BetAmountNumeric.Value = Convert.ToInt32(player.Credits);
            }
            if (BetAmountNumeric.Value >= 5)
            {
                player.Bet = Convert.ToInt64(BetAmountNumeric.Value);
            }

        }


        private void musicImage_Click(object sender, EventArgs e)
        {
            if (musicImage.Tag.Equals("mute.png"))
            {
                musicImage.Image = Image.FromFile("unmute.png");
                musicImage.Tag = "unmute.png";
                musicPlayer.URL = "OogwayAscends.mp3";
                musicPlayer.controls.play();
            }
            else
            {
                musicImage.Image = Image.FromFile("mute.png");
                musicImage.Tag = "mute.png";
                musicPlayer.controls.stop();
            }
        }

        private void FeatureButton_Click(object sender, EventArgs e)
        {
            player.SpinsLeft = 10;
            BonusSpins newBonusSpins = new BonusSpins(player);
            this.Hide();
            newBonusSpins.ShowDialog();
            this.Close();
        }
    }
}
