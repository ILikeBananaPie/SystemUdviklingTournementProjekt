using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TournementAndAnalysis
{
    class Dice
    {
        private Random rnd;

        public Dice()
        {

        }

        public int Roll()
        {
            return rnd.Next(1, 6);
        }

        public int StaticRoll(int a)
        {
            return a;
        }
    }
}
