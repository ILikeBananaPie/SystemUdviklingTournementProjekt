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
    public enum MENUSCENE { Menu, Elim, Cup}
    public partial class Form1:Form
    {
        private MENUSCENE scene1;
        public MENUSCENE Scene1 { get { return scene1; } set { scene1 = value; } }
        private Graphics dcX;
        private Graphics dc;
        private BufferedGraphics backBuffer;
        private Font f; //til alt eventuel tekst
        private Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LeagueButton.Location = new Point(Width - Width / 3 - LeagueButton.Width / 2, Height / 2 - LeagueButton.Height / 2);
            CupButton.Location = new Point(Width / 3 - CupButton.Width / 2, Height / 2 - CupButton.Height / 2);
            scene1 = MENUSCENE.Menu;

            //En gaffa løsning til noget grafisk
            Point p = Location;
            Size oriSize = this.Size;
            Size temp = new Size(40000, 40000);
            Size = temp;
            dc = CreateGraphics();
            Size = oriSize;
            Location = p;

            TournementHolder.Instance.Load(this, dc);



            //timer skal være sidst
            timer1.Enabled = true;
            TestMethod();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LeagueButton.Location = new Point(Width - Width / 3 - LeagueButton.Width / 2, Height / 2 - LeagueButton.Height / 2);
            CupButton.Location = new Point(Width / 3 - CupButton.Width / 2, Height / 2 - CupButton.Height / 2);


            dc.Clear(this.BackColor);
            switch (scene1)
            {
                case MENUSCENE.Menu:
                    {
                        MenuTick();
                        break;
                    }
                case MENUSCENE.Elim:
                    {
                        ElimTick();
                        break;
                    }
            }
            
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

        private void MenuTick()
        {
            if (!CupButton.Visible) { CupButton.Show(); }
            if (!LeagueButton.Visible) { LeagueButton.Show(); }
        }

        private void ElimTick()
        {
            MenuInvisible();
            TournementHolder.Instance.TournementTick();
        }

        private void MenuInvisible()
        {
            if (CupButton.Visible == true) { CupButton.Hide(); }
            if (LeagueButton.Visible == true) { LeagueButton.Hide(); }
        }

        //

        private void CupButton_Click(object sender, EventArgs e)
        {
            scene1 = MENUSCENE.Elim;
            TournementHolder.Instance.AskForAmount();
        }

        private void LeagueButton_Click(object sender, EventArgs e)
        {
           
        }

        #region ElimButtons
        private void Elimbutton1_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Elimbutton2_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Elimbutton3_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Elimbutton4_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Elimbutton5_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Elimbutton6_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Elimbutton7_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Elimbutton8_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void ElimA1v2_Click(object sender, EventArgs e)
        {

        }

        private void ElimB3v4_Click(object sender, EventArgs e)
        {

        }

        private void ElimC5v6_Click(object sender, EventArgs e)
        {

        }

        private void ElimD7v8_Click(object sender, EventArgs e)
        {

        }

        private void ElimAvB_Click(object sender, EventArgs e)
        {

        }

        private void ElimCvD_Click(object sender, EventArgs e)
        {

        }

        private void ElimFinalABvCD_Click(object sender, EventArgs e)
        {

        }

        private void ElimWinner_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.NextRound();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            int str;
            if (int.TryParse(ElimAmount.Text, out str))
            {
                if (str < 2)
                {
                    ElimAmount.Text = "For få deltagere";
                } else if (str == 2)
                {
                    //start for 2
                    ElimAmount.Text = "2 Success";
                } else if (str <= 4)
                {
                    //start for 4
                    ElimAmount.Text = "4 Success";
                } else if (str <= 8)
                {
                    TournementHolder.Instance.SetupForEight();
                    ElimAmount.Text = "8 Success";
                } else
                {
                    ElimAmount.Text = "For mange deltager";
                }
            } else
            {
                ElimAmount.Text = "Indtast tal";
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.GoBackToMenu();
        }

        #endregion

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.SetupForEight();
        }
    }
}
