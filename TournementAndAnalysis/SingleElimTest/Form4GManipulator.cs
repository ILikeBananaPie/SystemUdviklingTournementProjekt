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
    enum WHOWON { TopWin, BotWin, Undecided}

    public partial class Form4GManipulator:Form
    {
        private Form4G owner;
        private bool playing;

        WHOWON top;
        WHOWON bottom;
        WHOWON final;
        Random rnd;

        public Form4GManipulator(Form4G owner)
        {
            InitializeComponent();
            this.owner = owner;
        }

        private void Form4GManipulator_Load(object sender, EventArgs e)
        {
            playing = false;
            top = WHOWON.Undecided;
            bottom = WHOWON.Undecided;
            final = WHOWON.Undecided;
            rnd = new Random();
        }

        private void PlayRound_Click(object sender, EventArgs e)
        {
            if (playing == false)
            {
                textBox1.Text = "Inaccessible";
                textBox2.Text = "Inaccessible";
                textBox3.Text = "Inaccessible";
                textBox4.Text = "Inaccessible";
                textBox1.BackColor = Color.DarkGray;
                textBox1.Enabled = false;
                textBox2.BackColor = Color.DarkGray;
                textBox2.Enabled = false;
                textBox3.BackColor = Color.DarkGray;
                textBox3.Enabled = false;
                textBox4.BackColor = Color.DarkGray;
                textBox4.Enabled = false;
                playing = true;
            }

            if (top == WHOWON.Undecided)
            {
                int x = rnd.Next(0, 2);
                if (x == 0)
                {
                    top = WHOWON.TopWin;
                    owner.Example1Get.BackColor = Color.Green;
                    owner.Example2Get.BackColor = Color.Red;
                    owner.TopWinGet.Text = owner.Example1Get.Text;
                } else if (x == 1)
                {
                    top = WHOWON.BotWin;
                    owner.Example1Get.BackColor = Color.Red;
                    owner.Example2Get.BackColor = Color.Green;
                    owner.TopWinGet.Text = owner.Example2Get.Text;
                }

            } else if (bottom == WHOWON.Undecided)
            {
                int x = rnd.Next(0, 2);
                if (x == 0)
                {
                    bottom = WHOWON.TopWin;
                    owner.Example3Get.BackColor = Color.Green;
                    owner.Example4Get.BackColor = Color.Red;
                    owner.BottomWinGet.Text = owner.Example3Get.Text;
                } else if (x == 1)
                {
                    bottom = WHOWON.BotWin;
                    owner.Example3Get.BackColor = Color.Red;
                    owner.Example4Get.BackColor = Color.Green;
                    owner.BottomWinGet.Text = owner.Example4Get.Text;
                }
            } else if (final == WHOWON.Undecided)
            {
                int x = rnd.Next(0, 2);
                if (x == 0)
                {
                    final = WHOWON.TopWin;
                    owner.TopWinGet.BackColor = Color.Green;
                    owner.BottomWinGet.BackColor = Color.Red;
                    owner.FinalWinnerGet.Text = owner.TopWinGet.Text;
                } else if (x == 1)
                {
                    final = WHOWON.BotWin;
                    owner.TopWinGet.BackColor = Color.Red;
                    owner.BottomWinGet.BackColor = Color.Green;
                    owner.FinalWinnerGet.Text = owner.BottomWinGet.Text;
                }
                owner.FinalWinnerGet.BackColor = Color.Gold;
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (playing == false)
            {
                if (textBox1.Text != "Example1 New Name")
                {
                    owner.Example1Get.Text = textBox1.Text;
                }
                if (textBox2.Text != "Example2 New Name")
                {
                    owner.Example2Get.Text = textBox2.Text;
                }
                if (textBox3.Text != "Example3 New Name")
                {
                    owner.Example3Get.Text = textBox3.Text;
                }
                if (textBox4.Text != "Example4 New Name")
                {
                    owner.Example4Get.Text = textBox4.Text;
                }
            }
        }

        private void Checker_Tick(object sender, EventArgs e)
        {
            if (owner.IsDisposed)
            {
                this.Dispose();
            }
        }
    }
}
