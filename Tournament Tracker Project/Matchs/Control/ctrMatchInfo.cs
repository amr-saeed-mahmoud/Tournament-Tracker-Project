using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project.Matchs.Control
{
    public partial class ctrMatchInfo : UserControl
    {
        public event Action DataUpdated;
        protected virtual void OnUpdateDate() => DataUpdated?.Invoke();

        private int _MatchID = -1;
        public int MatchID { get { return _MatchID; } }

        private clsMatch _Match = new clsMatch();
        public clsMatch Curmatch { get { return _Match; } }

        public ctrMatchInfo()
        {
            InitializeComponent();
        }

        private void _LoadMatchInfo()
        {
            lbMatchID.Text = _Match.MatchID.ToString();

            string Against = _Match.Entries[0].TeamCompeting.TeamName;
            if (_Match.Entries.Count > 1)
                Against += " VS " + _Match.Entries[1].TeamCompeting.TeamName;
            lbAgainst.Text = Against;

            lbWinner.Text = _Match.Winner.TeamID > 0 ? _Match.Winner.TeamName : "Unknown";

            lbRound.Text = _Match.MatchRound.ToString();

            lbIsPlayed.Text = _Match.Winner.TeamID > 0 ? "True" : "False";
        }
        public async void LoadInfo(int MatchID)
        {
            _Match = await clsMatch.FindMatch(MatchID);
            if(_Match == null )
            {
                MessageBox.Show($"Match with match ID {MatchID} not exist.", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _LoadMatchInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmTournamentViewer frm = new frmTournamentViewer(_Match.MatchID, _Match.MatchRound);
            frm.SaveMatchResult += DataBack;
            frm.ShowDialog();
        }

        private void DataBack(object sender, clsMatch match)
        {
            _MatchID = match.MatchID;
            _Match = match;
            LoadInfo(_MatchID);
            OnUpdateDate();
        }
    }
}
