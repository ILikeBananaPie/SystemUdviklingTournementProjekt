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
        private Random rnd;

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

        public int ElimRound()
        {
            return rnd.Next(1);
        }

        public int LeagueRound()
        {
            return rnd.Next(0, 3);
        }

    }
}
