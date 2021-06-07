using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProektnaVP_test1
{
    public class Scene
    {
        public List<Item> items { get; set; }


        public Scene()
        {
            items = new List<Item>();

        }

        public void AddItem(Point p)
        {
            items.Add(new Item(p,Image.FromFile(@"\Images\background_VP.jpg")));
        }

        public void draw(Graphics g)
        {
            foreach (Item i in items)
            {
                i.draw(g);
            }
        }
        
        public void move(int h)
        {
            for (int i = items.Count - 1; i >= 0; i--)
            {
                items[i].move();
                if (items[i].Center.Y > h)
                {
                    items.RemoveAt(i);
                }
            }
        }



    }
}
