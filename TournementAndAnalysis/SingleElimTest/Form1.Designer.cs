namespace SingleElimTest
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
            this.FourGroups = new System.Windows.Forms.Button();
            this.EightGroups = new System.Windows.Forms.Button();
            this.SixteenGroups = new System.Windows.Forms.Button();
            this.CheckForMoreOpen = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // FourGroups
            // 
            this.FourGroups.Location = new System.Drawing.Point(159, 77);
            this.FourGroups.Name = "FourGroups";
            this.FourGroups.Size = new System.Drawing.Size(75, 23);
            this.FourGroups.TabIndex = 0;
            this.FourGroups.Text = "4 Groups";
            this.FourGroups.UseVisualStyleBackColor = true;
            this.FourGroups.Click += new System.EventHandler(this.FourGroups_Click);
            // 
            // EightGroups
            // 
            this.EightGroups.Location = new System.Drawing.Point(159, 136);
            this.EightGroups.Name = "EightGroups";
            this.EightGroups.Size = new System.Drawing.Size(75, 23);
            this.EightGroups.TabIndex = 1;
            this.EightGroups.Text = "8 Groups";
            this.EightGroups.UseVisualStyleBackColor = true;
            this.EightGroups.Click += new System.EventHandler(this.EightGroups_Click);
            // 
            // SixteenGroups
            // 
            this.SixteenGroups.Location = new System.Drawing.Point(159, 200);
            this.SixteenGroups.Name = "SixteenGroups";
            this.SixteenGroups.Size = new System.Drawing.Size(75, 23);
            this.SixteenGroups.TabIndex = 2;
            this.SixteenGroups.Text = "16 Groups";
            this.SixteenGroups.UseVisualStyleBackColor = true;
            this.SixteenGroups.Click += new System.EventHandler(this.SixteenGroups_Click);
            // 
            // CheckForMoreOpen
            // 
            this.CheckForMoreOpen.Enabled = true;
            this.CheckForMoreOpen.Tick += new System.EventHandler(this.CheckForMoreOpen_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 431);
            this.Controls.Add(this.SixteenGroups);
            this.Controls.Add(this.EightGroups);
            this.Controls.Add(this.FourGroups);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FourGroups;
        private System.Windows.Forms.Button EightGroups;
        private System.Windows.Forms.Button SixteenGroups;
        private System.Windows.Forms.Timer CheckForMoreOpen;
    }
}

