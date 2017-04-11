﻿using System;
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
            }
        }

        private void SetupTable()
        {
            for (int i = 0; i < teams.Count; i++)
            {
                CupTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20));
            }

            CupTable.Visible = true;
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
    }
}