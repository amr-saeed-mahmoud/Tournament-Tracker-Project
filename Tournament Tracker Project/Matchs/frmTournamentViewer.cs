using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tournament_Tracker_Project.Global_Classes;
using Tracker_BusinessLogic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tournament_Tracker_Project
{
    public partial class frmTournamentViewer : Form
    {

        public event EventHandler<clsMatch> SaveMatchResult;

        protected virtual void OnSaveResult(clsMatch match) => SaveMatchResult?.Invoke(this,match);

        private int TournamentID;

        private int SelectedMatchID = -1;
        private int SelectedRound = -1;

        private List<clsMatch> MatchsInFilterList = new List<clsMatch>();

        delegate bool LoadStates(clsMatch match);

        private LoadStates _LastStates = _AllMatchs;

        private static bool _UnplayedMatchs(clsMatch match) => match.Winner.TeamID <= 0;
        private static bool _PlayedMatchs(clsMatch match) => match.Winner.TeamID > 0;
        private static bool _AllMatchs(clsMatch match) => 1 == 1;

        public frmTournamentViewer()
        {
            InitializeComponent();
            TournamentID = clsGlobel.CurTournament.TournamentID;
        }
        public frmTournamentViewer(int SelectedMatchID, int SelectedRound)
        {
            InitializeComponent();
            TournamentID = clsGlobel.CurTournament.TournamentID;
            this.SelectedMatchID = SelectedMatchID;
            this.SelectedRound = SelectedRound;
        }

        private void _LoadMatchestInRoundBasedOnStates(int SelectedRound, LoadStates States)
        {
            lvMatchList.Items.Clear();
            MatchsInFilterList.Clear();
            foreach (clsMatch match in clsGlobel.CurTournament.Rounds[SelectedRound-1])
            {
                if (States(match))
                {
                    string recourd = match.Entries[0].TeamCompeting.TeamName;
                    if (match.Entries.Count > 1)
                        recourd += $" VS {match.Entries[1].TeamCompeting.TeamName}";
                    lvMatchList.Items.Add(recourd);
                    MatchsInFilterList.Add(match);
                }
            }
            _LastStates = States;
        }

        private void _LoadRounds(LoadStates States)
        {
            int NumberOfAvaliableRound =  clsGlobel.CurTournament.GetCurRoundNumber();
            
            cbxRound.Items.Clear();

            for (int i = 1; i <= NumberOfAvaliableRound; ++i)
            {
                cbxRound.Items.Add((i).ToString());
            }
            cbxRound.SelectedIndex = NumberOfAvaliableRound - 1;

            _LoadMatchestInRoundBasedOnStates(NumberOfAvaliableRound, States);
        }

        private void frmTournamentViewer_Load(object sender, EventArgs e)
        {
            lbTournamentName.Text = clsGlobel.CurTournament.TournamentName;// set tournament Name
            _LoadRounds(_AllMatchs);
            cbxFilters.SelectedIndex = 0;

            if(SelectedMatchID > 0)
            {
                cbxRound.SelectedIndex = SelectedRound - 1;
                int Index = clsGlobel.CurTournament.Rounds[SelectedRound-1].FindIndex(match => match.MatchID == SelectedMatchID);

                foreach (ListViewItem item in lvMatchList.Items)
                {
                    if (Index == 0)
                    {
                        item.Focused = true;
                        item.Selected = true;
                        item.Checked = true;
                        //lvMatchList.Select();
                    }
                    Index--;
                }
            }


        }

        private void cbxFilters_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedRound = cbxRound.SelectedIndex + 1;

            if (cbxFilters.SelectedIndex == 0)
                _LoadMatchestInRoundBasedOnStates(SelectedRound, _AllMatchs);
            else if (cbxFilters.SelectedIndex == 1)
                _LoadMatchestInRoundBasedOnStates(SelectedRound, _PlayedMatchs);
            else
                _LoadMatchestInRoundBasedOnStates(SelectedRound, _UnplayedMatchs);
        }

        private void lvMatchList_SelectedIndexChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            int SelectedMatchIndex = lvMatchList.FocusedItem.Index;
            // set teams name

            clsMatch CurMatch = MatchsInFilterList[SelectedMatchIndex];

            if (CurMatch.Entries.Count == 1)
            {
                btnSave.Enabled = false;
                // handel first team
                lbTeamOneName.Text = CurMatch.Entries[0].TeamCompeting.TeamName;
                txtTeamOneScore.Text = "0";
                txtTeamOneScore.Enabled = false;
                // handel second team
                lbTeamTwoName.Text = "Second Team Not Exists";
                lbTeamTwoName.Enabled = false;
                txtTeamTwoScore.Enabled = false;
            }
            else
            {
                
                lbTeamOneName.Text = CurMatch.Entries[0].TeamCompeting.TeamName;// set first team Name

                lbTeamTwoName.Text = CurMatch.Entries[1].TeamCompeting.TeamName;// set second team Name
                lbTeamTwoName.Enabled = true;

                if (CurMatch.Winner.TeamID > 0) // if the match is played
                {
                    btnSave.Enabled = false;

                    // handel first team
                    txtTeamOneScore.Text = $"{CurMatch.Entries[0].Score}";
                    txtTeamOneScore.Enabled = false;

                    // handel second team
                    txtTeamTwoScore.Text = $"{CurMatch.Entries[1].Score}";
                    txtTeamTwoScore.Enabled = false;
                }
                else// if the match not played
                {
                    btnSave.Enabled = true;

                    txtTeamOneScore.Text = "";
                    txtTeamOneScore.Enabled = true;

                    txtTeamTwoScore.Text = "";
                    txtTeamTwoScore.Enabled = true;
                    
                }

            }
            
        }

        private void ValidScore(object sender, CancelEventArgs e)
        {
            System.Windows.Forms.TextBox CurTextBox = (System.Windows.Forms.TextBox)sender;
            string Score = CurTextBox.Text.Trim();

            if (!Regex.IsMatch(Score, @"\b[0-9]+\b"))
            {
                errorProvider1.SetError(CurTextBox, "Enter A Valid Score.");
                e.Cancel = true;
            }
            else errorProvider1.SetError(CurTextBox, null);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("There are fields that are not Valid. Point to the red dots to read the message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int SelectedMatchIndexInFilteredList = lvMatchList.FocusedItem.Index;
            int SelectedRoundIndex = cbxRound.SelectedIndex;

            clsMatch CurMatch = MatchsInFilterList[SelectedMatchIndexInFilteredList];

            CurMatch.Entries[0].Score = int.Parse(txtTeamOneScore.Text.Trim());
            CurMatch.Entries[1].Score = int.Parse(txtTeamTwoScore.Text.Trim());

            if(MessageBox.Show("Are You Sure You Want Save The Match Result", "Question", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (await CurMatch.SaveMatchResult())
                {
                    // update result in globel class  (match in tournament)
                    List<clsMatch> AllMatchsInRound = clsGlobel.CurTournament.Rounds[SelectedRoundIndex];
                    clsMatch OldMatch = AllMatchsInRound.FirstOrDefault(match => match.MatchID == CurMatch.MatchID);
                    int IndexOldMatch = AllMatchsInRound.IndexOf(OldMatch);
                    AllMatchsInRound[IndexOldMatch] = CurMatch;

                    if (!await clsGlobel.CurTournament.HandelMatchInNextRound(CurMatch))
                    {
                        MessageBox.Show("Unsecssesful Proces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int CurRound = clsGlobel.CurTournament.GetCurRoundNumber();
                    if (CurMatch.MatchRound != CurRound)
                    {
                        int IndexMatch = 0;
                        int IndexEntry = 0;
                        List<clsMatch> NextRound = clsGlobel.CurTournament.Rounds[CurRound-1];

                        foreach (var match in AllMatchsInRound)
                        {
                            if (IndexEntry > 1)
                            {
                                IndexEntry = 0;
                                IndexMatch++;
                            }

                            NextRound[IndexMatch].Entries[IndexEntry].TeamCompeting = match.Winner;
                            IndexEntry++;
                        }
                    }
                    btnSave.Enabled = false;

                    _LoadRounds(_LastStates);

                    MessageBox.Show("Match Saved Sucessfully.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnSaveResult(CurMatch);
                }
                else MessageBox.Show("Unsecssesful Proces.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void cbxRound_SelectedIndexChanged(object sender, EventArgs e)
        {
            int SelectedRound = cbxRound.SelectedIndex + 1;
            _LoadMatchestInRoundBasedOnStates(SelectedRound, _LastStates);
        }
    }
}
