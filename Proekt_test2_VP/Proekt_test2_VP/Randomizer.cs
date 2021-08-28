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
            // 23% chance to get 1.png
            if (i < 25)
            {
                i = 1;
            }
            // 4% chance to get 2.png
            else if (i < 30)
            {
                i = 2;
            }
            // 14% chance to get 3.png
            else if (i < 35)
            {
                i = 3;
            }
            // 14% chance to get 4.png
            else if (i < 50)
            {
                i = 4;
            }
            // 14% chance to get 5.png
            else if (i < 65)
            {
                i = 5;
            }
            // 14% chance to get 6.png
            else if (i < 80)
            {
                i = 6;
            }
            // 9% chance to get 7.png
            else if (i < 90)
            {
                i = 7;
            }
            // 9% chance to get 8.png
            else if (i < 100)
            {
                i = 8;
            }
            // 4% chance to get bonus picture
            else if (i < 105)
            {
                i = 9;
            }
            return i;
        }

    }
}
