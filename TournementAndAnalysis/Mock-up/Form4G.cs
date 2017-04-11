using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mock_up
{
    public partial class Form4G:Form
    {
        private Form4GManipulator frmMan;
        public Button Example1Get { get { return Example1; } }
        public Button Example2Get { get { return Example2; } }
        public Button Example3Get { get { return Example3; } }
        public Button Example4Get { get { return Example4; } }
        public Button TopWinGet { get { return TopWin; } }
        public Button BottomWinGet { get { return BottomWin; } }
        public Button FinalWinnerGet { get { return FinalWinner; } }


        private Graphics dc;
        private Color background;
        private Pen blackPen;
        private Pen redPen;
        private Pen greenPen;

        public Form4G()
        {
            InitializeComponent();
        }

        private void Form4G_Load(object sender, EventArgs e)
        {
            frmMan = new Form4GManipulator(this);
            frmMan.Show();
            frmMan.Location = new Point(this.Location.X + this.Width + 20, this.Location.Y);

            dc = CreateGraphics();

            blackPen = new Pen(Color.Black, 3);
            redPen = new Pen(Color.Red, 3);
            greenPen = new Pen(Color.Red, 3);
            background = this.BackColor;

            Checker.Enabled = true;
        }

        private void Example1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Team Info if Avaible");
        }

        private void Checker_Tick(object sender, EventArgs e)
        {
            if (frmMan != null && frmMan.IsDisposed)
            {
                this.Dispose();
            }

            if (this.IsDisposed != true)
            {
                dc.Clear(background);

                dc.DrawLine(blackPen, new Point(Example1.Location.X + Example1.Width, Example1.Location.Y + (Example1.Height / 2)), new Point(Example1.Location.X + Example1.Width + (TopWin.Location.X - (Example1.Location.X + Example1.Width)) / 2, Example1.Location.Y + (Example1.Height / 2)));
                dc.DrawLine(blackPen, new Point(Example2.Location.X + Example2.Width, Example2.Location.Y + (Example2.Height / 2)), new Point(Example2.Location.X + Example2.Width + (TopWin.Location.X - (Example2.Location.X + Example2.Width)) / 2, Example2.Location.Y + (Example2.Height / 2)));
                dc.DrawLine(blackPen, new Point(Example1.Location.X + Example1.Width + (TopWin.Location.X - (Example1.Location.X + Example1.Width)) / 2, Example1.Location.Y + (Example1.Height / 2)), new Point(Example2.Location.X + Example2.Width + (TopWin.Location.X - (Example2.Location.X + Example2.Width)) / 2, Example2.Location.Y + (Example2.Height / 2)));
                dc.DrawLine(blackPen, new Point(Example1.Location.X + Example1.Width + (TopWin.Location.X - (Example1.Location.X + Example1.Width)) / 2, TopWin.Location.Y + (TopWin.Height / 2)), new Point(TopWin.Location.X, TopWin.Location.Y + (TopWin.Height / 2)));

            } else { dc.Dispose(); }
        }
    }
}
