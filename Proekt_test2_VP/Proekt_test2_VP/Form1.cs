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

        public Point p1 { get; set; } 
        public Point p2 { get; set; }
        public List<PictureBox> PictureBoxes { get; set; }

        List<PictureBox> winningBoxes = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            Randomizer Randomizer = new Randomizer();
            DoubleBuffered = true;
            musicImage.Image = Image.FromFile("mute.png");
            musicImage.Tag = "mute.png";
            creditLabel.Text = "Credits: " + player.Credits.ToString();

            PictureBoxes = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                                                pictureBox5, pictureBox6, pictureBox7, pictureBox8,
                                                pictureBox9, pictureBox10, pictureBox11, pictureBox12};
        }

        public static int[] p = new int[12];

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(PictureBox pb in PictureBoxes)
            {
                pb.Image = Image.FromFile("Pictures/" + Randomizer.getRand(1,9).ToString() + ".png");
            }

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

        public void DrawWinningLine(PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Black, 3);
            e.Graphics.DrawLine(blackPen,p1,p2);

            Invalidate(true);
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen blackPen = new Pen(Color.Red, 3);
            for (int i = 1; i < winningBoxes.Count; i++)
            {
                Graphics g = winningBoxes[i].CreateGraphics();

                e.Graphics.DrawLine(blackPen, winningBoxes[i-1].Location, winningBoxes[i].Location);
                Point p = winningBoxes[i - 1].Location;
                Size s = winningBoxes[i - 1].Size;
                Rectangle r = new Rectangle(p.X-s.Width/2,p.Y-s.Height/2,s.Width,s.Height );
                e.Graphics.DrawRectangle(blackPen, r);
            }
           
        }
        public void draw()
        {
            Pen blackPen = new Pen(Color.Red, 3);
            for (int i = 1; i < winningBoxes.Count; i++)
            {
                Graphics g = winningBoxes[i].CreateGraphics();

                g.DrawLine(blackPen, winningBoxes[i - 1].Location, winningBoxes[i].Location);
                Point p = winningBoxes[i - 1].Location;
                Size s = winningBoxes[i - 1].Size;
                Rectangle r = new Rectangle(p.X - s.Width / 2, p.Y - s.Height / 2, s.Width, s.Height);
                g.DrawRectangle(blackPen, r);
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
                        winningBoxes.Add(PictureBoxes[j]); // locations for the winning picture boxes
                    }
                    else
                    {
                        break;
                    }
                    if (couter == 3)
                    {
                        draw();
                        Invalidate();
                        connect3 = true; // minimum 3 se konektiraat
                    }
                    if (couter == 4)
                    {
                        draw();
                        Invalidate();
                        player.getConnected4(px);
                        connect3 = false;
                    }


                }

                if (connect3) // povika funkcija za da isplati 3 spoeni
                {
                    draw();
                    Invalidate();
                    player.getConnected3(px);

                }

                px = 0;
                couter = 1;
                connect3 = false;


                winningBoxes.Clear();
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

            // check if 3 scrolls are present...
            couter = 0;
            for(int i = 0; i < 12; i++)
            {
                if (p[i] == 8)
                {
                    couter++;
                }
            }
            // 2te podole treba da se skrojat vo posebna fkcija
            if (couter == 3) // recieve 10 spins
            {
                
                player.SpinsLeft = 10;
                musicPlayer.controls.pause();
                BonusSpins newBonusSpins = new BonusSpins(player);
                this.Hide();
                newBonusSpins.ShowDialog();
                this.Close();
            }
            if(couter == 4) // recieve 15 spins
            {
                player.SpinsLeft = 15;
                musicPlayer.controls.pause();
                BonusSpins newBonusSpins = new BonusSpins(player);
                this.Hide();
                newBonusSpins.ShowDialog();
                this.Close();
            }

            player.getCredit();

            WinLabel.Text = "Win: " + player.Total.ToString();
            creditLabel.Text = "Credits: " + player.Credits.ToString();
            BetLabel.Text = "Bet: " + player.Bet.ToString();

            Invalidate(true);
        }

        public int Rigged_lol(int i)
        {
            // Total: 9 images...
            // 10% chance to get 1.png
            if (i < 10)
            {
                i = 1;
            }
            // 10% chance to get 2.png
            else if (i < 20)
            {
                i = 2;
            }
            // 15% chance to get 3.png
            else if (i < 35)
            {
                i = 3;
            }
            // 15% chance to get 4.png
            else if (i < 50)
            {
                i = 4;
            }
            // 15% chance to get 5.png
            else if (i < 65)
            {
                i = 5;
            }
            // 15% chance to get 6.png
            else if (i < 80)
            {
                i = 6;
            }
            // 10% chance to get 7.png
            else if (i < 90)
            {
                i = 7;
            }
            // 10% chance to get 8.png
            else if (i < 100)
            {
                i = 8;
            }
            return i;
        }

        private void Rolling()
        {
            for (int i = 0; i < 12; i++)
            {
                p[i] = Randomizer.getRand(0, 100);

                p[i] = Rigged_lol(p[i]);

                // ova e proverka da nema poveke od eden scroll vo ista kolona
                if (i >= 4)
                {
                    if (p[i] == p[i - 4] & p[i] == 8)
                    {
                        p[i] = Randomizer.getRand(0, 90);
                        p[i] = Rigged_lol(p[i]);
                    }
                    if(i >= 8)
                    {
                        if (p[i] == p[i - 8] & p[i] == 8)
                        {
                            p[i] = Randomizer.getRand(0, 90);
                            p[i] = Rigged_lol(p[i]);
                        }
                    }
                }

            }
            int t=0;
            foreach(PictureBox pb in PictureBoxes)
            {
                if (pb.Image != null) pb.Image.Dispose();
                pb.Image = Image.FromFile("Pictures/" + p[t].ToString() + ".png");
                t++;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Rolling();
            if (musicImage.Tag.Equals("unmute.png") && musicPlayer.playState == WMPLib.WMPPlayState.wmppsPaused)
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
                trackBar1.Value = 5;
                musicImage.Image = Image.FromFile("unmute.png");
                musicImage.Tag = "unmute.png";
                musicPlayer.URL = "OogwayAscends.mp3";
                musicPlayer.controls.play();
            }
            else
            {
                trackBar1.Value = 0;
                musicImage.Image = Image.FromFile("mute.png");
                musicImage.Tag = "mute.png";
                musicPlayer.controls.pause();
            }
            musicPlayer.settings.volume = trackBar1.Value*10;
        }

        private void FeatureButton_Click(object sender, EventArgs e)
        {
            player.SpinsLeft = 10;
            musicPlayer.controls.pause();
            BonusSpins newBonusSpins = new BonusSpins(player);
            this.Hide();
            newBonusSpins.ShowDialog();
            this.Close();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            musicPlayer.settings.volume = trackBar1.Value*10;
        }

        private void musicImage_MouseHover(object sender, EventArgs e)
        {
            trackBar1.Visible = true;
        }

        private void Form1_MouseEnter(object sender, EventArgs e)
        {
            trackBar1.Visible = false;
        }

        
    }
}
