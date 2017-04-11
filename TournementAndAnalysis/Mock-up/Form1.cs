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
    public partial class Form1 : Form
    {
        private List<string> teams = new List<string>();
        private bool elim;
        private bool cup;
        private int round = 0;

        public Form1()
        {
            InitializeComponent();

            ElimTourn.Top = ClientRectangle.Height / 2;
            ElimTourn.Left = ClientRectangle.Width / 2 - ElimTourn.Width;
            CupTourn.Top = ClientRectangle.Height / 2;
            CupTourn.Left = ClientRectangle.Width / 2 + CupTourn.Width / 2;

            Add.Top = ClientRectangle.Height / 2;
            Add.Left = ClientRectangle.Width / 2 - ElimTourn.Width;
            Done.Top = ClientRectangle.Height / 2;
            Done.Left = ClientRectangle.Width / 2 + CupTourn.Width / 2;

            EnterTeams.Top = ClientRectangle.Height / 2 - EnterTeams.Height * 2;
            EnterTeams.Left = ClientRectangle.Width / 2 - EnterTeams.Width / 2;
            EnterTeams.Width = 150;

            NextRound.Top = ClientRectangle.Height / 2;
            NextRound.Left = ClientRectangle.Width / 2 - ElimTourn.Width;

            SetupCupTable();

        }

        private void SetupCupTable()
        {
            CupTable.Height = 20;
            CupTable.Width = 20;
            CupTable.Top = 50;
            CupTable.ColumnCount = 6;
            CupTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            CupTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            CupTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            CupTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            CupTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            CupTable.Left = ClientRectangle.Width / 10 * 2;

            Label label = new Label();
            label.Text = "Teams";
            CupTable.Controls.Add(label, 0, 0);

            Label label2 = new Label();
            label2.Text = "Played";
            CupTable.Controls.Add(label2, 1, 0);

            Label label3 = new Label();
            label3.Text = "Won";
            CupTable.Controls.Add(label3, 2, 0);

            Label label4 = new Label();
            label4.Text = "Loss";
            CupTable.Controls.Add(label4, 3, 0);

            Label label5 = new Label();
            label5.Text = "Draw";
            CupTable.Controls.Add(label5, 4, 0);

            Label label6 = new Label();
            label6.Text = "Position";
            CupTable.Controls.Add(label6, 5, 0);
        }

        private void ElimTourn_Click(object sender, EventArgs e)
        {
            ElimTourn.Visible = false;
            CupTourn.Visible = false;
            Done.Visible = true;
            Add.Visible = true;
            EnterTeams.Visible = true;
            TeamList.Visible = true;
            elim = true;
        }

        private void CupTourn_Click(object sender, EventArgs e)
        {
            ElimTourn.Visible = false;
            CupTourn.Visible = false;
            Done.Visible = true;
            Add.Visible = true;
            EnterTeams.Visible = true;
            TeamList.Visible = true;
            cup = true;
        }

        private void EnterTeams_TextChanged(object sender, EventArgs e)
        {

        }

        private void Done_Click(object sender, EventArgs e)
        {
            if (teams.Count <= 2)
            {
                EnterTeams.Text = "Must have more than two teams";
            }
            else
            {
                if (elim)
                {
                    if (teams.Count % 2 != 0)
                    {
                        EnterTeams.Text = "Must have an even amount";
                    }
                    else
                    {
                        Done.Visible = false;
                        Add.Visible = false;
                        EnterTeams.Visible = false;
                        TeamList.Visible = false;
                    }
                }
                if (cup)
                {
                    Done.Visible = false;
                    Add.Visible = false;
                    EnterTeams.Visible = false;
                    TeamList.Visible = false;
                    SetupTable();
                    CupTable.Visible = true;
                    NextRound.Visible = true;
                }
            }

        }

        private void SetupTable()
        {
            for (int i = 0; i < teams.Count; i++)
            {
                CupTable.RowStyles.Add(new RowStyle(SizeType.AutoSize, 20));
                Label label = new Label();
                label.Text = teams[i];
                CupTable.Controls.Add(label, 0, i + 1);
            }
            ShowStats();
            CupTable.Visible = true;
        }

        private void ShowStats()
        {
            for (int x = 1; x < CupTable.ColumnCount; x++)
            {
                for (int y = 1; y < teams.Count + 1; y++)
                {
                    Label text = new Label();
                    text.Text = "0";
                    CupTable.Controls.Add(text, x, y);
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (EnterTeams.Text != "")
            {
                TeamList.Items.Add(EnterTeams.Text);
                teams.Add(EnterTeams.Text);
                EnterTeams.Text = "";
            }

        }

        private void TeamList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CupTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NextRound_Click(object sender, EventArgs e)
        {
            for (int i = 1; i < teams.Count + 1; i++)
            {
                CupTable.GetControlFromPosition(0, i).BackColor = Color.White;
            }

            if (round == 0)
            {
                Label label = new Label();
                label.BackColor = Color.Red;
                CupTable.GetControlFromPosition(0, 1).BackColor = Color.Red;
                CupTable.GetControlFromPosition(0, 2).BackColor = Color.Red;

                CupTable.GetControlFromPosition(1, 1).Text = "1";
                CupTable.GetControlFromPosition(1, 2).Text = "1";

                CupTable.GetControlFromPosition(2, 1).Text = "1";
                CupTable.GetControlFromPosition(3, 2).Text = "1";

                CupTable.GetControlFromPosition(5, 1).Text = "1";
                CupTable.GetControlFromPosition(5, 2).Text = "3";
                CupTable.GetControlFromPosition(5, 3).Text = "2";
                round++;
            }
            else if (round == 1)
            {
                Label label = new Label();
                label.BackColor = Color.Red;
                CupTable.GetControlFromPosition(0, 2).BackColor = Color.Red;
                CupTable.GetControlFromPosition(0, 3).BackColor = Color.Red;

                CupTable.GetControlFromPosition(1, 2).Text = "2";
                CupTable.GetControlFromPosition(1, 3).Text = "1";

                CupTable.GetControlFromPosition(3, 2).Text = "2";
                CupTable.GetControlFromPosition(2, 3).Text = "1";

                CupTable.GetControlFromPosition(5, 1).Text = "1";
                CupTable.GetControlFromPosition(5, 2).Text = "3";
                CupTable.GetControlFromPosition(5, 3).Text = "2";
                round++;
            }
            else if (round == 2)
            {
                Label label = new Label();
                label.BackColor = Color.Red;
                CupTable.GetControlFromPosition(0, 1).BackColor = Color.Red;
                CupTable.GetControlFromPosition(0, 3).BackColor = Color.Red;

                CupTable.GetControlFromPosition(1, 1).Text = "2";
                CupTable.GetControlFromPosition(1, 3).Text = "2";

                CupTable.GetControlFromPosition(3, 1).Text = "1";
                CupTable.GetControlFromPosition(2, 3).Text = "2";

                CupTable.GetControlFromPosition(5, 1).Text = "2";
                CupTable.GetControlFromPosition(5, 2).Text = "3";
                CupTable.GetControlFromPosition(5, 3).Text = "1";
                round++;
            }



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
