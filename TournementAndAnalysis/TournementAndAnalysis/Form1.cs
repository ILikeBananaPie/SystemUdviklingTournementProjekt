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
        
        private Graphics dc;
        private Font f;
        private Random rnd = new Random();
        private List<Button> MainScreenButtons;
        private List<Button> LeagueAddTeamButtons;
        private List<string> LeagueTeamList = new List<string>();
        private List<string> ColumnHeaders;
        private List<Button> LeagueTeamButtons = new List<Button>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MainScreenButtons = new List<Button> { CupButton, LeagueButton };
            LeagueAddTeamButtons = new List<Button> { AddTeam, StartTournament };
            ColumnHeaders = new List<string> { "Contestant:", "Played:", "Won:", "Loss:", "Draw:", "Position:" };

            LeagueButton.Location = new Point(Width - Width / 3 - LeagueButton.Width / 2, Height / 2 - LeagueButton.Height / 2);
            CupButton.Location = new Point(Width / 3 - CupButton.Width / 2, Height / 2 - CupButton.Height / 2);

            AddTeam.Location = new Point(Width / 3 - AddTeam.Width / 2, Height / 2 - AddTeam.Height / 2);
            StartTournament.Location = new Point(Width - Width / 3 - StartTournament.Width / 2, Height / 2 - StartTournament.Height / 2);

            LeagueTeams.Location = new Point(Width / 2 - LeagueTeams.Width / 2, Height / 2 + (LeagueTeams.Height / 2));
            AddTeamTextbox.Location = new Point(Width - Width / 2 - AddTeamTextbox.Width / 2, Height / 2 - AddTeamTextbox.Height / 2);

            timer1.Enabled = true;
            TestMethod();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

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

        private void CupButton_Click(object sender, EventArgs e)
        {

        }

        private void LeagueButton_Click(object sender, EventArgs e)
        {
            foreach (Button button in MainScreenButtons)
            {
                button.Visible = false;
            }

            foreach (Button button in LeagueAddTeamButtons)
            {
                button.Visible = true;
            }
            AddTeamTextbox.Visible = true;
            LeagueTeams.Visible = true;
        }

        private void AddTeam_Click(object sender, EventArgs e)
        {
            LeagueTeamList.Add(AddTeamTextbox.Text);
            LeagueTeams.Items.Add(AddTeamTextbox.Text);
            AddTeamTextbox.Text = "";
        }

        private void StartTournament_Click(object sender, EventArgs e)
        {
            foreach (Button button in LeagueAddTeamButtons)
            {
                button.Visible = false;
            }
            AddTeamTextbox.Visible = false;
            LeagueTeams.Visible = false;
            SetupTable();

        }

        private void SetupTable()
        {
            //Hello
            tableLayoutPanel1.Size = new Size(20, 100);
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.Visible = true;

            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnStyles.RemoveAt(0);
            //tableLayoutPanel1.RowStyles.RemoveAt(0);
            tableLayoutPanel1.Padding = new Padding(3);
            tableLayoutPanel1.ColumnCount = 6;
            for (int i = 0; i < ColumnHeaders.Count; i++)
            {
                Label myLabel = new Label();
                myLabel.Text = ColumnHeaders[i];
                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
                tableLayoutPanel1.Controls.Add(myLabel, i, 0);
            }


            for (int i = 0; i < LeagueTeamList.Count; i++)
            {
                Button myButton = new Button();
                myButton.Text = LeagueTeamList[i];
                LeagueTeamButtons.Add(myButton);
                tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                tableLayoutPanel1.Controls.Add(myButton, 0, i + 1);
            }
            tableLayoutPanel1.Location = new Point(20, 20);

            for (int x = 1; x < LeagueTeamList.Count + 1; x++)
            {
                for (int y = 1; y < 6; y++)
                {
                    Label myLabel = new Label();
                    myLabel.Text = "0";
                    tableLayoutPanel1.Controls.Add(myLabel, y, x);
                }
            }
        }

        private void LeagueNextRound_Click(object sender, EventArgs e)
        {

        }
    }
}
