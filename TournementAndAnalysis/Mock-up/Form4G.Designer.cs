namespace Mock_up
{
    partial class Form4G
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
            this.Example1 = new System.Windows.Forms.Button();
            this.Example2 = new System.Windows.Forms.Button();
            this.Example3 = new System.Windows.Forms.Button();
            this.Example4 = new System.Windows.Forms.Button();
            this.TopWin = new System.Windows.Forms.Button();
            this.BottomWin = new System.Windows.Forms.Button();
            this.FinalWinner = new System.Windows.Forms.Button();
            this.Checker = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // Example1
            // 
            this.Example1.Location = new System.Drawing.Point(32, 36);
            this.Example1.Name = "Example1";
            this.Example1.Size = new System.Drawing.Size(75, 23);
            this.Example1.TabIndex = 0;
            this.Example1.Text = "Example1";
            this.Example1.UseVisualStyleBackColor = true;
            this.Example1.Click += new System.EventHandler(this.Example1_Click);
            // 
            // Example2
            // 
            this.Example2.Location = new System.Drawing.Point(32, 88);
            this.Example2.Name = "Example2";
            this.Example2.Size = new System.Drawing.Size(75, 23);
            this.Example2.TabIndex = 1;
            this.Example2.Text = "Example2";
            this.Example2.UseVisualStyleBackColor = true;
            // 
            // Example3
            // 
            this.Example3.Location = new System.Drawing.Point(32, 143);
            this.Example3.Name = "Example3";
            this.Example3.Size = new System.Drawing.Size(75, 23);
            this.Example3.TabIndex = 2;
            this.Example3.Text = "Example3";
            this.Example3.UseVisualStyleBackColor = true;
            // 
            // Example4
            // 
            this.Example4.Location = new System.Drawing.Point(32, 198);
            this.Example4.Name = "Example4";
            this.Example4.Size = new System.Drawing.Size(75, 23);
            this.Example4.TabIndex = 3;
            this.Example4.Text = "Example4";
            this.Example4.UseVisualStyleBackColor = true;
            // 
            // TopWin
            // 
            this.TopWin.Location = new System.Drawing.Point(151, 61);
            this.TopWin.Name = "TopWin";
            this.TopWin.Size = new System.Drawing.Size(75, 23);
            this.TopWin.TabIndex = 4;
            this.TopWin.Text = "TopWin";
            this.TopWin.UseVisualStyleBackColor = true;
            // 
            // BottomWin
            // 
            this.BottomWin.Location = new System.Drawing.Point(151, 168);
            this.BottomWin.Name = "BottomWin";
            this.BottomWin.Size = new System.Drawing.Size(75, 23);
            this.BottomWin.TabIndex = 5;
            this.BottomWin.Text = "BottomWin";
            this.BottomWin.UseVisualStyleBackColor = true;
            // 
            // FinalWinner
            // 
            this.FinalWinner.Location = new System.Drawing.Point(266, 116);
            this.FinalWinner.Name = "FinalWinner";
            this.FinalWinner.Size = new System.Drawing.Size(75, 23);
            this.FinalWinner.TabIndex = 6;
            this.FinalWinner.Text = "FinalWinner";
            this.FinalWinner.UseVisualStyleBackColor = true;
            // 
            // Checker
            // 
            this.Checker.Tick += new System.EventHandler(this.Checker_Tick);
            // 
            // Form4G
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 261);
            this.Controls.Add(this.FinalWinner);
            this.Controls.Add(this.BottomWin);
            this.Controls.Add(this.TopWin);
            this.Controls.Add(this.Example4);
            this.Controls.Add(this.Example3);
            this.Controls.Add(this.Example2);
            this.Controls.Add(this.Example1);
            this.Name = "Form4G";
            this.Text = "Form4G";
            this.Load += new System.EventHandler(this.Form4G_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Example1;
        private System.Windows.Forms.Button Example2;
        private System.Windows.Forms.Button Example3;
        private System.Windows.Forms.Button Example4;
        private System.Windows.Forms.Button TopWin;
        private System.Windows.Forms.Button BottomWin;
        private System.Windows.Forms.Button FinalWinner;
        private System.Windows.Forms.Timer Checker;
    }
}