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
        WindowsMediaPlayer player = new WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            Randomizer Randomizer = new Randomizer();
            DoubleBuffered = true;
            musicImage.Image = Image.FromFile("mute.png");
            musicImage.Tag = "mute.png";

        }
        // rand p-s
        //public static int p1;
        //public static int p2;
        //public static int p3;
        //public static int p4;
        //public static int p5;
        //public static int p6;
        //public static int p7;
        //public static int p8;
        //public static int p9;
        //public static int p10;
        //public static int p11;
        //public static int p12;

        public static int[] p = new int[12];

        // CREDIT, TOTAL AND BET
        public static double credits = 100;
        public static double total = 0;
        public static long bet = 5;

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile("1.png");
            pictureBox2.Image = Image.FromFile("2.png");
            pictureBox3.Image = Image.FromFile("3.png");
            pictureBox4.Image = Image.FromFile("1.png");

            pictureBox5.Image = Image.FromFile("2.png");
            pictureBox6.Image = Image.FromFile("3.png");
            pictureBox7.Image = Image.FromFile("1.png");
            pictureBox8.Image = Image.FromFile("2.png");

            pictureBox9.Image = Image.FromFile("3.png");
            pictureBox10.Image = Image.FromFile("1.png");
            pictureBox11.Image = Image.FromFile("2.png");
            pictureBox12.Image = Image.FromFile("3.png");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (credits >= bet || timer1.Enabled)
            {
                Rolling();
                if (timer1.Enabled)
                {
                    timer1.Stop();
                    Pay();
                }
                else
                {
                    credits -= bet;
                    creditLabel.Text = "Credits: " + credits.ToString();
                    timer1.Start();
                }

                total = 0;

            }

        }

        private void Connected3(int px)
        {
            if (px == 1) total = total + bet * 2;

            if (px == 2) total = total + bet * 1.5;

            if (px == 3) total = total + bet * 1;

            if (px == 4) total = total + bet * 0.5;

            //if (p1 == 5) total = total + bet;

            //if (p1 == 6) total = total + bet;

            //if (p1 == 7) total = total + bet;

            //if (p1 == 8) total = total + bet;

            //if (p1 == 9) total = total + bet;

            //if (p1 == 10) total = total + bet;

            //if (p1 == 11) total = total + bet;

            //if (p1 == 12) total = total + bet;
        }
        private void Connected4(int px)
        {
            if (px == 1) total = total + bet * 5;

            if (px == 2) total = total + bet * 3;

            if (px == 3) total = total + bet * 2;

            if (px == 4) total = total + bet * 1;

            //if (p1 == 5) total = total + bet;

            //if (p1 == 6) total = total + bet;

            //if (p1 == 7) total = total + bet;

            //if (p1 == 8) total = total + bet;

            //if (p1 == 9) total = total + bet;

            //if (p1 == 10) total = total + bet;

            //if (p1 == 11) total = total + bet;

            //if (p1 == 12) total = total + bet;
        }
        private void ZigZag(int px)
        {
            if (px == 1) total = total + bet * 6;

            if (px == 2) total = total + bet * 5;

            if (px == 3) total = total + bet * 4;

            if (px == 4) total = total + bet * 3;

            //if (p1 == 5) total = total + bet;

            //if (p1 == 6) total = total + bet;

            //if (p1 == 7) total = total + bet;

            //if (p1 == 8) total = total + bet;

            //if (p1 == 9) total = total + bet;

            //if (p1 == 10) total = total + bet;

            //if (p1 == 11) total = total + bet;

            //if (p1 == 12) total = total + bet;
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
                        Connected4(px);
                        connect3 = false;
                    }


                }

                if (connect3) // povika funkcija za da isplati 3 spoeni
                {
                    Connected3(px);

                }

                px = 0;
                couter = 1;
                connect3 = false;
            }

            // for zig-zag 4 connections :
            if (p[0] == p[5] & p[10] == p[7] & p[5] == p[10] & p[0]!=5)
                ZigZag(p[0]);
            if (p[1] == p[4] & p[6] == p[11] & p[4] == p[6] & p[1] != 5)
                ZigZag(p[1]);
            if (p[2] == p[5] & p[8] == p[7] & p[5] == p[8] & p[2] != 5)
                ZigZag(p[2]);
            if (p[3] == p[6] & p[9] == p[4] & p[6] == p[9] & p[3]!=5)
                ZigZag(p[3]);

            credits = credits + total;


            WinLabel.Text = "Win: " + total.ToString();
            creditLabel.Text = "Credits: " + credits.ToString();
            BetLabel.Text = "Bet: " + bet.ToString();
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
                }
            }


            //p1 = Randomizer.getRand(1, 5);
            //p2 = Randomizer.getRand(1, 5);
            //p3 = Randomizer.getRand(1, 5);
            //p4 = Randomizer.getRand(1, 5);

            //p5 = Randomizer.getRand(1, 5);
            //p6 = Randomizer.getRand(1, 5);
            //p7 = Randomizer.getRand(1, 5);
            //p8 = Randomizer.getRand(1, 5);

            //p9 = Randomizer.getRand(1, 5);
            //p10 = Randomizer.getRand(1, 5);
            //p11 = Randomizer.getRand(1, 5);
            //p12 = Randomizer.getRand(1, 5);

            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = Image.FromFile(p[0].ToString() + ".png");
            if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
            pictureBox2.Image = Image.FromFile(p[1].ToString() + ".png");
            if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
            pictureBox3.Image = Image.FromFile(p[2].ToString() + ".png");
            if (pictureBox4.Image != null) pictureBox4.Image.Dispose();
            pictureBox4.Image = Image.FromFile(p[3].ToString() + ".png");

            if (pictureBox5.Image != null) pictureBox5.Image.Dispose();
            pictureBox5.Image = Image.FromFile(p[4].ToString() + ".png");
            if (pictureBox6.Image != null) pictureBox6.Image.Dispose();
            pictureBox6.Image = Image.FromFile(p[5].ToString() + ".png");
            if (pictureBox7.Image != null) pictureBox7.Image.Dispose();
            pictureBox7.Image = Image.FromFile(p[6].ToString() + ".png");
            if (pictureBox8.Image != null) pictureBox8.Image.Dispose();
            pictureBox8.Image = Image.FromFile(p[7].ToString() + ".png");

            if (pictureBox9.Image != null) pictureBox9.Image.Dispose();
            pictureBox9.Image = Image.FromFile(p[8].ToString() + ".png");
            if (pictureBox10.Image != null) pictureBox10.Image.Dispose();
            pictureBox10.Image = Image.FromFile(p[9].ToString() + ".png");
            if (pictureBox11.Image != null) pictureBox11.Image.Dispose();
            pictureBox11.Image = Image.FromFile(p[10].ToString() + ".png");
            if (pictureBox12.Image != null) pictureBox12.Image.Dispose();
            pictureBox12.Image = Image.FromFile(p[11].ToString() + ".png");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rolling();
            if (musicImage.Tag.Equals("unmute.png") && player.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                player.URL = "OogwayAscends.mp3";
                player.controls.play();
            }
        }

        private void BetAmountNumeric_ValueChanged(object sender, EventArgs e)
        {
            if (BetAmountNumeric.Value > Convert.ToInt32(credits))
            {
                BetAmountNumeric.Value = Convert.ToInt32(credits);
            }
            if (BetAmountNumeric.Value >= 5)
            {
                bet = Convert.ToInt64(BetAmountNumeric.Value);
            }

        }


        private void musicImage_Click(object sender, EventArgs e)
        {
            if (musicImage.Tag.Equals("mute.png"))
            {
                musicImage.Image = Image.FromFile("unmute.png");
                musicImage.Tag = "unmute.png";
                player.URL = "OogwayAscends.mp3";
                player.controls.play();
            }
            else
            {
                musicImage.Image = Image.FromFile("mute.png");
                musicImage.Tag = "mute.png";
                player.controls.stop();
            }
        }
    }
}
