namespace Mock_up
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
            this.ElimTourn = new System.Windows.Forms.Button();
            this.CupTourn = new System.Windows.Forms.Button();
            this.EnterTeams = new System.Windows.Forms.TextBox();
            this.Done = new System.Windows.Forms.Button();
            this.Add = new System.Windows.Forms.Button();
            this.TeamList = new System.Windows.Forms.ListBox();
            this.CupTable = new System.Windows.Forms.TableLayoutPanel();
            this.NextRound = new System.Windows.Forms.Button();
            this.checker = new System.Windows.Forms.Timer(this.components);
            this.BackToMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ElimTourn
            // 
            this.ElimTourn.Location = new System.Drawing.Point(70, 72);
            this.ElimTourn.Name = "ElimTourn";
            this.ElimTourn.Size = new System.Drawing.Size(75, 23);
            this.ElimTourn.TabIndex = 0;
            this.ElimTourn.Text = "Elimination Tournament";
            this.ElimTourn.UseVisualStyleBackColor = true;
            this.ElimTourn.Click += new System.EventHandler(this.ElimTourn_Click);
            // 
            // CupTourn
            // 
            this.CupTourn.Location = new System.Drawing.Point(70, 123);
            this.CupTourn.Name = "CupTourn";
            this.CupTourn.Size = new System.Drawing.Size(75, 23);
            this.CupTourn.TabIndex = 1;
            this.CupTourn.Text = "Cup Tournament";
            this.CupTourn.UseVisualStyleBackColor = true;
            this.CupTourn.Click += new System.EventHandler(this.CupTourn_Click);
            // 
            // EnterTeams
            // 
            this.EnterTeams.Location = new System.Drawing.Point(70, 187);
            this.EnterTeams.Name = "EnterTeams";
            this.EnterTeams.Size = new System.Drawing.Size(100, 20);
            this.EnterTeams.TabIndex = 2;
            this.EnterTeams.Visible = false;
            this.EnterTeams.TextChanged += new System.EventHandler(this.EnterTeams_TextChanged);
            // 
            // Done
            // 
            this.Done.Location = new System.Drawing.Point(199, 72);
            this.Done.Name = "Done";
            this.Done.Size = new System.Drawing.Size(75, 23);
            this.Done.TabIndex = 3;
            this.Done.Text = "Done";
            this.Done.UseVisualStyleBackColor = true;
            this.Done.Visible = false;
            this.Done.Click += new System.EventHandler(this.Done_Click);
            // 
            // Add
            // 
            this.Add.Location = new System.Drawing.Point(199, 123);
            this.Add.Name = "Add";
            this.Add.Size = new System.Drawing.Size(75, 23);
            this.Add.TabIndex = 4;
            this.Add.Text = "Add team";
            this.Add.UseVisualStyleBackColor = true;
            this.Add.Visible = false;
            this.Add.Click += new System.EventHandler(this.Add_Click);
            // 
            // TeamList
            // 
            this.TeamList.FormattingEnabled = true;
            this.TeamList.Location = new System.Drawing.Point(25, 230);
            this.TeamList.Name = "TeamList";
            this.TeamList.Size = new System.Drawing.Size(120, 95);
            this.TeamList.TabIndex = 5;
            this.TeamList.Visible = false;
            this.TeamList.SelectedIndexChanged += new System.EventHandler(this.TeamList_SelectedIndexChanged);
            // 
            // CupTable
            // 
            this.CupTable.AutoSize = true;
            this.CupTable.ColumnCount = 1;
            this.CupTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.CupTable.Location = new System.Drawing.Point(358, 44);
            this.CupTable.Name = "CupTable";
            this.CupTable.RowCount = 1;
            this.CupTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.CupTable.Size = new System.Drawing.Size(417, 238);
            this.CupTable.TabIndex = 6;
            this.CupTable.Visible = false;
            this.CupTable.Paint += new System.Windows.Forms.PaintEventHandler(this.CupTable_Paint);
            // 
            // NextRound
            // 
            this.NextRound.Location = new System.Drawing.Point(25, 367);
            this.NextRound.Name = "NextRound";
            this.NextRound.Size = new System.Drawing.Size(75, 23);
            this.NextRound.TabIndex = 7;
            this.NextRound.Text = "Next Round";
            this.NextRound.UseVisualStyleBackColor = true;
            this.NextRound.Visible = false;
            this.NextRound.Click += new System.EventHandler(this.NextRound_Click);
            // 
            // checker
            // 
            this.checker.Enabled = true;
            this.checker.Tick += new System.EventHandler(this.checker_Tick);
            // 
            // BackToMain
            // 
            this.BackToMain.Location = new System.Drawing.Point(212, 301);
            this.BackToMain.Name = "BackToMain";
            this.BackToMain.Size = new System.Drawing.Size(75, 23);
            this.BackToMain.TabIndex = 8;
            this.BackToMain.Text = "Back";
            this.BackToMain.UseVisualStyleBackColor = true;
            this.BackToMain.Visible = false;
            this.BackToMain.Click += new System.EventHandler(this.BackToMain_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 473);
            this.Controls.Add(this.BackToMain);
            this.Controls.Add(this.NextRound);
            this.Controls.Add(this.CupTable);
            this.Controls.Add(this.TeamList);
            this.Controls.Add(this.Add);
            this.Controls.Add(this.Done);
            this.Controls.Add(this.EnterTeams);
            this.Controls.Add(this.CupTourn);
            this.Controls.Add(this.ElimTourn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ElimTourn;
        private System.Windows.Forms.Button CupTourn;
        private System.Windows.Forms.TextBox EnterTeams;
        private System.Windows.Forms.Button Done;
        private System.Windows.Forms.Button Add;
        private System.Windows.Forms.ListBox TeamList;
        private System.Windows.Forms.TableLayoutPanel CupTable;
        private System.Windows.Forms.Button NextRound;
        private System.Windows.Forms.Timer checker;
        private System.Windows.Forms.Button BackToMain;
    }
}

