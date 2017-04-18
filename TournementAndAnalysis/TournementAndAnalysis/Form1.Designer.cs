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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.LeagueButton);
            this.Controls.Add(this.CupButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button CupButton;
        private System.Windows.Forms.Button LeagueButton;
    }
}

