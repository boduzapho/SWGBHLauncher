namespace SWGBHLauncher
{
    partial class BHWorker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.lblNameofFile = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.lblDownloaded = new System.Windows.Forms.Label();
            this.lblPerc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbProgress
            // 
            this.pbProgress.ForeColor = System.Drawing.Color.Red;
            this.pbProgress.Location = new System.Drawing.Point(2, 18);
            this.pbProgress.Margin = new System.Windows.Forms.Padding(0);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(101, 10);
            this.pbProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbProgress.TabIndex = 0;
            this.pbProgress.Visible = false;
            this.pbProgress.Click += new System.EventHandler(this.pbProgress_Click);
            // 
            // lblNameofFile
            // 
            this.lblNameofFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNameofFile.AutoSize = true;
            this.lblNameofFile.BackColor = System.Drawing.Color.Transparent;
            this.lblNameofFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblNameofFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameofFile.ForeColor = System.Drawing.Color.White;
            this.lblNameofFile.Location = new System.Drawing.Point(-3, 2);
            this.lblNameofFile.Name = "lblNameofFile";
            this.lblNameofFile.Size = new System.Drawing.Size(80, 13);
            this.lblNameofFile.TabIndex = 1;
            this.lblNameofFile.Text = "Current File :";
            // 
            // lblSpeed
            // 
            this.lblSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(329, 61);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(100, 34);
            this.lblSpeed.TabIndex = 2;
            this.lblSpeed.Text = "Speed : 0.0 kbs";
            // 
            // lblDownloaded
            // 
            this.lblDownloaded.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDownloaded.AutoSize = true;
            this.lblDownloaded.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDownloaded.Location = new System.Drawing.Point(185, 14);
            this.lblDownloaded.Name = "lblDownloaded";
            this.lblDownloaded.Size = new System.Drawing.Size(44, 13);
            this.lblDownloaded.TabIndex = 5;
            this.lblDownloaded.Text = "0/0 0/0";
            this.lblDownloaded.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPerc
            // 
            this.lblPerc.AutoSize = true;
            this.lblPerc.BackColor = System.Drawing.Color.Transparent;
            this.lblPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerc.Location = new System.Drawing.Point(182, 53);
            this.lblPerc.Name = "lblPerc";
            this.lblPerc.Size = new System.Drawing.Size(27, 13);
            this.lblPerc.TabIndex = 6;
            this.lblPerc.Text = "00%";
            this.lblPerc.Visible = false;
            // 
            // BHWorker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.lblNameofFile);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblPerc);
            this.Controls.Add(this.lblDownloaded);
            this.Controls.Add(this.lblSpeed);
            this.Name = "BHWorker";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Size = new System.Drawing.Size(105, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbProgress;
        private System.Windows.Forms.Label lblNameofFile;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Label lblPerc;
        public System.Windows.Forms.Label lblDownloaded;
    }
}
