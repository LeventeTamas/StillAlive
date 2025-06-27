namespace StillAlive
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbAsciiArt = new System.Windows.Forms.TextBox();
            this.CreditsTerminalBox = new StillAlive.TerminalBox();
            this.LyricsTerminalBox = new StillAlive.TerminalBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tbAsciiArt);
            this.panel1.Controls.Add(this.CreditsTerminalBox);
            this.panel1.Controls.Add(this.LyricsTerminalBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(918, 764);
            this.panel1.TabIndex = 4;
            // 
            // tbAsciiArt
            // 
            this.tbAsciiArt.BackColor = System.Drawing.Color.Black;
            this.tbAsciiArt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbAsciiArt.Font = new System.Drawing.Font("Courier New", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAsciiArt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(163)))), ((int)(((byte)(2)))));
            this.tbAsciiArt.Location = new System.Drawing.Point(472, 340);
            this.tbAsciiArt.Multiline = true;
            this.tbAsciiArt.Name = "tbAsciiArt";
            this.tbAsciiArt.ReadOnly = true;
            this.tbAsciiArt.Size = new System.Drawing.Size(444, 404);
            this.tbAsciiArt.TabIndex = 2;
            // 
            // CreditsTerminalBox
            // 
            this.CreditsTerminalBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CreditsTerminalBox.BackgroundImage")));
            this.CreditsTerminalBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CreditsTerminalBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreditsTerminalBox.Location = new System.Drawing.Point(456, 21);
            this.CreditsTerminalBox.Name = "CreditsTerminalBox";
            this.CreditsTerminalBox.Size = new System.Drawing.Size(449, 337);
            this.CreditsTerminalBox.TabIndex = 1;
            // 
            // LyricsTerminalBox
            // 
            this.LyricsTerminalBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("LyricsTerminalBox.BackgroundImage")));
            this.LyricsTerminalBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.LyricsTerminalBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LyricsTerminalBox.Location = new System.Drawing.Point(22, 21);
            this.LyricsTerminalBox.Name = "LyricsTerminalBox";
            this.LyricsTerminalBox.Size = new System.Drawing.Size(449, 723);
            this.LyricsTerminalBox.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(918, 764);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Portal 1 - Still Alive | Created by Levente Tamás";
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private TerminalBox LyricsTerminalBox;
        private TerminalBox CreditsTerminalBox;
        private System.Windows.Forms.TextBox tbAsciiArt;
    }
}

