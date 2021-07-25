using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proekt_test2_VP
{
    public class Randomizer
    {
        private static Random random;
        public Randomizer()
        {
            random = new Random();
        }

        public int getRand(int min, int max)
        {
            return random.Next(min, max);
        }

        public int Rigged_lol(int min, int max)
        {
            int i = getRand(min, max);
            // Total: 9 images...
            // 10% chance to get 1.png
            if (i < 50)
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

    }
}
