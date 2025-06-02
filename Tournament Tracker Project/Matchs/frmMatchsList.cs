using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tournament_Tracker_Project.Global_Classes;
using Tournament_Tracker_Project.People;
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project.Matchs
{
    public partial class frmMatchsList : Form
    {
        DataTable Matchs = new DataTable();
        public frmMatchsList()
        {
            InitializeComponent();
        }

        private void _LoadMatchsDataTable()
        {
            int CurRound = clsGlobel.CurTournament.GetCurRoundNumber();

            Matchs = new DataTable();

            Matchs.Columns.Add("Match ID");
            Matchs.Columns.Add("First Team");
            Matchs.Columns.Add("Second Team");
            Matchs.Columns.Add("Winner Team");
            Matchs.Columns.Add("Round");
            Matchs.Columns.Add("IsPlayed", typeof(bool));


            var AllMatchs = clsGlobel.CurTournament.Rounds;

            foreach(List<clsMatch> matchs in AllMatchs)
            {
                foreach(clsMatch match in matchs)
                {
                    if (match.MatchRound > CurRound)
                        return;

                    DataRow row = Matchs.NewRow();
                    row["Match ID"] = match.MatchID;
                    row["First Team"] = match.Entries[0].TeamCompeting.TeamName;
                    row["Second Team"] = match.Entries.Count > 1 ? match.Entries[1].TeamCompeting.TeamName : "Null";
                    row["Winner Team"] = match.Winner.TeamID > 0 ? match.Winner.TeamName : "Unknown";
                    row["Round"] = match.MatchRound;
                    row["IsPlayed"] = match.Winner.TeamID > 0 ? true : false;

                    Matchs.Rows.Add(row);
                }
            }
        }

        private void frmMatchsList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;

            _LoadMatchsDataTable();

            lbRowCount.Text = Matchs.Rows.Count.ToString();

            dgvMatchs.DataSource = Matchs;

            dgvMatchs.Columns[0].HeaderText = "Match ID";
            dgvMatchs.Columns[0].Width = 110;

            dgvMatchs.Columns[1].HeaderText = "First Team";
            dgvMatchs.Columns[1].Width = 150;

            dgvMatchs.Columns[2].HeaderText = "Second Team";
            dgvMatchs.Columns[2].Width = 150;

            dgvMatchs.Columns[3].HeaderText = "Winner Team";
            dgvMatchs.Columns[3].Width = 163;

            dgvMatchs.Columns[4].HeaderText = "Round";
            dgvMatchs.Columns[4].Width = 163;

            dgvMatchs.Columns[5].HeaderText = "Is Played";
            dgvMatchs.Columns[5].Width = 65;

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0 || cbFilterBy.SelectedIndex == 6)
                txtFilterValue.Visible = false;
            else txtFilterValue.Visible = true;

            if (cbFilterBy.SelectedIndex == 6)
            {
                txtFilterValue.Visible = false;
                cbxIsPlayed.Visible = true;
                cbxIsPlayed.SelectedIndex = 0;
                cbxIsPlayed.Focus();
            }
            else
            {
                cbxIsPlayed.Visible = false;
                txtFilterValue.Focus();
            }

            txtFilterValue.Text = "";
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Match ID":
                    FilterColumn = "MatchID";
                    break;
                case "First Team":
                    FilterColumn = "FristTeam";
                    break;

                case "Second Team":
                    FilterColumn = "SecondTeam";
                    break;


                case "Winner Team":
                    FilterColumn = "WinnerTeam";
                    break;

                case "Round":
                    FilterColumn = "Round";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                Matchs.DefaultView.RowFilter = "";
                lbRowCount.Text = Matchs.Rows.Count.ToString();
                return;
            }

            if (FilterColumn != "FirstTeam" && FilterColumn != "SecondTeam" && FilterColumn != "WinnerTeam" && FilterColumn != "IsPlayed")
                Matchs.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                Matchs.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRowCount.Text = dgvMatchs.Rows.Count.ToString();
        }

        private void cbxIsPlayed_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = cbxIsPlayed.Text;
            string SeletedFilter = "IsPlayed";

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Played":
                    FilterValue = "1";
                    break;
                case "Non Played":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                Matchs.DefaultView.RowFilter = "";
            else
                Matchs.DefaultView.RowFilter = string.Format("[{0}] = {1}", SeletedFilter, FilterValue);

            lbRowCount.Text = dgvMatchs.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTournamentViewer_Click(object sender, EventArgs e)
        {
            frmTournamentViewer frm = new frmTournamentViewer();
            frm.SaveMatchResult += RefreshList;
            frm.ShowDialog();
        }

        private void cmsMatch_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (dgvMatchs.CurrentRow != null)
            {
                string Winner = dgvMatchs.CurrentRow.Cells[3].Value.ToString();
                int round = int.Parse(dgvMatchs.CurrentRow.Cells[4].Value.ToString());

                if (round == clsGlobel.CurTournament.GetCurRoundNumber())
                {
                    if (Winner == "Unknown")
                        editToolStripMenuItem.Enabled = true;
                    else
                        editToolStripMenuItem.Enabled = false;
                }
                else editToolStripMenuItem.Enabled = false;
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvMatchs.CurrentRow != null)
            {
                int selectedID;
                int selectedRound;

                if (int.TryParse(dgvMatchs.CurrentRow.Cells[0].Value.ToString(), out selectedID) &&
                    int.TryParse(dgvMatchs.CurrentRow.Cells[4].Value.ToString(), out selectedRound))
                {
                    frmTournamentViewer frm = new frmTournamentViewer(selectedID, selectedRound);
                    frm.SaveMatchResult += RefreshList;
                    frm.ShowDialog();
                }

            }
        }

        private void RefreshList(object sender, clsMatch e)
        {
            frmMatchsList_Load(null,null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int SelectedMatchID = -1;
            if (dgvMatchs.CurrentRow != null)
            {

                if (int.TryParse(dgvMatchs.CurrentRow.Cells[0].Value.ToString(), out int SelectedID))
                {
                    SelectedMatchID = SelectedID;
                    frmMatchInfo frm = new frmMatchInfo(SelectedMatchID);
                    frm.MatchInfoUpdated += RefreshInfo;
                    frm.ShowDialog();
                }
                
            }
        }
        private void RefreshInfo()
        {
            this.Refresh();
        }
        
    }
}
