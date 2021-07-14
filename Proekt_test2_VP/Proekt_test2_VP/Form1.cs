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
        public static int p1;
        public static int p2;
        public static int p3;
        public static int p4;
        public static int p5;
        public static int p6;
        public static int p7;
        public static int p8;
        public static int p9;
        public static int p10;
        public static int p11;
        public static int p12;

        // CREDIT, TOTAL AND BET
        public static long credits = 100;
        public static long total = 0;
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
            if ( credits >= bet || timer1.Enabled )
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

        private void Pay()
        {
            // GET RESULTS FROM PAYTABLE
            // CHECK IF 1, 2, 3 or 4 OCCURANCES
            if (p1 == 3) total = total + 5;

            if (p1 == 2 & p2 == 2) total = total + 10;
            if (p1 == 3 & p2 == 3) total = total + 10;

            if (p1 == 1 & p2 == 1 & p3 == 1) total = total + 20;
            if (p1 == 2 & p2 == 2 & p3 == 2) total = total + 30;
            if (p1 == 3 & p2 == 3 & p3 == 3) total = total + 50;

            credits = credits + total;


            WinLabel.Text = "Win: " + total.ToString();
            creditLabel.Text = "Credits: " + credits.ToString();
            BetLabel.Text = "Bet: " + bet.ToString();
        }

        private void Rolling()
        {
            p1 = Randomizer.getRand(1, 4);
            p2 = Randomizer.getRand(1, 4);
            p3 = Randomizer.getRand(1, 4);
            p4 = Randomizer.getRand(1, 4);

            p5 = Randomizer.getRand(1, 4);
            p6 = Randomizer.getRand(1, 4);
            p7 = Randomizer.getRand(1, 4);
            p8 = Randomizer.getRand(1, 4);

            p9 = Randomizer.getRand(1, 4);
            p10 = Randomizer.getRand(1, 4);
            p11 = Randomizer.getRand(1, 4);
            p12 = Randomizer.getRand(1, 4);

            if (pictureBox1.Image != null) pictureBox1.Image.Dispose();
            pictureBox1.Image = Image.FromFile(p1.ToString() + ".png");
            if (pictureBox2.Image != null) pictureBox2.Image.Dispose();
            pictureBox2.Image = Image.FromFile(p2.ToString() + ".png");
            if (pictureBox3.Image != null) pictureBox3.Image.Dispose();
            pictureBox3.Image = Image.FromFile(p3.ToString() + ".png");
            if (pictureBox4.Image != null) pictureBox4.Image.Dispose();
            pictureBox4.Image = Image.FromFile(p4.ToString() + ".png");

            if (pictureBox5.Image != null) pictureBox5.Image.Dispose();
            pictureBox5.Image = Image.FromFile(p5.ToString() + ".png");
            if (pictureBox6.Image != null) pictureBox6.Image.Dispose();
            pictureBox6.Image = Image.FromFile(p6.ToString() + ".png");
            if (pictureBox7.Image != null) pictureBox7.Image.Dispose();
            pictureBox7.Image = Image.FromFile(p7.ToString() + ".png");
            if (pictureBox8.Image != null) pictureBox8.Image.Dispose();
            pictureBox8.Image = Image.FromFile(p8.ToString() + ".png");

            if (pictureBox9.Image != null) pictureBox9.Image.Dispose();
            pictureBox9.Image = Image.FromFile(p9.ToString() + ".png");
            if (pictureBox10.Image != null) pictureBox10.Image.Dispose();
            pictureBox10.Image = Image.FromFile(p10.ToString() + ".png");
            if (pictureBox11.Image != null) pictureBox11.Image.Dispose();
            pictureBox11.Image = Image.FromFile(p11.ToString() + ".png");
            if (pictureBox12.Image != null) pictureBox12.Image.Dispose();
            pictureBox12.Image = Image.FromFile(p12.ToString() + ".png");
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
            if(BetAmountNumeric.Value > credits)
            {
                BetAmountNumeric.Value = credits;
            }
            if(BetAmountNumeric.Value >= 5)
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
