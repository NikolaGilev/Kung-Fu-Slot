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
        Randomizer random = new Randomizer();

        public List<PictureBox> PictureBoxes { get; set; }
        public BonusSpins(PlayerClass Player)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            musicImage.Image = Image.FromFile("mute.png");
            musicImage.Tag = "mute.png";
            player = Player;
            creditLabel.Text = "Credits: " + player.Credits.ToString();
            FreeSpinsLabel.Text = "Free spins left: " + player.SpinsLeft.ToString();
            BetAmountNumeric.Value = Convert.ToDecimal(player.Bet);
            PictureBoxes = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                                                pictureBox5, pictureBox6, pictureBox7, pictureBox8,
                                                pictureBox9, pictureBox10, pictureBox11, pictureBox12};

        }

        public static int[] p = new int[12];


        private void BonusSpins_Load(object sender, EventArgs e)
        {
            foreach (PictureBox pb in PictureBoxes)
            {
                pb.Image = Image.FromFile("Pictures/" + random.getRand(1, 9).ToString() + ".png");
            }

            creditLabel.Text = "Credits: " + player.Credits.ToString();
            FreeSpinsLabel.Text = "Free spins left: " + player.SpinsLeft.ToString();
        }

        private void SpinButton_Click(object sender, EventArgs e)
        {
                if (timer1.Enabled)
                {
                    SpinButton.Text = "Spin";
                    timer1.Stop();
                    Pay();
                }
                else if(player.SpinsLeft>0)
                {

                    SpinButton.Text = "Stop";
                    creditLabel.Text = "Credits: " + player.Credits.ToString();
                    timer1.Start();
                    player.SpinsLeft--;
                    FreeSpinsLabel.Text = "Free spins left: " + player.SpinsLeft.ToString();
                }
                else
                {
                    SpinButton.Text = "Spin";
                    Form1 form = new Form1();
                    form.player.Credits = player.Credits;
                    form.player.Bet = player.Bet;
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                    player.Total = 0;
                }

                player.Total = 0;
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

            // check if 3 scrolls are present...
            couter = 0;
            for (int i = 0; i < 12; i++)
            {
                if (p[i] == 8)
                {
                    couter++;
                }
            }
            // 2te podole treba da se skrojat vo posebna fkcija
            if (couter == 3) // recieve 10 spins
            {

                player.SpinsLeft += 10;
            }
            if (couter == 4) // recieve 15 spins
            {
                player.SpinsLeft += 15;
            }

            player.getCredit();


            WinLabel.Text = "Win: " + player.Total.ToString();
            creditLabel.Text = "Credits: " + player.Credits.ToString();
            BetLabel.Text = "Bet: " + player.Bet.ToString();
            FreeSpinsLabel.Text = "Free spins left: " + player.SpinsLeft.ToString();
        }

        private void Rolling()
        {
            for (int i = 0; i < 12; i++)
            { 
                p[i] = random.Rigged_lol(0, 100);

                // ova e proverka da nema poveke od eden scroll vo ista kolona
                if (i >= 4)
                {
                    if (p[i] == p[i - 4] & p[i] == 8)
                    {
                        p[i] = random.Rigged_lol(0, 90);
                    }
                    if (i >= 8)
                    {
                        if (p[i] == p[i - 8] & p[i] == 8)
                        {
                            p[i] = random.Rigged_lol(0, 90);
                        }
                    }
                }

            }
            int t = 0;
            foreach (PictureBox pb in PictureBoxes)
            {
                if (pb.Image != null) pb.Image.Dispose();
                pb.Image = Image.FromFile("Pictures/" + p[t].ToString() + ".png");
                t++;
            }

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
                musicImage.Image = Image.FromFile("unmute.png");
                musicImage.Tag = "unmute.png";
                musicPlayer.URL = "KungFuFighting.mp3";
                musicPlayer.controls.play();
            }
            else
            {
                musicImage.Image = Image.FromFile("mute.png");
                musicImage.Tag = "mute.png";
                musicPlayer.controls.pause();
            }
            musicPlayer.settings.volume = trackBar1.Value * 10;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            musicPlayer.settings.volume = trackBar1.Value * 10;
        }

        private void musicImage_MouseHover(object sender, EventArgs e)
        {
            if (musicImage.Tag.Equals("unmute.png"))
                trackBar1.Visible = true;
        }

        private void BonusSpins_MouseEnter(object sender, EventArgs e)
        {
            trackBar1.Visible = false;
        }
    }
}
    


           
           



