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
    enum MENUSCENE { Menu, Elim, Cup}
    public partial class Form1:Form
    {
        private MENUSCENE scene1;
        private Graphics dc;
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

            TournementHolder.Instance.Load(this);



            //timer skal være sidst
            timer1.Enabled = true;
            TestMethod();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LeagueButton.Location = new Point(Width - Width / 3 - LeagueButton.Width / 2, Height / 2 - LeagueButton.Height / 2);
            CupButton.Location = new Point(Width / 3 - CupButton.Width / 2, Height / 2 - CupButton.Height / 2);

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

        }

        private void LeagueButton_Click(object sender, EventArgs e)
        {
            scene1 = MENUSCENE.Elim;
            TournementHolder.Instance.AskForAmount();
        }

        #region ElimButtons
        private void Elimbutton1_Click(object sender, EventArgs e)
        {
            
        }

        private void Elimbutton2_Click(object sender, EventArgs e)
        {

        }

        private void Elimbutton3_Click(object sender, EventArgs e)
        {

        }

        private void Elimbutton4_Click(object sender, EventArgs e)
        {

        }

        private void Elimbutton5_Click(object sender, EventArgs e)
        {

        }

        private void Elimbutton6_Click(object sender, EventArgs e)
        {

        }

        private void Elimbutton7_Click(object sender, EventArgs e)
        {

        }

        private void Elimbutton8_Click(object sender, EventArgs e)
        {

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

        #endregion
    }
}
