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
    public partial class Form1 : Form
    {

        private Graphics dc;
        private Font f;
        private Random rnd = new Random();
        private List<Button> MainScreenButtons;
        private List<Button> LeagueAddTeamButtons;
        private List<string[]> LeagueTeamList = new List<string[]>();
        private List<int> LeagueTeamNumbers = new List<int>();
        private List<string> LeagueTeamCombinations = new List<string>();
        private List<int[]> teamPositions = new List<int[]>();
        private List<int[]> extraMatchesList = new List<int[]>();
        private int leagueRound = 1;
        private bool extraMatches;
        private int extraMatchTeamOne;
        private int extraMatchTeamTwo;

        private List<string> ColumnHeaders;
        private List<Button> LeagueTeamButtons = new List<Button>();
        private int TeamNumber = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ErrorMessage.Visible = false;
            MainScreenButtons = new List<Button> { CupButton, LeagueButton };
            LeagueAddTeamButtons = new List<Button> { AddTeam, StartTournament };
            ColumnHeaders = new List<string> { "Contestant:", "Played:", "Won:", "Loss:", "Draw:", "Position:" };

            LeagueButton.Location = new Point(Width - Width / 3 - LeagueButton.Width / 2, Height / 2 - LeagueButton.Height / 2);
            CupButton.Location = new Point(Width / 3 - CupButton.Width / 2, Height / 2 - CupButton.Height / 2);

            AddTeam.Location = new Point(Width / 3 - AddTeam.Width / 2, Height / 2 - AddTeam.Height / 2);
            StartTournament.Location = new Point(Width - Width / 3 - StartTournament.Width / 2, Height / 2 - StartTournament.Height / 2);

            LeagueTeams.Location = new Point(Width / 2 - LeagueTeams.Width / 2, Height / 2 + (LeagueTeams.Height / 2));
            AddTeamTextbox.Location = new Point(Width - Width / 2 - AddTeamTextbox.Width / 2, Height / 2 - AddTeamTextbox.Height / 2);

            button1.Visible = false;
            timer1.Enabled = true;
            TestMethod();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LeagueBack.Location = new Point((Width / 10) * 8, (Height / 10) * 8);
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
            LeagueBack.Visible = true;
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
            LeagueTeamList.Add(new string[] { AddTeamTextbox.Text, TeamNumber.ToString(), "0" });
            LeagueTeams.Items.Add(AddTeamTextbox.Text);
            AddTeamTextbox.Text = "";
            TeamNumber++;
            ErrorMessage.Visible = false;
        }

        private void StartTournament_Click(object sender, EventArgs e)
        {
            if (LeagueTeamList.Count >= 3)
            {
                foreach (Button button in LeagueAddTeamButtons)
                {
                    button.Visible = false;
                }
                foreach (string[] item in LeagueTeamList)
                {
                    LeagueTeamNumbers.Add(int.Parse(item[1]));
                }

                AddTeamTextbox.Visible = false;
                LeagueTeams.Visible = false;
                LeagueNextRound.Visible = true;
                button1.Visible = true;
                CreateCombinations();
                SetupTable();
            }
            else
            {
                ErrorMessage.Text = "*Need at least 3 contestants to start tournament*";
                ErrorMessage.ForeColor = Color.Red;
                ErrorMessage.Location = new Point(AddTeamTextbox.Location.X - 65, AddTeamTextbox.Location.Y - 50);
                ErrorMessage.Visible = true;
            }


        }

        private void CreateCombinations()
        {
            bool done = false;
            int x = 0;
            int i = 1;
            while (!done)
            {
                LeagueTeamCombinations.Add(LeagueTeamNumbers[x].ToString() + "," + LeagueTeamNumbers[i].ToString());
                i++;
                if (i == LeagueTeamNumbers.Count)
                {
                    x++;
                    i = x + 1;
                }
                if (x == LeagueTeamNumbers.Count - 1)
                {
                    done = true;
                }
            }
        }

        private void SetupTable()
        {
            //Hello
            tableLayoutPanel1.Size = new Size(20, 100);
            tableLayoutPanel1.BackColor = Color.Transparent;
            tableLayoutPanel1.Visible = true;

            tableLayoutPanel1.AutoSize = true;
            //tableLayoutPanel1.ColumnStyles.RemoveAt(0);
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
                myButton.Text = LeagueTeamList[i][0];
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
            if (extraMatches)
            {
                if (ElimRound() == 0)
                {
                    int pos = int.Parse(tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamOne).Text);
                    pos++;
                    tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamOne).Text = pos.ToString();
                }
                else
                {
                    int pos = int.Parse(tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamTwo).Text);
                    pos++;
                    tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamTwo).Text = pos.ToString();
                }
                int[] temp = CheckDraws();
                if (temp != null)
                {
                    extraMatches = true;
                    LeagueNextRound.Visible = true;
                }
                else
                {
                    LeagueNextRound.Visible = false;
                    extraMatches = false;
                }
            }
            else
            {
                if (LeagueTeamCombinations.Count == 0)
                {
                    CreateCombinations();
                    leagueRound++;
                }

                char[] delimiterChars = { ',' };
                int combination = rnd.Next(LeagueTeamCombinations.Count);
                string[] teams = LeagueTeamCombinations[combination].Split(delimiterChars);
                LeagueTeamCombinations.RemoveAt(combination);
                int team1 = int.Parse(teams[0]) - 1;
                int team2 = int.Parse(teams[1]) - 1;
                int winLose = LeagueRound();
                int y;
                if (winLose == 0)
                {
                    y = 4;
                    int first = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text);
                    first++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text = first.ToString();

                    int second = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text);
                    second++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text = second.ToString();

                }
                else if (winLose == 1)
                {
                    y = 2;
                    int first = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text);
                    first++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text = first.ToString();

                    y = 3;
                    int second = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text);
                    second++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text = second.ToString();
                }
                else
                {
                    y = 3;
                    int first = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text);
                    first++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text = first.ToString();

                    y = 2;
                    int second = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text);
                    second++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text = second.ToString();
                }
                y = 1;
                int played = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text);
                played++;
                tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text = played.ToString();

                played = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text);
                played++;
                tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text = played.ToString();

                UpdatePositions();
                if (CheckWin())
                {
                    LeagueNextRound.Visible = false;
                    if (CheckDraws() != null)
                    {
                        extraMatches = true;
                        LeagueNextRound.Visible = true;
                    }
                }
            }
        }

        public int[] CheckDraws()
        {
            for (int i = 1; i < LeagueTeamList.Count + 1; i++)
            {
                for (int x = 1; x < LeagueTeamList.Count + 1; x++)
                {
                    string temp1 = tableLayoutPanel1.GetControlFromPosition(5, i).Text;
                    string temp2 = tableLayoutPanel1.GetControlFromPosition(5, x).Text;

                    if (temp1 == temp2 && x != i)
                    {
                        extraMatchTeamOne = i;
                        extraMatchTeamTwo = x;
                        return new int[] { i, x };
                    }
                }
            }
            return null;
        }

        public bool CheckWin()
        {
            bool win = false;
            for (int i = 1; i < LeagueTeamList.Count + 1; i++)
            {
                if (int.Parse(tableLayoutPanel1.GetControlFromPosition(1, i).Text) < (LeagueTeamList.Count - 1) * 2)
                {
                    win = false;
                    break;
                }
                else
                {
                    win = true;
                }
            }
            return win;
        }

        public void UpdatePositions()
        {
            teamPositions.Clear();
            int highestScore = 0;
            foreach (string[] item in LeagueTeamList)
            {
                int won = int.Parse(tableLayoutPanel1.GetControlFromPosition(2, int.Parse(item[1])).Text) * 3;
                int loss = int.Parse(tableLayoutPanel1.GetControlFromPosition(3, int.Parse(item[1])).Text);
                int draw = int.Parse(tableLayoutPanel1.GetControlFromPosition(4, int.Parse(item[1])).Text) * 2;
                int score = won + loss + draw;
                item[2] = score.ToString();
            }

            foreach (string[] item in LeagueTeamList)
            {
                teamPositions.Add(new int[] { int.Parse(item[1]), int.Parse(item[2]) });
                if (int.Parse(item[2]) > highestScore)
                {
                    highestScore = int.Parse(item[2]);
                }
            }
            List<int[]> tempList = new List<int[]>();
            tempList = teamPositions.OrderBy(x => x[1]).ToList();
            tempList.Reverse();
            teamPositions = tempList;

            for (int i = 0; i < teamPositions.Count; i++)
            {
                if (i > 0)
                {
                    if (teamPositions[i][1] == teamPositions[i - 1][1])
                    {
                        tableLayoutPanel1.GetControlFromPosition(5, teamPositions[i][0]).Text = tableLayoutPanel1.GetControlFromPosition(5, teamPositions[i - 1][0]).Text;
                    }
                    else
                    {
                        tableLayoutPanel1.GetControlFromPosition(5, teamPositions[i][0]).Text = (teamPositions.IndexOf(teamPositions[i]) + 1).ToString();
                    }
                }
                else
                {
                    tableLayoutPanel1.GetControlFromPosition(5, teamPositions[i][0]).Text = (teamPositions.IndexOf(teamPositions[i]) + 1).ToString();
                }
            }
        }

        private void LeagueBack_Click(object sender, EventArgs e)
        {
            LeagueNextRound.Visible = false;
            tableLayoutPanel1.Visible = false;
            LeagueBack.Visible = false;
            AddTeamTextbox.Visible = false;
            LeagueTeams.Visible = false;

            tableLayoutPanel1.Controls.Clear();
            //tableLayoutPanel1.RowStyles.Clear();
            //tableLayoutPanel1.ColumnStyles.Clear();

            //ColumnHeaders.Clear();
            LeagueTeamButtons.Clear();
            leagueRound = 1;
            TeamNumber = 1;

            LeagueTeams.Items.Clear();
            LeagueTeamList.Clear();
            LeagueTeamNumbers.Clear();
            LeagueTeamCombinations.Clear();
            teamPositions.Clear();
            extraMatchesList.Clear();

            foreach (Button button in LeagueAddTeamButtons)
            {
                button.Visible = false;
            }

            foreach (Button button in MainScreenButtons)
            {
                button.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}