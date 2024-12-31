using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tournament_Tracker_Project.Global_Classes;
using Tournament_Tracker_Project.Login;
using Tournament_Tracker_Project.Matchs;
using Tournament_Tracker_Project.People;
using Tournament_Tracker_Project.Tournament;
using Tournament_Tracker_Project.Users;

namespace Tournament_Tracker_Project
{
    public partial class frmMainSecreen : Form
    {
        frmLogin _frmLogin;
        public frmMainSecreen(frmLogin frmLogin)
        {
            InitializeComponent();
            _frmLogin = frmLogin;
        }

        private void MatchsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMatchsList frm = new frmMatchsList();
            frm.ShowDialog();
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeopleList frm = new frmPeopleList();
            frm.ShowDialog();
        }

        private void TournamentsDashboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTournamentDashboard frm = new frmTournamentDashboard();
            frm.SelectTournament += OnSelectTournament;
            frm.ShowDialog();
        }
        private void OnSelectTournament()
        {
            MatchsToolStripMenuItem.Enabled = true;
            CutTournamntToolStripMenuItem1.Enabled = true;
        }

        private void frmMainSecreen_Load(object sender, EventArgs e)
        {
            //TournamentsDashboardToolStripMenuItem.PerformClick();
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersList frm = new frmUsersList();
            frm.ShowDialog();
        }

        private void tsMManageApplications_Click(object sender, EventArgs e)
        {
            frmTournamentsList frm = new frmTournamentsList();
            frm.ShowDialog();
        }

        private void releaseDetainedLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCurTournamentInfo frm = new frmCurTournamentInfo();
            frm.ShowDialog();
        }

        private void ManageMatchstoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmTournamentViewer frm = new frmTournamentViewer();
            frm.ShowDialog();
        }

        private void CreateTournamentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCreateTournament frm = new frmCreateTournament();
            frm.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobel.User.UserID);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangeUserPassowd frm = new frmChangeUserPassowd(clsGlobel.User.UserID);
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobel.User = null;
            _frmLogin.Show();
            this.Close();
        }
    }
}
