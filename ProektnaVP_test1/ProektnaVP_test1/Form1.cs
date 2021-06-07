using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProektnaVP_test1
{
    public partial class Form1 : Form
    {
        Scene scene;
        int timer;
        public Form1()
        {
            InitializeComponent();
            scene = new Scene();
            DoubleBuffered = true;

            timer1.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            this.BackgroundImage = (Image)(new Bitmap(Image.FromFile(@"~\images\background_VP.jpg"), new Size(this.Width, this.Height)));
            scene.draw(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 200; i < this.Width-200; i += 100)
            {
                for (int j = 50; j < this.Height-300; j += 100)
                    scene.AddItem(new Point(i, j));
            }
            Invalidate();
        }

        private void spinbtn_Click(object sender, EventArgs e)
        {
            timer = 0;
            Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scene.move(this.Height);
            
            Invalidate(true);
        }
    }
}
