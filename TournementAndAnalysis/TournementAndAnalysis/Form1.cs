using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournementAndAnalysis
{
    public partial class Form1:Form
    {
        private Button elim;
        private Button cup;
        private Graphics dc;
        private Font f;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            elim = new Button();
            elim.Text = "Elimination";
            Controls.Add(elim);

            cup = new Button();
            cup.Text = "Cup";
            Controls.Add(cup);

            timer1.Enabled = true;
            TestMethod();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            elim.Location = new Point(Width / 3 - elim.Width / 2, Height / 2 - elim.Height / 2);
            cup.Location = new Point(Width - Width / 3 - cup.Width / 2, Height / 2 - cup.Height / 2);
        }

        public int TestMethod()
        {
            return 1;
        }

        public int RoundResult(string str)
        {
            Dice myDice = new Dice();
            int a = myDice.Roll();
            int b = myDice.Roll();

            if (str == "elim")
            {
                if (a == b)
                {
                    RoundResult("elim");
                }
            }
            else
            {
                if (a == b)
                {
                    return 0;
                }
            }

            if (a > b)
            {
                return 1;
            }
            else return 2;

        }

    }
}
