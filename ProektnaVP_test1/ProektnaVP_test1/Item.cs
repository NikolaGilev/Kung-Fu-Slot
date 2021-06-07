using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektnaVP_test1
{
    public class Item
    {
        public Point Center { get; set; }
        public Random random { get; set; }
        public int squareValue { get; set; }
        public Image image { get; set; }

        public Item(Point c,Image img) 
        {
            Center = c;
            random = new Random();
            squareValue = random.Next();
            image = resizeImage(img, new Size(100, 100));

        }

        public void draw(Graphics g)
        {
            g.DrawImage(image, Center);
        }

        public void move() // Reroll
        {
            Center = new Point(Center.X,Center.Y+10);
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }



    }
}
