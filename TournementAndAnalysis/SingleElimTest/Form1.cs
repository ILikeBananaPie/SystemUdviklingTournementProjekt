using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SingleElimTest
{
    public partial class Form1:Form
    {
        private Form frm;
        private bool open;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SixteenGroups_Click(object sender, EventArgs e)
        {

        }

        private void EightGroups_Click(object sender, EventArgs e)
        {

        }

        private void FourGroups_Click(object sender, EventArgs e)
        {
            if (open == false)
            {
                frm = new Form4G();
                frm.Show();
            }
        }

        private void CheckForMoreOpen_Tick(object sender, EventArgs e)
        {
            if (frm != null)
            {
                if (frm.IsDisposed)
                {
                    open = false;
                    if (Visible == false) { Visible = true; }
                } else
                {
                    open = true;
                    if (Visible) { Visible = false; }
                }
            }
        }
    }
}
