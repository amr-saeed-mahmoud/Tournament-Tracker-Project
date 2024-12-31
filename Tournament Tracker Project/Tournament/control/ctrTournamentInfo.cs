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
using Tournament_Tracker_Project.Users;
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project.Tournament.control
{
    public partial class ctrTournamentInfo : UserControl
    {
        public ctrTournamentInfo()
        {
            InitializeComponent();
        }


        public void LaodInfo()
        {
            if (clsGlobel.CurTournament.TournamentID <= 0)
                return;

            lbID.Text = clsGlobel.CurTournament.TournamentID.ToString();
            lbName.Text = clsGlobel.CurTournament.TournamentName;
            lbFee.Text = clsGlobel.CurTournament.EntryFees.ToString();
            lbUserID.Text = clsGlobel.CurTournament.CreatedByUserID.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUserInfo frm = new frmUserInfo(clsGlobel.CurTournament.CreatedByUserID);
            frm.ShowDialog();
        }
    }
}
