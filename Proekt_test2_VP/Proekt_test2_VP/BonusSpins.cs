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
        Dictionary<string, List<PictureBox>> winningBoxes { get; set; }

        public BonusSpins(PlayerClass Player)
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
            musicImage.Image = Image.FromFile("Pictures/mute.png");
            musicImage.Tag = "mute.png";
            player = Player;
            creditLabel.Text = "Credits: " + player.Credits.ToString();
            FreeSpinsLabel.Text = "Free spins left: " + player.SpinsLeft.ToString();
            BetAmountNumeric.Value = Convert.ToDecimal(player.Bet);
            PictureBoxes = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                                                pictureBox5, pictureBox6, pictureBox7, pictureBox8,
                                                pictureBox9, pictureBox10, pictureBox11, pictureBox12};
            winningBoxes = new Dictionary<string, List<PictureBox>>()
            {
                { "straight", new List<PictureBox>() {  } },
                { "down", new List<PictureBox>() {  } },
                { "up", new List<PictureBox>() {  } },
                { "V", new List<PictureBox>() {  } },
                { "^", new List<PictureBox>() {  } },
                { "scroll",  new List<PictureBox>() { } }, 
                { "bonus",  new List<PictureBox>() {  } }
            };

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
                    SpinButton.Enabled = false;
                    WonBoxesToNormal();
                    SpinButton.Text = "Stop";
                    creditLabel.Text = "Credits: " + player.Credits.ToString();
                    timer1.Start();
                    player.SpinsLeft--;
                    FreeSpinsLabel.Text = "Free spins left: " + player.SpinsLeft.ToString();
                }
                else
                {
                    player.getBonusCredit();
                    SpinButton.Text = "Spin";
                    Form1 form = new Form1();
                    form.player.Credits = player.Credits;
                    form.player.Bet = player.Bet;
                    this.Hide();
                    form.ShowDialog();
                    this.Close();
                    player.Total = 0;
                    player.TotalWin = 0;
                }
            player.Total = 0;
        }

        private void Pay()
        {
            // GET RESULTS FROM PAYTABLE
            // CHECK IF 1, 2, 3 or 4 OCCURANCES
            // for 4 connections && for 3 connections:
            if (p[0] == p[1] & p[1] == p[2] & p[0] != 8) // 1 red..
            {

                winningBoxes["straight"].Add(PictureBoxes[0]);
                winningBoxes["straight"].Add(PictureBoxes[1]);
                winningBoxes["straight"].Add(PictureBoxes[2]);

                if (p[2] == p[3]) // proverka za 4-to
                {
                    //winningBoxes.Add("straight", new List<PictureBox> { PictureBoxes[0], PictureBoxes[1], PictureBoxes[2],PictureBoxes[3] });

                    winningBoxes["straight"].Add(PictureBoxes[3]);
                    player.getConnected4(p[0]);
                }
                else
                {
                    //winningBoxes.Add("straight", new List<PictureBox> { PictureBoxes[0], PictureBoxes[1], PictureBoxes[2] });
                    player.getConnected3(p[0]);
                }

            }
            if (p[4] == p[5] & p[5] == p[6] & p[4] != 8) // 2 red..
            {
                winningBoxes["straight"].Add(PictureBoxes[4]);
                winningBoxes["straight"].Add(PictureBoxes[5]);
                winningBoxes["straight"].Add(PictureBoxes[6]);
                if (p[6] == p[7]) // proverka za 4-to
                {
                    //winningBoxes.Add("straight", new List<PictureBox> { PictureBoxes[4], PictureBoxes[5], PictureBoxes[6],PictureBoxes[7] });

                    winningBoxes["straight"].Add(PictureBoxes[7]);
                    player.getConnected4(p[0]);
                }
                else
                {
                    //winningBoxes.Add("straight", new List<PictureBox> { PictureBoxes[4], PictureBoxes[5], PictureBoxes[6] });
                    player.getConnected3(p[0]);
                }
            }

            if (p[8] == p[9] & p[9] == p[10] & p[8] != 8) // 3 red..
            {
                winningBoxes["straight"].Add(PictureBoxes[8]);
                winningBoxes["straight"].Add(PictureBoxes[9]);
                winningBoxes["straight"].Add(PictureBoxes[10]);
                if (p[10] == p[11]) // proverka za 4-to
                {
                    //winningBoxes.Add("straight", new List<PictureBox> { PictureBoxes[8], PictureBoxes[9], PictureBoxes[10], PictureBoxes[11] });

                    winningBoxes["straight"].Add(PictureBoxes[11]);
                    player.getConnected4(p[0]);
                }
                else
                {
                    //winningBoxes.Add("straight", new List<PictureBox> { PictureBoxes[8], PictureBoxes[9], PictureBoxes[10] });
                    player.getConnected3(p[0]);
                }
            }

            // for zig-zag 4 connections :
            if (p[0] == p[5] & p[10] == p[7] & p[5] == p[10] & p[0] != 8)
            {
                winningBoxes["down"].Add(PictureBoxes[0]);
                winningBoxes["down"].Add(PictureBoxes[5]);

                winningBoxes["V"].Add(PictureBoxes[10]);

                winningBoxes["up"].Add(PictureBoxes[7]);

                player.getConnected4(p[0]);
            }
            if (p[1] == p[4] & p[6] == p[11] & p[4] == p[6] & p[1] != 8)
            {
                winningBoxes["down"].Add(PictureBoxes[6]);
                winningBoxes["down"].Add(PictureBoxes[11]);

                winningBoxes["^"].Add(PictureBoxes[1]);

                winningBoxes["up"].Add(PictureBoxes[4]);

                player.getConnected4(p[1]);
            }
            if (p[2] == p[5] & p[8] == p[7] & p[5] == p[8] & p[2] != 8)
            {
                winningBoxes["down"].Add(PictureBoxes[7]);

                winningBoxes["^"].Add(PictureBoxes[2]);

                winningBoxes["up"].Add(PictureBoxes[5]);
                winningBoxes["up"].Add(PictureBoxes[8]);

                player.getConnected4(p[2]);
            }
            if (p[3] == p[6] & p[9] == p[4] & p[6] == p[9] & p[3] != 8)
            {
                winningBoxes["down"].Add(PictureBoxes[4]);

                winningBoxes["V"].Add(PictureBoxes[9]);

                winningBoxes["up"].Add(PictureBoxes[3]);
                winningBoxes["up"].Add(PictureBoxes[6]);

                player.getConnected4(p[3]);
            }
            // check if 3 scrolls are present...
            int counter = 0;
            int bonuscounter = 0;
            for (int i = 0; i < 12; i++)
            {
                if (p[i] == 8)
                {
                    winningBoxes["scroll"].Add(PictureBoxes[i]);
                    counter++;
                }
                if(p[i] == player.BonusPicture)
                {
                    winningBoxes["bonus"].Add(PictureBoxes[i]);
                    bonuscounter++;
                }
            }
            // 2te podole treba da se skrojat vo posebna fkcija
            if (counter == 3) // recieve 10 spins
            {
                player.SpinsLeft += 10;
            }
            else if (counter == 4) // recieve 15 spins
            {
                player.SpinsLeft += 15;
            }
            else
            {
                winningBoxes["scroll"].Clear();
            }
            if(bonuscounter >= 2)
            {
                player.getBonus(bonuscounter);
            }
            else
            {
                winningBoxes["bonus"].Clear();
            }
            WonBoxes();
            player.getBonusTotal();

            WinLabel.Text = "Win: " + player.Total.ToString();
            creditLabel.Text = "Credits: " + player.Credits.ToString();
            BetLabel.Text = "Bet: " + player.Bet.ToString();
            FreeSpinsLabel.Text = "Free spins left: " + player.SpinsLeft.ToString();
            TotalWinLabel.Text = "Total Win: " + player.TotalWin.ToString();
        }
        public void WonBoxes()
        {
            //foreach (List<PictureBox> li in winningBoxes.Values)
            //{
            //    foreach (PictureBox pb in li)
            //    {
            //        pb.BackgroundImage = Image.FromFile("win-img.png");
            //    }
            //}
            foreach(KeyValuePair<string,List<PictureBox>> kvp in winningBoxes)
            {
                    foreach (PictureBox pb in kvp.Value)
                    {
                        if (kvp.Key.Equals("bonus") || kvp.Key.Equals("scroll")){
                           pb.BackgroundImage = Image.FromFile("Pictures/win-img-purple.png");
                    }
                        else
                        {
                            pb.BackgroundImage = Image.FromFile("Pictures/win-img.png");
                        }
                    }
            }
            Invalidate(true);
        }
        public void WonBoxesToNormal()
        {
            foreach (List<PictureBox> kvp in winningBoxes.Values)
            {
                foreach (PictureBox pb in kvp)
                {
                    pb.BackColor = Color.Transparent;
                    pb.BackgroundImage = null;
                    pb.BorderStyle = BorderStyle.None;
                }
            }

            // winningBoxes.Clear() but keeping the keys
            winningBoxes["straight"].Clear();
            winningBoxes["down"].Clear();
            winningBoxes["up"].Clear();
            winningBoxes["^"].Clear();
            winningBoxes["V"].Clear();
            winningBoxes["bonus"].Clear();
            winningBoxes["scroll"].Clear();

        }

        private void Rolling()
        {
            for (int i = 0; i < 12; i++)
            { 
                p[i] = random.Rigged_lol(0, 105);
                if (p[i] == 9) p[i] = player.BonusPicture;

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
            SpinButton.Enabled = true;
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
                musicImage.Image = Image.FromFile("Pictures/unmute.png");
                musicImage.Tag = "unmute.png";
                musicPlayer.URL = "KungFuFighting.mp3";
                musicPlayer.controls.play();
            }
            else
            {
                musicImage.Image = Image.FromFile("Pictures/mute.png");
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

        private void BonusSpins_Paint(object sender, PaintEventArgs e)
        {
            // -, down, up, v, ^

            if (winningBoxes.TryGetValue("straight",out List<PictureBox> straight))
            {
                foreach(PictureBox pb in straight)
                {
                    Graphics g = pb.CreateGraphics();

                    g.DrawLine(
                        new Pen(Color.Blue, 2f),
                        new Point(0, pb.Size.Height / 2),
                        new Point(pb.Size.Width, pb.Size.Height / 2));

                    g.Dispose();
                    //elipse

                    //g.DrawEllipse(
                    //    new Pen(Color.Red, 4f),
                    //    5, 5, pb.Size.Width - 20, pb.Size.Height - 20);


                }

            }

            if (winningBoxes.TryGetValue("down", out List<PictureBox> down))
            {
                foreach (PictureBox pb in down)
                {
                    Graphics g = pb.CreateGraphics();

                    g.DrawLine(
                        new Pen(Color.White, 2f),
                        new Point(0, 0),
                        new Point(pb.Size.Width, pb.Size.Height));

                    g.Dispose();
                    //elipse

                    //g.DrawEllipse(
                    //    new Pen(Color.Red, 4f),
                    //    5, 5, pb.Size.Width - 20, pb.Size.Height - 20);

                }
            }

            if (winningBoxes.TryGetValue("up", out List<PictureBox> up))
            {
                foreach (PictureBox pb in up)
                {
                    Graphics g = pb.CreateGraphics();

                    g.DrawLine(
                        new Pen(Color.White, 2f),
                        new Point(0, pb.Size.Height),
                        new Point(pb.Size.Width, 0));

                    g.Dispose();
                    //elipse

                    //g.DrawEllipse(
                    //    new Pen(Color.Red, 4f),
                    //    5, 5, pb.Size.Width - 20, pb.Size.Height - 20);

                }
            }

            if (winningBoxes.TryGetValue("V", out List<PictureBox> v))
            {
                foreach (PictureBox pb in v)
                {
                    Graphics g = pb.CreateGraphics();

                    g.DrawLine(
                        new Pen(Color.White, 2f),
                        new Point(0, 0), 
                        new Point(pb.Size.Width / 2, pb.Size.Height / 2));

                    g.DrawLine(
                        new Pen(Color.White, 2f),
                        new Point(pb.Size.Width / 2, pb.Size.Height / 2),
                        new Point(pb.Size.Width, 0));

                    g.Dispose();
                    //elipse

                    //g.DrawEllipse(
                    //    new Pen(Color.Red, 4f),
                    //    5, 5, pb.Size.Width - 20, pb.Size.Height - 20);

                }
            }

            if (winningBoxes.TryGetValue("^", out List<PictureBox> unV))
            {
                foreach (PictureBox pb in unV)
                {
                    Graphics g = pb.CreateGraphics();

                    g.DrawLine(
                        new Pen(Color.White, 2f),
                        new Point(0, pb.Size.Height),
                        new Point(pb.Size.Width / 2, pb.Size.Height / 2));

                    g.DrawLine(
                        new Pen(Color.White, 2f),
                        new Point(pb.Size.Width / 2, pb.Size.Height / 2),
                        new Point(pb.Size.Width, pb.Size.Height));

                    g.Dispose();
                    //elipse
                    //g.DrawEllipse(
                    //    new Pen(Color.Red, 4f),
                    //    5, 5, pb.Size.Width - 20, pb.Size.Height - 20);


                }
            }
        }
    }
}
    


           
           



