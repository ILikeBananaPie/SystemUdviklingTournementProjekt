namespace TournementAndAnalysis
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CupButton = new System.Windows.Forms.Button();
            this.LeagueButton = new System.Windows.Forms.Button();
            this.LeagueTeams = new System.Windows.Forms.ListBox();
            this.AddTeamTextbox = new System.Windows.Forms.TextBox();
            this.AddTeam = new System.Windows.Forms.Button();
            this.StartTournament = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LeagueNextRound = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CupButton
            // 
            this.CupButton.Location = new System.Drawing.Point(83, 89);
            this.CupButton.Name = "CupButton";
            this.CupButton.Size = new System.Drawing.Size(75, 23);
            this.CupButton.TabIndex = 0;
            this.CupButton.Text = "Cup";
            this.CupButton.UseVisualStyleBackColor = true;
            this.CupButton.Click += new System.EventHandler(this.CupButton_Click);
            // 
            // LeagueButton
            // 
            this.LeagueButton.Location = new System.Drawing.Point(83, 129);
            this.LeagueButton.Name = "LeagueButton";
            this.LeagueButton.Size = new System.Drawing.Size(75, 23);
            this.LeagueButton.TabIndex = 1;
            this.LeagueButton.Text = "League";
            this.LeagueButton.UseVisualStyleBackColor = true;
            this.LeagueButton.Click += new System.EventHandler(this.LeagueButton_Click);
            // 
            // LeagueTeams
            // 
            this.LeagueTeams.FormattingEnabled = true;
            this.LeagueTeams.Location = new System.Drawing.Point(231, 230);
            this.LeagueTeams.Name = "LeagueTeams";
            this.LeagueTeams.Size = new System.Drawing.Size(120, 95);
            this.LeagueTeams.TabIndex = 2;
            this.LeagueTeams.Visible = false;
            // 
            // AddTeamTextbox
            // 
            this.AddTeamTextbox.Location = new System.Drawing.Point(231, 158);
            this.AddTeamTextbox.Name = "AddTeamTextbox";
            this.AddTeamTextbox.Size = new System.Drawing.Size(100, 20);
            this.AddTeamTextbox.TabIndex = 3;
            this.AddTeamTextbox.Visible = false;
            // 
            // AddTeam
            // 
            this.AddTeam.Location = new System.Drawing.Point(199, 370);
            this.AddTeam.Name = "AddTeam";
            this.AddTeam.Size = new System.Drawing.Size(98, 23);
            this.AddTeam.TabIndex = 4;
            this.AddTeam.Text = "Add Contestant";
            this.AddTeam.UseVisualStyleBackColor = true;
            this.AddTeam.Visible = false;
            this.AddTeam.Click += new System.EventHandler(this.AddTeam_Click);
            // 
            // StartTournament
            // 
            this.StartTournament.Location = new System.Drawing.Point(199, 399);
            this.StartTournament.Name = "StartTournament";
            this.StartTournament.Size = new System.Drawing.Size(98, 23);
            this.StartTournament.TabIndex = 5;
            this.StartTournament.Text = "Start Tournament";
            this.StartTournament.UseVisualStyleBackColor = true;
            this.StartTournament.Visible = false;
            this.StartTournament.Click += new System.EventHandler(this.StartTournament_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(517, 170);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 20);
            this.tableLayoutPanel1.TabIndex = 6;
            this.tableLayoutPanel1.Visible = false;
            // 
            // LeagueNextRound
            // 
            this.LeagueNextRound.Location = new System.Drawing.Point(477, 286);
            this.LeagueNextRound.Name = "LeagueNextRound";
            this.LeagueNextRound.Size = new System.Drawing.Size(75, 23);
            this.LeagueNextRound.TabIndex = 7;
            this.LeagueNextRound.Text = "Play Next Round";
            this.LeagueNextRound.UseVisualStyleBackColor = true;
            this.LeagueNextRound.Visible = false;
            this.LeagueNextRound.Click += new System.EventHandler(this.LeagueNextRound_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 455);
            this.Controls.Add(this.LeagueNextRound);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.StartTournament);
            this.Controls.Add(this.AddTeam);
            this.Controls.Add(this.AddTeamTextbox);
            this.Controls.Add(this.LeagueTeams);
            this.Controls.Add(this.LeagueButton);
            this.Controls.Add(this.CupButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button CupButton;
        private System.Windows.Forms.Button LeagueButton;
        private System.Windows.Forms.ListBox LeagueTeams;
        private System.Windows.Forms.TextBox AddTeamTextbox;
        private System.Windows.Forms.Button AddTeam;
        private System.Windows.Forms.Button StartTournament;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button LeagueNextRound;
    }
}

