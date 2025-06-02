namespace Tournament_Tracker_Project
{
    partial class frmCreateTournament
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTournamentName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEntryFeeValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lilbCreateTeam = new System.Windows.Forms.LinkLabel();
            this.btnAddTeam = new System.Windows.Forms.Button();
            this.cbxTeamList = new System.Windows.Forms.ComboBox();
            this.btnCreatePrize = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnDeleteSelectedTeam = new System.Windows.Forms.Button();
            this.btnDeleteSeletedPrize = new System.Windows.Forms.Button();
            this.btnCreateTournament = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lbTeamsList = new System.Windows.Forms.ListBox();
            this.lbPrizesList = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Create Tournament";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(11, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tournament Name";
            // 
            // txtTournamentName
            // 
            this.txtTournamentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTournamentName.Location = new System.Drawing.Point(16, 131);
            this.txtTournamentName.Name = "txtTournamentName";
            this.txtTournamentName.Size = new System.Drawing.Size(265, 27);
            this.txtTournamentName.TabIndex = 9;
            this.txtTournamentName.Validating += new System.ComponentModel.CancelEventHandler(this.txtTournamentName_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(12, 176);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 29);
            this.label3.TabIndex = 10;
            this.label3.Text = "Entry Fee";
            // 
            // txtEntryFeeValue
            // 
            this.txtEntryFeeValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntryFeeValue.Location = new System.Drawing.Point(135, 176);
            this.txtEntryFeeValue.Name = "txtEntryFeeValue";
            this.txtEntryFeeValue.Size = new System.Drawing.Size(110, 27);
            this.txtEntryFeeValue.TabIndex = 11;
            this.txtEntryFeeValue.Validating += new System.ComponentModel.CancelEventHandler(this.txtEntryFeeValue_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(11, 242);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 29);
            this.label4.TabIndex = 12;
            this.label4.Text = "Select Team";
            // 
            // lilbCreateTeam
            // 
            this.lilbCreateTeam.AutoSize = true;
            this.lilbCreateTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lilbCreateTeam.Location = new System.Drawing.Point(193, 246);
            this.lilbCreateTeam.Name = "lilbCreateTeam";
            this.lilbCreateTeam.Size = new System.Drawing.Size(106, 20);
            this.lilbCreateTeam.TabIndex = 14;
            this.lilbCreateTeam.TabStop = true;
            this.lilbCreateTeam.Text = "Create Team";
            this.lilbCreateTeam.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lilbCreateTeam_LinkClicked);
            // 
            // btnAddTeam
            // 
            this.btnAddTeam.BackColor = System.Drawing.Color.White;
            this.btnAddTeam.FlatAppearance.BorderSize = 2;
            this.btnAddTeam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnAddTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAddTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnAddTeam.Location = new System.Drawing.Point(92, 318);
            this.btnAddTeam.Name = "btnAddTeam";
            this.btnAddTeam.Size = new System.Drawing.Size(113, 43);
            this.btnAddTeam.TabIndex = 15;
            this.btnAddTeam.Text = "Add Team";
            this.btnAddTeam.UseVisualStyleBackColor = false;
            this.btnAddTeam.Click += new System.EventHandler(this.btnAddTeam_Click);
            // 
            // cbxTeamList
            // 
            this.cbxTeamList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTeamList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTeamList.FormattingEnabled = true;
            this.cbxTeamList.Location = new System.Drawing.Point(16, 274);
            this.cbxTeamList.Name = "cbxTeamList";
            this.cbxTeamList.Size = new System.Drawing.Size(265, 28);
            this.cbxTeamList.TabIndex = 16;
            // 
            // btnCreatePrize
            // 
            this.btnCreatePrize.BackColor = System.Drawing.Color.White;
            this.btnCreatePrize.FlatAppearance.BorderSize = 2;
            this.btnCreatePrize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCreatePrize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCreatePrize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePrize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePrize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCreatePrize.Location = new System.Drawing.Point(90, 381);
            this.btnCreatePrize.Name = "btnCreatePrize";
            this.btnCreatePrize.Size = new System.Drawing.Size(209, 43);
            this.btnCreatePrize.TabIndex = 17;
            this.btnCreatePrize.Text = "Create Prize";
            this.btnCreatePrize.UseVisualStyleBackColor = false;
            this.btnCreatePrize.Click += new System.EventHandler(this.btnCreatePrize_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label5.Location = new System.Drawing.Point(350, 88);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 26);
            this.label5.TabIndex = 19;
            this.label5.Text = "Teams / Players";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label6.Location = new System.Drawing.Point(350, 290);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 26);
            this.label6.TabIndex = 21;
            this.label6.Text = "Prizes";
            // 
            // btnDeleteSelectedTeam
            // 
            this.btnDeleteSelectedTeam.BackColor = System.Drawing.Color.White;
            this.btnDeleteSelectedTeam.FlatAppearance.BorderSize = 2;
            this.btnDeleteSelectedTeam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDeleteSelectedTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnDeleteSelectedTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelectedTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSelectedTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDeleteSelectedTeam.Location = new System.Drawing.Point(660, 164);
            this.btnDeleteSelectedTeam.Name = "btnDeleteSelectedTeam";
            this.btnDeleteSelectedTeam.Size = new System.Drawing.Size(88, 66);
            this.btnDeleteSelectedTeam.TabIndex = 22;
            this.btnDeleteSelectedTeam.Text = "Delete Selected";
            this.btnDeleteSelectedTeam.UseVisualStyleBackColor = false;
            this.btnDeleteSelectedTeam.Click += new System.EventHandler(this.btnDeleteSelectedTeam_Click);
            // 
            // btnDeleteSeletedPrize
            // 
            this.btnDeleteSeletedPrize.BackColor = System.Drawing.Color.White;
            this.btnDeleteSeletedPrize.FlatAppearance.BorderSize = 2;
            this.btnDeleteSeletedPrize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDeleteSeletedPrize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnDeleteSeletedPrize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSeletedPrize.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSeletedPrize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDeleteSeletedPrize.Location = new System.Drawing.Point(660, 369);
            this.btnDeleteSeletedPrize.Name = "btnDeleteSeletedPrize";
            this.btnDeleteSeletedPrize.Size = new System.Drawing.Size(88, 66);
            this.btnDeleteSeletedPrize.TabIndex = 23;
            this.btnDeleteSeletedPrize.Text = "Delete Selected";
            this.btnDeleteSeletedPrize.UseVisualStyleBackColor = false;
            this.btnDeleteSeletedPrize.Click += new System.EventHandler(this.btnDeleteSeletedPrize_Click);
            // 
            // btnCreateTournament
            // 
            this.btnCreateTournament.BackColor = System.Drawing.Color.White;
            this.btnCreateTournament.FlatAppearance.BorderSize = 2;
            this.btnCreateTournament.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCreateTournament.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCreateTournament.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTournament.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTournament.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCreateTournament.Location = new System.Drawing.Point(173, 536);
            this.btnCreateTournament.Name = "btnCreateTournament";
            this.btnCreateTournament.Size = new System.Drawing.Size(419, 43);
            this.btnCreateTournament.TabIndex = 24;
            this.btnCreateTournament.Text = "Create Tournament";
            this.btnCreateTournament.UseVisualStyleBackColor = false;
            this.btnCreateTournament.Click += new System.EventHandler(this.btnCreateTournament_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 4;
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Image = global::Tournament_Tracker_Project.Properties.Resources.closeBlack32;
            this.btnClose.Location = new System.Drawing.Point(718, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 42);
            this.btnClose.TabIndex = 31;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // lbTeamsList
            // 
            this.lbTeamsList.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeamsList.FormattingEnabled = true;
            this.lbTeamsList.ItemHeight = 23;
            this.lbTeamsList.Location = new System.Drawing.Point(354, 126);
            this.lbTeamsList.Name = "lbTeamsList";
            this.lbTeamsList.Size = new System.Drawing.Size(291, 142);
            this.lbTeamsList.TabIndex = 32;
            // 
            // lbPrizesList
            // 
            this.lbPrizesList.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPrizesList.FormattingEnabled = true;
            this.lbPrizesList.ItemHeight = 23;
            this.lbPrizesList.Location = new System.Drawing.Point(354, 331);
            this.lbPrizesList.Name = "lbPrizesList";
            this.lbPrizesList.Size = new System.Drawing.Size(291, 142);
            this.lbPrizesList.TabIndex = 33;
            // 
            // frmCreateTournament
            // 
            this.AcceptButton = this.btnCreateTournament;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(773, 599);
            this.Controls.Add(this.lbPrizesList);
            this.Controls.Add(this.lbTeamsList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCreateTournament);
            this.Controls.Add(this.btnDeleteSeletedPrize);
            this.Controls.Add(this.btnDeleteSelectedTeam);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCreatePrize);
            this.Controls.Add(this.cbxTeamList);
            this.Controls.Add(this.btnAddTeam);
            this.Controls.Add(this.lilbCreateTeam);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtEntryFeeValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTournamentName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "frmCreateTournament";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Tournament";
            this.Load += new System.EventHandler(this.frmCreateTournament_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTournamentName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEntryFeeValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel lilbCreateTeam;
        private System.Windows.Forms.Button btnAddTeam;
        private System.Windows.Forms.ComboBox cbxTeamList;
        private System.Windows.Forms.Button btnCreatePrize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDeleteSelectedTeam;
        private System.Windows.Forms.Button btnDeleteSeletedPrize;
        private System.Windows.Forms.Button btnCreateTournament;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ListBox lbTeamsList;
        private System.Windows.Forms.ListBox lbPrizesList;
    }
}