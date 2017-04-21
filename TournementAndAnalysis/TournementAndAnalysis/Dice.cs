using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            foreach (Button btn in TournementHolder.Instance.buttons)
            {
                if (btn.Name.Contains("Hold") && btn.Name.Contains("Ny"))
                {
                    return 0;
                }
                else
                {
                    return rnd.Next(1, 6);
                }
            }
            return rnd.Next(1, 6);
            
        }

        public int StaticRoll(int a)
        {
            return a;
        }
    }
}
