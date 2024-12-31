namespace Tournament_Tracker_Project
{
    partial class frmMainSecreen
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
            this.msMainMenue = new System.Windows.Forms.MenuStrip();
            this.TournamentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TournamentsDashboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMManageApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.CutTournamntToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageMatchstoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ManageTeamsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateTournamentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.peopleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MatchsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.msMainMenue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // msMainMenue
            // 
            this.msMainMenue.BackColor = System.Drawing.Color.White;
            this.msMainMenue.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.msMainMenue.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.msMainMenue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TournamentsToolStripMenuItem,
            this.peopleToolStripMenuItem,
            this.MatchsToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.msMainMenue.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.msMainMenue.Location = new System.Drawing.Point(0, 0);
            this.msMainMenue.Name = "msMainMenue";
            this.msMainMenue.Size = new System.Drawing.Size(1246, 72);
            this.msMainMenue.TabIndex = 3;
            this.msMainMenue.Text = "menuStrip1";
            // 
            // TournamentsToolStripMenuItem
            // 
            this.TournamentsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TournamentsDashboardToolStripMenuItem,
            this.tsMManageApplications,
            this.CutTournamntToolStripMenuItem1,
            this.CreateTournamentToolStripMenuItem});
            this.TournamentsToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.Tournaments64;
            this.TournamentsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TournamentsToolStripMenuItem.Name = "TournamentsToolStripMenuItem";
            this.TournamentsToolStripMenuItem.Size = new System.Drawing.Size(213, 68);
            this.TournamentsToolStripMenuItem.Text = "Tournaments";
            // 
            // TournamentsDashboardToolStripMenuItem
            // 
            this.TournamentsDashboardToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.TournamentsDashboardToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.Tournament_Dashboard_32;
            this.TournamentsDashboardToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.TournamentsDashboardToolStripMenuItem.Name = "TournamentsDashboardToolStripMenuItem";
            this.TournamentsDashboardToolStripMenuItem.Size = new System.Drawing.Size(341, 38);
            this.TournamentsDashboardToolStripMenuItem.Text = "&Tournaments Dashboard";
            this.TournamentsDashboardToolStripMenuItem.Click += new System.EventHandler(this.TournamentsDashboardToolStripMenuItem_Click);
            // 
            // tsMManageApplications
            // 
            this.tsMManageApplications.Image = global::Tournament_Tracker_Project.Properties.Resources.flag;
            this.tsMManageApplications.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsMManageApplications.Name = "tsMManageApplications";
            this.tsMManageApplications.Size = new System.Drawing.Size(341, 38);
            this.tsMManageApplications.Text = "&All Tournaments";
            this.tsMManageApplications.Click += new System.EventHandler(this.tsMManageApplications_Click);
            // 
            // CutTournamntToolStripMenuItem1
            // 
            this.CutTournamntToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ManageMatchstoolStripMenuItem1,
            this.ManageTeamsToolStripMenuItem,
            this.releaseDetainedLicenseToolStripMenuItem});
            this.CutTournamntToolStripMenuItem1.Enabled = false;
            this.CutTournamntToolStripMenuItem1.Image = global::Tournament_Tracker_Project.Properties.Resources.trophy__3_;
            this.CutTournamntToolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CutTournamntToolStripMenuItem1.Name = "CutTournamntToolStripMenuItem1";
            this.CutTournamntToolStripMenuItem1.Size = new System.Drawing.Size(341, 38);
            this.CutTournamntToolStripMenuItem1.Text = "&Current Tournament";
            // 
            // ManageMatchstoolStripMenuItem1
            // 
            this.ManageMatchstoolStripMenuItem1.Image = global::Tournament_Tracker_Project.Properties.Resources.Matchs_Schedule;
            this.ManageMatchstoolStripMenuItem1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageMatchstoolStripMenuItem1.Name = "ManageMatchstoolStripMenuItem1";
            this.ManageMatchstoolStripMenuItem1.Size = new System.Drawing.Size(343, 38);
            this.ManageMatchstoolStripMenuItem1.Text = "Manage &Matchs";
            this.ManageMatchstoolStripMenuItem1.Click += new System.EventHandler(this.ManageMatchstoolStripMenuItem1_Click);
            // 
            // ManageTeamsToolStripMenuItem
            // 
            this.ManageTeamsToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.management;
            this.ManageTeamsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ManageTeamsToolStripMenuItem.Name = "ManageTeamsToolStripMenuItem";
            this.ManageTeamsToolStripMenuItem.Size = new System.Drawing.Size(343, 38);
            this.ManageTeamsToolStripMenuItem.Text = "Manage &Teams";
            // 
            // releaseDetainedLicenseToolStripMenuItem
            // 
            this.releaseDetainedLicenseToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.Question_32;
            this.releaseDetainedLicenseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.releaseDetainedLicenseToolStripMenuItem.Name = "releaseDetainedLicenseToolStripMenuItem";
            this.releaseDetainedLicenseToolStripMenuItem.Size = new System.Drawing.Size(343, 38);
            this.releaseDetainedLicenseToolStripMenuItem.Text = "Tournament &Information";
            this.releaseDetainedLicenseToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenseToolStripMenuItem_Click);
            // 
            // CreateTournamentToolStripMenuItem
            // 
            this.CreateTournamentToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.page;
            this.CreateTournamentToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CreateTournamentToolStripMenuItem.Name = "CreateTournamentToolStripMenuItem";
            this.CreateTournamentToolStripMenuItem.Size = new System.Drawing.Size(341, 38);
            this.CreateTournamentToolStripMenuItem.Text = "&Create Tournament";
            this.CreateTournamentToolStripMenuItem.Click += new System.EventHandler(this.CreateTournamentToolStripMenuItem_Click);
            // 
            // peopleToolStripMenuItem
            // 
            this.peopleToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.People_64;
            this.peopleToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.peopleToolStripMenuItem.Name = "peopleToolStripMenuItem";
            this.peopleToolStripMenuItem.Size = new System.Drawing.Size(153, 68);
            this.peopleToolStripMenuItem.Text = "People";
            this.peopleToolStripMenuItem.Click += new System.EventHandler(this.peopleToolStripMenuItem_Click);
            // 
            // MatchsToolStripMenuItem
            // 
            this.MatchsToolStripMenuItem.Enabled = false;
            this.MatchsToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.Matchs64;
            this.MatchsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.MatchsToolStripMenuItem.Name = "MatchsToolStripMenuItem";
            this.MatchsToolStripMenuItem.Size = new System.Drawing.Size(159, 68);
            this.MatchsToolStripMenuItem.Text = "Matchs";
            this.MatchsToolStripMenuItem.Click += new System.EventHandler(this.MatchsToolStripMenuItem_Click);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.Users_2_64;
            this.employeesToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(141, 68);
            this.employeesToolStripMenuItem.Text = "Users";
            this.employeesToolStripMenuItem.Click += new System.EventHandler(this.employeesToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripSeparator4,
            this.signOutToolStripMenuItem});
            this.closeToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.account_settings_64;
            this.closeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(251, 68);
            this.closeToolStripMenuItem.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.PersonDetails_32;
            this.currentUserInfoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(275, 38);
            this.currentUserInfoToolStripMenuItem.Text = "&Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.Password_32;
            this.changePasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(275, 38);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(272, 6);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = global::Tournament_Tracker_Project.Properties.Resources.sign_out_32__2;
            this.signOutToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(275, 38);
            this.signOutToolStripMenuItem.Text = "Sign &Out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::Tournament_Tracker_Project.Properties.Resources.A_black_image;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1246, 695);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmMainSecreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1246, 695);
            this.Controls.Add(this.msMainMenue);
            this.Controls.Add(this.pictureBox1);
            this.IsMdiContainer = true;
            this.Name = "frmMainSecreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Secreen";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainSecreen_Load);
            this.msMainMenue.ResumeLayout(false);
            this.msMainMenue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip msMainMenue;
        private System.Windows.Forms.ToolStripMenuItem TournamentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TournamentsDashboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMManageApplications;
        private System.Windows.Forms.ToolStripMenuItem CutTournamntToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ManageMatchstoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ManageTeamsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreateTournamentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem peopleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MatchsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenseToolStripMenuItem;
    }
}