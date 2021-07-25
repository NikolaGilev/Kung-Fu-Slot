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
    public partial class BonusSpins : Form
    {
        WindowsMediaPlayer musicPlayer = new WindowsMediaPlayer();
        PlayerClass player;

        public BonusSpins(PlayerClass Player)
        {
            InitializeComponent();
            Randomizer Randomizer = new Randomizer();
            DoubleBuffered = true;
            musicImage.Image = Image.FromFile("mute.png");
            musicImage.Tag = "mute.png";
            player = Player;
            creditLabel.Text = "Credits: " + player.Credits.ToString();
            FreeSpinsLabel.Text = "Free spins left: " + player.SpinsLeft.ToString();

        }

        public static int[] p = new int[12];


        private void BonusSpins_Load(object sender, EventArgs e)
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
        }

        private void SpinButton_Click(object sender, EventArgs e)
        {
            if (player.Credits >= player.Bet || timer1.Enabled)
            {
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    Pay();
                }
                else if(player.SpinsLeft>0)
                {
                    creditLabel.Text = "Credits: " + player.Credits.ToString();
                    timer1.Start();
                    player.SpinsLeft--;
                    FreeSpinsLabel.Text = "Free spins left: " + player.SpinsLeft.ToString();
                }
                else
                {
                    Form1 form = new Form1();
                    form.player.Credits = player.Credits;
                    form.player.Bet = player.Bet;
                    musicPlayer.controls.stop();
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                    player.Total = 0;
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
            if (p[0] == p[5] & p[10] == p[7] & p[5] == p[10] & p[0] != 5)
                player.getZigZag(p[0]);
            if (p[1] == p[4] & p[6] == p[11] & p[4] == p[6] & p[1] != 5)
                player.getZigZag(p[1]);
            if (p[2] == p[5] & p[8] == p[7] & p[5] == p[8] & p[2] != 5)
                player.getZigZag(p[2]);
            if (p[3] == p[6] & p[9] == p[4] & p[6] == p[9] & p[3] != 5)
                player.getZigZag(p[3]);

            player.getCredit();


            WinLabel.Text = "Win: " + player.Total.ToString();
            creditLabel.Text = "Credits: " + player.Credits.ToString();
            BetLabel.Text = "Bet: " + player.Bet.ToString();
        }

        private void Rolling()
        {
            for (int i = 0; i < 12; i++)
            {
                p[i] = Randomizer.getRand(1, 6);

                if (i >= 4)
                {
                    if (p[i] == p[i - 4] & p[i] == 5)
                    {
                        p[i] = Randomizer.getRand(1, 5);
                    }
                    if (i >= 8)
                    {
                        if (p[i] == p[i - 8] & p[i] == 5)
                        {
                            p[i] = Randomizer.getRand(1, 5);
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
                musicPlayer.URL = "KungFuFighting.mp3";
                musicPlayer.controls.play();
            }
        }

        private void musicImage_Click_1(object sender, EventArgs e)
        {
            if (musicImage.Tag.Equals("mute.png"))
            {
                trackBar1.Value = 5;
                musicImage.Image = Image.FromFile("unmute.png");
                musicImage.Tag = "unmute.png";
                musicPlayer.URL = "KungFuFighting.mp3";
                musicPlayer.controls.play();
            }
            else
            {
                trackBar1.Value = 0;
                musicImage.Image = Image.FromFile("mute.png");
                musicImage.Tag = "mute.png";
                musicPlayer.controls.stop();
            }
            musicPlayer.settings.volume = trackBar1.Value * 10;
        }

        private void BetAmountNumeric_ValueChanged_1(object sender, EventArgs e)
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
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            musicPlayer.settings.volume = trackBar1.Value * 10;
        }
        private void musicImage_MouseHover(object sender, EventArgs e)
        {
            trackBar1.Visible = true;
        }
        private void BonusSpins_MouseHover(object sender, EventArgs e)
        {
            trackBar1.Visible = false;
        }

        

       
    }
}
    


           
           



