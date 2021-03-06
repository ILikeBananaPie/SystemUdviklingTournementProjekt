﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TournementAndAnalysis
{
    public enum MENUSCENE { Menu, Elim, Cup }
    public partial class Form1 : Form
    {
        private MENUSCENE scene1;
        public MENUSCENE Scene1 { get { return scene1; } set { scene1 = value; } }
        private Graphics dc;
        private BufferedGraphics backBuffer;
        private Font f; //til alt eventuel tekst
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
        private int timer = 0;
        private Image backgroundImage;

        private List<string> ColumnHeaders;
        private List<Button> LeagueTeamButtons = new List<Button>();
        private int TeamNumber = 1;

        public Form1()
        {
            InitializeComponent();
            ElimAmount.KeyPress += new KeyPressEventHandler(ElimAmount_KeyPress);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AddTeamTextbox.ForeColor = Color.White;
            AddTeamTextbox.BackColor = Color.Purple;
            LeagueTeams.ForeColor = Color.White;
            LeagueTeams.BackColor = Color.Purple;
            tableLayoutPanel1.BackgroundImage = Image.FromFile("ButtonTest52.png");
            tableLayoutPanel1.BackgroundImageLayout = ImageLayout.Stretch;
            //tableLayoutPanel1.BackColor = Color.Transparent;
            LeagueBack.Width = 100;
            AddTeam.BackgroundImage = Image.FromFile("ButtonTest5.png");
            AddTeam.BackgroundImageLayout = ImageLayout.Stretch;
            AddTeam.FlatStyle = FlatStyle.Flat;
            AddTeam.FlatAppearance.BorderSize = 0;
            StartTournament.BackgroundImage = Image.FromFile("ButtonTest5.png");
            StartTournament.BackgroundImageLayout = ImageLayout.Stretch;
            StartTournament.FlatStyle = FlatStyle.Flat;
            StartTournament.FlatAppearance.BorderSize = 0;
            ErrorMessage.Visible = false;
            MainScreenButtons = new List<Button> { CupButton, LeagueButton };
            LeagueAddTeamButtons = new List<Button> { AddTeam, StartTournament };
            ColumnHeaders = new List<string> { "Contestant:", "Played:", "Won:", "Loss:", "Draw:", "Position:" };

            foreach (object btn in Controls)
            {
                if (btn is Button)
                {
                    (btn as Button).ForeColor = Color.White;
                    (btn as Button).Font = new Font("Rockwell", 8, FontStyle.Bold, GraphicsUnit.Point);
                }
            }
            LeagueButton.Location = new Point(Width - Width / 3 - LeagueButton.Width / 2, Height / 2 - LeagueButton.Height / 2);
            CupButton.Location = new Point(Width / 3 - CupButton.Width / 2, Height / 2 - CupButton.Height / 2);
            scene1 = MENUSCENE.Menu;
            backgroundImage = Image.FromFile("global-bg.jpg");

            //En gaffa løsning til noget grafisk
            Point p = Location;
            Size oriSize = this.Size;
            Size temp = new Size(40000, 40000);
            Size = temp;
            backBuffer = BufferedGraphicsManager.Current.Allocate(CreateGraphics(), new Rectangle(new Point(0), Size));
            dc = backBuffer.Graphics;
            Size = oriSize;
            Location = p;



            TournementHolder.Instance.Load(this, dc);



            //timer skal være sidst
            AddTeam.Location = new Point(Width / 3 - AddTeam.Width / 2, Height / 2 - AddTeam.Height / 2);
            StartTournament.Location = new Point(Width - Width / 3 - StartTournament.Width / 2, Height / 2 - StartTournament.Height / 2);

            LeagueTeams.Location = new Point(Width / 2 - LeagueTeams.Width / 2, Height / 2 + (LeagueTeams.Height / 2));
            AddTeamTextbox.Location = new Point(Width - Width / 2 - AddTeamTextbox.Width / 2, Height / 2 - AddTeamTextbox.Height / 2);
            LeagueNextRound.AutoSize = true;
            LeagueNextRound.AutoSizeMode = AutoSizeMode.GrowOnly;
            LeagueNextRound.TextAlign = ContentAlignment.MiddleLeft;
            LeagueNextRound.Padding = new Padding(0, 0, 0, 0);

            timer1.Enabled = true;
            TestMethod();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LeagueButton.Location = new Point(Width - Width / 3 - LeagueButton.Width / 2, Height / 2 - LeagueButton.Height / 2);
            CupButton.Location = new Point(Width / 3 - CupButton.Width / 2, Height / 2 - CupButton.Height / 2);


            dc.Clear(this.BackColor);
            dc.DrawImage(backgroundImage, new Rectangle(0, 0, Size.Width, Size.Height));
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
            backBuffer.Render();

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

        private void CupButton_Click(object sender, EventArgs e)
        {
            scene1 = MENUSCENE.Elim;
            TournementHolder.Instance.AskForAmount();
        }

        private void LeagueButton_Click(object sender, EventArgs e)
        {
            LeagueBack.Visible = true;
            scene1 = MENUSCENE.Cup;

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
                }
                else if (str == 2)
                {
                    //start for 2
                    ElimAmount.Text = "2 Success";
                }
                else if (str <= 4)
                {
                    //start for 4
                    ElimAmount.Text = "4 Success";
                }
                else if (str <= 8)
                {
                    TournementHolder.Instance.SetupForEight();
                    ElimAmount.Text = "8 Success";
                }
                else
                {
                    ElimAmount.Text = "For mange deltager";
                }
            }
            else
            {
                ElimAmount.Text = "Indtast tal";
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.GoBackToMenu();
        }

        #endregion

        private void ElimGroupsOf4_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.SetupForFour();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.SetupForEight();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.SetupForSixTeen();
        }

        private void ElimGroupsOf20_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.SetupForThirtyTwo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold9_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold10_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold12_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold25_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold26_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold27_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold28_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold29_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold30_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold31_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold32_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold13_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold14_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold15_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold16_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold17_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold18_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold19_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold20_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold21_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold22_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold23_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void Hold24_Click(object sender, EventArgs e)
        {
            TournementHolder.Instance.ChangeElimButtonText(sender);
        }

        private void ElimAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void ElimAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (ElimWinner.Text == "Skift Deltager")
                {
                    ElimWinner.Focus();
                    ElimWinner_Click(this, new EventArgs());
                }
            }
        }

        private void AddTeam_Click(object sender, EventArgs e)
        {
            if (AddTeamTextbox.Text == "")
            {
                ErrorMessage.Text = "*Team name cannot be empty*";
                ErrorMessage.ForeColor = Color.Red;
                ErrorMessage.Location = new Point(AddTeamTextbox.Location.X - 20, AddTeamTextbox.Location.Y - 50);
                ErrorMessage.Visible = true;
            }
            else
            {
                LeagueTeamList.Add(new string[] { AddTeamTextbox.Text, TeamNumber.ToString(), "0" });
                LeagueTeams.Items.Add(AddTeamTextbox.Text);
                AddTeamTextbox.Text = "";
                TeamNumber++;
                ErrorMessage.Visible = false;
            }

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
                myLabel.ForeColor = Color.White;
                myLabel.Font = new Font("Rockwell", 8, FontStyle.Bold, GraphicsUnit.Point);

                tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100));
                tableLayoutPanel1.Controls.Add(myLabel, i, 0);
            }


            for (int i = 0; i < LeagueTeamList.Count; i++)
            {
                Button myButton = new Button();
                myButton.BackgroundImage = Image.FromFile("ButtonTest5.png");
                myButton.BackgroundImageLayout = ImageLayout.Stretch;
                myButton.ForeColor = Color.White;
                myButton.Font = new Font("Rockwell", 8, FontStyle.Bold, GraphicsUnit.Point);
                myButton.FlatStyle = FlatStyle.Flat;
                myButton.FlatAppearance.BorderSize = 0;
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
                    myLabel.ForeColor = Color.White;
                    myLabel.Font = new Font("Rockwell", 8, FontStyle.Bold, GraphicsUnit.Point);
                    tableLayoutPanel1.Controls.Add(myLabel, y, x);
                }
            }
        }

        private void LeagueNextRound_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                for (int x = 0; x < LeagueTeamList.Count + 1; x++)
                {
                    tableLayoutPanel1.GetControlFromPosition(i, x).BackColor = Color.Transparent;
                }
            }
            if (extraMatches)
            {
                foreach (Button button in LeagueTeamButtons)
                {
                    button.BackColor = Color.Transparent;
                }
                LeagueTeamButtons[extraMatchTeamOne - 1].BackColor = Color.Gray;
                LeagueTeamButtons[extraMatchTeamTwo - 1].BackColor = Color.Gray;

                if (ElimRound() == 0)
                {
                    int pos = int.Parse(tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamOne).Text);
                    pos++;
                    tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamOne).Text = pos.ToString();
                    tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamOne).BackColor = Color.LightGray;

                }
                else
                {
                    int pos = int.Parse(tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamTwo).Text);
                    pos++;
                    tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamTwo).Text = pos.ToString();
                    tableLayoutPanel1.GetControlFromPosition(5, extraMatchTeamTwo).BackColor = Color.LightGray;
                }
                int[] temp = CheckDraws();
                if (temp != null)
                {
                    extraMatches = true;
                    LeagueNextRound.Visible = true;
                }
                else
                {
                    LeagueNextRound.Text = "Play Next Round";
                    LeagueNextRound.Left -= LeagueNextRound.Width;
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
                foreach (Button button in LeagueTeamButtons)
                {
                    button.BackColor = Color.Transparent;
                }
                LeagueTeamButtons[team1].BackColor = Color.Gray;
                LeagueTeamButtons[team2].BackColor = Color.Gray;
                int winLose = LeagueRound();
                int y;
                if (winLose == 0)
                {
                    y = 4;
                    int first = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text);
                    first++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text = first.ToString();
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).BackColor = Color.LightGray;

                    int second = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text);
                    second++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text = second.ToString();
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).BackColor = Color.LightGray;


                }
                else if (winLose == 1)
                {
                    y = 2;
                    int first = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text);
                    first++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text = first.ToString();
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).BackColor = Color.LightGray;


                    y = 3;
                    int second = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text);
                    second++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text = second.ToString();
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).BackColor = Color.LightGray;

                }
                else
                {
                    y = 3;
                    int first = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text);
                    first++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text = first.ToString();
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).BackColor = Color.LightGray;


                    y = 2;
                    int second = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text);
                    second++;
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text = second.ToString();
                    tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).BackColor = Color.LightGray;

                }
                y = 1;
                int played = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text);
                played++;
                tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).Text = played.ToString();
                tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team1][1])).BackColor = Color.LightGray;


                played = int.Parse(tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text);
                played++;
                tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).Text = played.ToString();
                tableLayoutPanel1.GetControlFromPosition(y, int.Parse(LeagueTeamList[team2][1])).BackColor = Color.LightGray;


                UpdatePositions();
                if (CheckWin())
                {
                    LeagueNextRound.Visible = false;
                    if (CheckDraws() != null)
                    {
                        LeagueNextRound.Text = "Play Extra Round";
                        LeagueNextRound.Left += LeagueNextRound.Width;
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
            for (int i = 0; i < tableLayoutPanel1.ColumnCount; i++)
            {
                for (int x = 0; x < LeagueTeamList.Count + 1; x++)
                {
                    tableLayoutPanel1.GetControlFromPosition(i, x).BackColor = Color.Transparent;
                }
            }
            foreach (Button button in LeagueTeamButtons)
            {
                button.BackColor = Color.Transparent;
            }
            SetPositions();
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

        public void SetPositions()
        {
            for (int i = 1; i < teamPositions.Count + 1; i++)
            {
                string name = tableLayoutPanel1.GetControlFromPosition(0, i).Text;
                string played = tableLayoutPanel1.GetControlFromPosition(1, i).Text;
                string won = tableLayoutPanel1.GetControlFromPosition(2, i).Text;
                string loss = tableLayoutPanel1.GetControlFromPosition(3, i).Text;
                string draw = tableLayoutPanel1.GetControlFromPosition(4, i).Text;
                string position = tableLayoutPanel1.GetControlFromPosition(5, i).Text;
                int teamPos = teamPositions[i - 1][0];
                //int test = team
                /*
                if (tableLayoutPanel1.GetControlFromPosition(5, i).Text == position && i != teamPositions.Count)
                {
                    tableLayoutPanel1.GetControlFromPosition(0, i + 1).Text = tableLayoutPanel1.GetControlFromPosition(0, int.Parse(position) + 1).Text;
                    tableLayoutPanel1.GetControlFromPosition(1, i + 1).Text = tableLayoutPanel1.GetControlFromPosition(1, int.Parse(position) + 1).Text;
                    tableLayoutPanel1.GetControlFromPosition(2, i + 1).Text = tableLayoutPanel1.GetControlFromPosition(2, int.Parse(position) + 1).Text;
                    tableLayoutPanel1.GetControlFromPosition(3, i + 1).Text = tableLayoutPanel1.GetControlFromPosition(3, int.Parse(position) + 1).Text;
                    tableLayoutPanel1.GetControlFromPosition(4, i + 1).Text = tableLayoutPanel1.GetControlFromPosition(4, int.Parse(position) + 1).Text;
                    tableLayoutPanel1.GetControlFromPosition(5, i + 1).Text = tableLayoutPanel1.GetControlFromPosition(5, int.Parse(position) + 1).Text;

                    tableLayoutPanel1.GetControlFromPosition(0, int.Parse(position) + 1).Text = name;
                    tableLayoutPanel1.GetControlFromPosition(1, int.Parse(position) + 1).Text = played;
                    tableLayoutPanel1.GetControlFromPosition(2, int.Parse(position) + 1).Text = won;
                    tableLayoutPanel1.GetControlFromPosition(3, int.Parse(position) + 1).Text = loss;
                    tableLayoutPanel1.GetControlFromPosition(4, int.Parse(position) + 1).Text = draw;
                    tableLayoutPanel1.GetControlFromPosition(5, int.Parse(position) + 1).Text = position;
                }
                */

                tableLayoutPanel1.GetControlFromPosition(0, i).Text = tableLayoutPanel1.GetControlFromPosition(0, int.Parse(position)).Text;
                tableLayoutPanel1.GetControlFromPosition(1, i).Text = tableLayoutPanel1.GetControlFromPosition(1, int.Parse(position)).Text;
                tableLayoutPanel1.GetControlFromPosition(2, i).Text = tableLayoutPanel1.GetControlFromPosition(2, int.Parse(position)).Text;
                tableLayoutPanel1.GetControlFromPosition(3, i).Text = tableLayoutPanel1.GetControlFromPosition(3, int.Parse(position)).Text;
                tableLayoutPanel1.GetControlFromPosition(4, i).Text = tableLayoutPanel1.GetControlFromPosition(4, int.Parse(position)).Text;
                tableLayoutPanel1.GetControlFromPosition(5, i).Text = tableLayoutPanel1.GetControlFromPosition(5, int.Parse(position)).Text;

                tableLayoutPanel1.GetControlFromPosition(0, int.Parse(position)).Text = name;
                tableLayoutPanel1.GetControlFromPosition(1, int.Parse(position)).Text = played;
                tableLayoutPanel1.GetControlFromPosition(2, int.Parse(position)).Text = won;
                tableLayoutPanel1.GetControlFromPosition(3, int.Parse(position)).Text = loss;
                tableLayoutPanel1.GetControlFromPosition(4, int.Parse(position)).Text = draw;
                tableLayoutPanel1.GetControlFromPosition(5, int.Parse(position)).Text = position;

                teamPositions[i - 1][0] = teamPositions[int.Parse(position) - 1][0];
                teamPositions[int.Parse(position) - 1][0] = teamPos;

            }
        }

        private void LeagueBack_Click(object sender, EventArgs e)
        {
            scene1 = MENUSCENE.Menu;
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