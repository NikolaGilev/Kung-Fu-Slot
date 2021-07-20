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

        public static int getRand(int min, int max)
        {
            return random.Next(min, max);
        }

    }
}
