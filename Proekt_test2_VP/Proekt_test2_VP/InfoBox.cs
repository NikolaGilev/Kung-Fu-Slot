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
    public partial class InfoBox : Form
    {
        public List<PictureBox> PictureBoxes { get; set; }
        public List<PictureBox> Scrolls { get; set; }

        public List<Label> Labels { get; set; }
        public PlayerClass player = new PlayerClass();
        VScrollBar vScrollBar1 = new VScrollBar();

        public InfoBox(PlayerClass Player)
        {
            InitializeComponent();
            DoubleBuffered = true;
            PictureBoxes = new List<PictureBox> { pictureBox1, pictureBox2, pictureBox3, pictureBox4,
                                                pictureBox5, pictureBox6, pictureBox7, pictureBox8,
                                                pictureBox9, pictureBox10, pictureBox11, pictureBox12,
                                                pictureBox13, pictureBox14, pictureBox15, pictureBox16,
                                                pictureBox17,pictureBox18, pictureBox19, pictureBox20,
                                                pictureBox21, pictureBox22, pictureBox23 };
            Labels = new List<Label> { label1, label2, label3, label4, label5, label6, label7, label8,
                                        label9, label10, label11, label12, label13, label14};

            Scrolls = new List<PictureBox> { pictureBox24, pictureBox25, pictureBox26};

            player = Player; 
        }
        private void InfoBox_Load(object sender, EventArgs e)
        {
            // paint images to pictureboxes
            for (int i = 0; i < PictureBoxes.Count; i++)
            {
                if (i < 8)
                {
                    PictureBoxes[i].Image = Image.FromFile("Pictures/" + (i + 1) + ".png");
                    Labels[i].Text = "3 | " + player.calculatePayout3(i + 1) + "\n";
                    Labels[i].Text += "4 | " + player.calculatePayout4(i + 1);
                }
                else if(i<14)
                {
                    PictureBoxes[i].Image = Image.FromFile("Pictures/" + (i + 1) + ".png");
                    Labels[i].Text = "2 | " + player.calculateBonusPayout(2,i + 1) + "\n";
                    Labels[i].Text += "3 | " + player.calculateBonusPayout(3, i + 1) + "\n";
                    Labels[i].Text += "4 | " + player.calculateBonusPayout(4, i + 1);
                }
                // paint images for payout combinations
                else
                {
                    PictureBoxes[i].Image = Image.FromFile("Pictures/4." + (i - 13) + ".png");
                }
            }

            foreach (PictureBox pb in Scrolls)
            {
                pb.Image = Image.FromFile("Pictures/8.png");
                pb.BackgroundImage = Image.FromFile("Pictures/win-img-purple.png");
            }

            pictureBox27.Image = Image.FromFile("Pictures/buyfeature.png");

        }

    }
}
