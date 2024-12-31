namespace Tournament_Tracker_Project
{
    partial class frmCreateTeam
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
            this.txtTeamName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbxTeamMemberList = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.lbTeamMembers = new System.Windows.Forms.ListBox();
            this.btnCreateTeam = new System.Windows.Forms.Button();
            this.btnDeleteSelectedMember = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCreateMember = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Create Team";
            // 
            // txtTeamName
            // 
            this.txtTeamName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTeamName.Location = new System.Drawing.Point(17, 115);
            this.txtTeamName.Margin = new System.Windows.Forms.Padding(4);
            this.txtTeamName.Name = "txtTeamName";
            this.txtTeamName.Size = new System.Drawing.Size(290, 27);
            this.txtTeamName.TabIndex = 11;
            this.txtTeamName.Validating += new System.ComponentModel.CancelEventHandler(this.IsValidName);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(11, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 29);
            this.label2.TabIndex = 10;
            this.label2.Text = "Team Name";
            // 
            // cbxTeamMemberList
            // 
            this.cbxTeamMemberList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTeamMemberList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTeamMemberList.FormattingEnabled = true;
            this.cbxTeamMemberList.Location = new System.Drawing.Point(19, 199);
            this.cbxTeamMemberList.Margin = new System.Windows.Forms.Padding(4);
            this.cbxTeamMemberList.Name = "cbxTeamMemberList";
            this.cbxTeamMemberList.Size = new System.Drawing.Size(288, 28);
            this.cbxTeamMemberList.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(11, 160);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(246, 29);
            this.label4.TabIndex = 17;
            this.label4.Text = "Select Team Member";
            // 
            // btnAddMember
            // 
            this.btnAddMember.BackColor = System.Drawing.Color.White;
            this.btnAddMember.FlatAppearance.BorderSize = 2;
            this.btnAddMember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnAddMember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnAddMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnAddMember.Location = new System.Drawing.Point(80, 246);
            this.btnAddMember.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(165, 36);
            this.btnAddMember.TabIndex = 19;
            this.btnAddMember.Text = "Add Member";
            this.btnAddMember.UseVisualStyleBackColor = false;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // lbTeamMembers
            // 
            this.lbTeamMembers.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeamMembers.FormattingEnabled = true;
            this.lbTeamMembers.ItemHeight = 23;
            this.lbTeamMembers.Location = new System.Drawing.Point(459, 115);
            this.lbTeamMembers.Margin = new System.Windows.Forms.Padding(4);
            this.lbTeamMembers.Name = "lbTeamMembers";
            this.lbTeamMembers.Size = new System.Drawing.Size(314, 418);
            this.lbTeamMembers.TabIndex = 21;
            // 
            // btnCreateTeam
            // 
            this.btnCreateTeam.BackColor = System.Drawing.Color.White;
            this.btnCreateTeam.FlatAppearance.BorderSize = 2;
            this.btnCreateTeam.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCreateTeam.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCreateTeam.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateTeam.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTeam.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCreateTeam.Location = new System.Drawing.Point(533, 567);
            this.btnCreateTeam.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateTeam.Name = "btnCreateTeam";
            this.btnCreateTeam.Size = new System.Drawing.Size(167, 38);
            this.btnCreateTeam.TabIndex = 28;
            this.btnCreateTeam.Text = "Create Team";
            this.btnCreateTeam.UseVisualStyleBackColor = false;
            this.btnCreateTeam.Click += new System.EventHandler(this.btnCreateTeam_Click);
            // 
            // btnDeleteSelectedMember
            // 
            this.btnDeleteSelectedMember.BackColor = System.Drawing.Color.White;
            this.btnDeleteSelectedMember.FlatAppearance.BorderSize = 2;
            this.btnDeleteSelectedMember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnDeleteSelectedMember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnDeleteSelectedMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteSelectedMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteSelectedMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnDeleteSelectedMember.Location = new System.Drawing.Point(800, 281);
            this.btnDeleteSelectedMember.Margin = new System.Windows.Forms.Padding(4);
            this.btnDeleteSelectedMember.Name = "btnDeleteSelectedMember";
            this.btnDeleteSelectedMember.Size = new System.Drawing.Size(82, 60);
            this.btnDeleteSelectedMember.TabIndex = 29;
            this.btnDeleteSelectedMember.Text = "Delete Selected";
            this.btnDeleteSelectedMember.UseVisualStyleBackColor = false;
            this.btnDeleteSelectedMember.Click += new System.EventHandler(this.btnDeleteSelectedMember_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            this.btnClose.Location = new System.Drawing.Point(836, 4);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(52, 42);
            this.btnClose.TabIndex = 30;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderSize = 2;
            this.btnSearch.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnSearch.Image = global::Tournament_Tracker_Project.Properties.Resources.searching;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(41, 130);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(219, 42);
            this.btnSearch.TabIndex = 34;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCreateMember
            // 
            this.btnCreateMember.BackColor = System.Drawing.Color.White;
            this.btnCreateMember.FlatAppearance.BorderSize = 2;
            this.btnCreateMember.FlatAppearance.MouseDownBackColor = System.Drawing.Color.PaleTurquoise;
            this.btnCreateMember.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.btnCreateMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateMember.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.btnCreateMember.Image = global::Tournament_Tracker_Project.Properties.Resources.AddPerson_32;
            this.btnCreateMember.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateMember.Location = new System.Drawing.Point(41, 61);
            this.btnCreateMember.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreateMember.Name = "btnCreateMember";
            this.btnCreateMember.Size = new System.Drawing.Size(219, 42);
            this.btnCreateMember.TabIndex = 35;
            this.btnCreateMember.Text = "Create Member";
            this.btnCreateMember.UseVisualStyleBackColor = false;
            this.btnCreateMember.Click += new System.EventHandler(this.btnCreateMember_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCreateMember);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(19, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 237);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // frmCreateTeam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(891, 636);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDeleteSelectedMember);
            this.Controls.Add(this.btnCreateTeam);
            this.Controls.Add(this.lbTeamMembers);
            this.Controls.Add(this.btnAddMember);
            this.Controls.Add(this.cbxTeamMemberList);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTeamName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "frmCreateTeam";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Team";
            this.Load += new System.EventHandler(this.frmCreateTeam_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTeamName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxTeamMemberList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.ListBox lbTeamMembers;
        private System.Windows.Forms.Button btnCreateTeam;
        private System.Windows.Forms.Button btnDeleteSelectedMember;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCreateMember;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}