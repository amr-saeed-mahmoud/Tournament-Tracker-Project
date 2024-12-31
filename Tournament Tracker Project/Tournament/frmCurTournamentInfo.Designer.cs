namespace Tournament_Tracker_Project.Tournament
{
    partial class frmCurTournamentInfo
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
            this.ctrTournamentInfo1 = new Tournament_Tracker_Project.Tournament.control.ctrTournamentInfo();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ctrTournamentInfo1
            // 
            this.ctrTournamentInfo1.BackColor = System.Drawing.Color.White;
            this.ctrTournamentInfo1.Location = new System.Drawing.Point(19, 61);
            this.ctrTournamentInfo1.Name = "ctrTournamentInfo1";
            this.ctrTournamentInfo1.Size = new System.Drawing.Size(864, 187);
            this.ctrTournamentInfo1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(282, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Current Tournament Info";
            // 
            // frmCurTournamentInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(895, 250);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctrTournamentInfo1);
            this.Name = "frmCurTournamentInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Current Tournament Information";
            this.Load += new System.EventHandler(this.frmCurTournamentInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private control.ctrTournamentInfo ctrTournamentInfo1;
        private System.Windows.Forms.Label label1;
    }
}