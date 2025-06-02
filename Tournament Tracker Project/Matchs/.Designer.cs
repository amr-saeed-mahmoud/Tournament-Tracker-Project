namespace Tournament_Tracker_Project
{
    partial class frmTournamentViewer
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbTournamentName = new System.Windows.Forms.Label();
            this.lbRound = new System.Windows.Forms.Label();
            this.cbxRound = new System.Windows.Forms.ComboBox();
            this.lvMatchList = new System.Windows.Forms.ListView();
            this.lbTeamOneName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTeamTwoScore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTeamTwoName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbxFilters = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtTeamOneScore = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tournament :";
            // 
            // lbTournamentName
            // 
            this.lbTournamentName.AutoSize = true;
            this.lbTournamentName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lbTournamentName.Location = new System.Drawing.Point(141, 25);
            this.lbTournamentName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTournamentName.Name = "lbTournamentName";
            this.lbTournamentName.Size = new System.Drawing.Size(240, 31);
            this.lbTournamentName.TabIndex = 1;
            this.lbTournamentName.Text = "<Tournament Name>.";
            // 
            // lbRound
            // 
            this.lbRound.AutoSize = true;
            this.lbRound.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRound.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lbRound.Location = new System.Drawing.Point(12, 89);
            this.lbRound.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbRound.Name = "lbRound";
            this.lbRound.Size = new System.Drawing.Size(75, 30);
            this.lbRound.TabIndex = 2;
            this.lbRound.Text = "Round";
            // 
            // cbxRound
            // 
            this.cbxRound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRound.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxRound.FormattingEnabled = true;
            this.cbxRound.Location = new System.Drawing.Point(115, 89);
            this.cbxRound.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxRound.Name = "cbxRound";
            this.cbxRound.Size = new System.Drawing.Size(217, 31);
            this.cbxRound.TabIndex = 3;
            this.cbxRound.SelectedIndexChanged += new System.EventHandler(this.cbxRound_SelectedIndexChanged);
            // 
            // lvMatchList
            // 
            this.lvMatchList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMatchList.FullRowSelect = true;
            this.lvMatchList.HideSelection = false;
            this.lvMatchList.Location = new System.Drawing.Point(14, 217);
            this.lvMatchList.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.lvMatchList.Name = "lvMatchList";
            this.lvMatchList.Size = new System.Drawing.Size(301, 314);
            this.lvMatchList.TabIndex = 5;
            this.lvMatchList.UseCompatibleStateImageBehavior = false;
            this.lvMatchList.View = System.Windows.Forms.View.List;
            this.lvMatchList.SelectedIndexChanged += new System.EventHandler(this.lvMatchList_SelectedIndexChanged);
            // 
            // lbTeamOneName
            // 
            this.lbTeamOneName.AutoSize = true;
            this.lbTeamOneName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeamOneName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lbTeamOneName.Location = new System.Drawing.Point(351, 238);
            this.lbTeamOneName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTeamOneName.Name = "lbTeamOneName";
            this.lbTeamOneName.Size = new System.Drawing.Size(114, 26);
            this.lbTeamOneName.TabIndex = 6;
            this.lbTeamOneName.Text = "Team One";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(351, 285);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 26);
            this.label3.TabIndex = 7;
            this.label3.Text = "Score";
            // 
            // txtTeamTwoScore
            // 
            this.txtTeamTwoScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamTwoScore.Location = new System.Drawing.Point(429, 422);
            this.txtTeamTwoScore.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTeamTwoScore.Name = "txtTeamTwoScore";
            this.txtTeamTwoScore.Size = new System.Drawing.Size(120, 30);
            this.txtTeamTwoScore.TabIndex = 11;
            this.txtTeamTwoScore.Validating += new System.ComponentModel.CancelEventHandler(this.ValidScore);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(351, 425);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 26);
            this.label4.TabIndex = 10;
            this.label4.Text = "Score";
            // 
            // lbTeamTwoName
            // 
            this.lbTeamTwoName.AutoSize = true;
            this.lbTeamTwoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeamTwoName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.lbTeamTwoName.Location = new System.Drawing.Point(351, 377);
            this.lbTeamTwoName.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbTeamTwoName.Name = "lbTeamTwoName";
            this.lbTeamTwoName.Size = new System.Drawing.Size(113, 26);
            this.lbTeamTwoName.TabIndex = 9;
            this.lbTeamTwoName.Text = "Team Two";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(461, 335);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 26);
            this.label6.TabIndex = 12;
            this.label6.Text = "-VS-";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Enabled = false;
            this.btnSave.FlatAppearance.BorderSize = 2;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnSave.Location = new System.Drawing.Point(356, 490);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(193, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbxFilters
            // 
            this.cbxFilters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilters.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxFilters.FormattingEnabled = true;
            this.cbxFilters.Items.AddRange(new object[] {
            "All Matchs",
            "Played Only",
            "Unplayed Only"});
            this.cbxFilters.Location = new System.Drawing.Point(115, 143);
            this.cbxFilters.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbxFilters.Name = "cbxFilters";
            this.cbxFilters.Size = new System.Drawing.Size(217, 31);
            this.cbxFilters.TabIndex = 14;
            this.cbxFilters.SelectedIndexChanged += new System.EventHandler(this.cbxFilters_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(9, 143);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 30);
            this.label2.TabIndex = 15;
            this.label2.Text = "Filter by";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // txtTeamOneScore
            // 
            this.txtTeamOneScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamOneScore.Location = new System.Drawing.Point(429, 283);
            this.txtTeamOneScore.Name = "txtTeamOneScore";
            this.txtTeamOneScore.Size = new System.Drawing.Size(120, 30);
            this.txtTeamOneScore.TabIndex = 16;
            this.txtTeamOneScore.Validating += new System.ComponentModel.CancelEventHandler(this.ValidScore);
            // 
            // frmTournamentViewer
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(585, 565);
            this.Controls.Add(this.txtTeamOneScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbxFilters);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTeamTwoScore);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbTeamTwoName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTeamOneName);
            this.Controls.Add(this.lvMatchList);
            this.Controls.Add(this.cbxRound);
            this.Controls.Add(this.lbRound);
            this.Controls.Add(this.lbTournamentName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmTournamentViewer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tournament Viewer";
            this.Load += new System.EventHandler(this.frmTournamentViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbTournamentName;
        private System.Windows.Forms.Label lbRound;
        private System.Windows.Forms.ComboBox cbxRound;
        private System.Windows.Forms.ListView lvMatchList;
        private System.Windows.Forms.Label lbTeamOneName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTeamTwoScore;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbTeamTwoName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ComboBox cbxFilters;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtTeamOneScore;
    }
}

