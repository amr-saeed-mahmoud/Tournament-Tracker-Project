using System;
using System.ComponentModel;
using System.Windows.Forms;
using Tracker_BusinessLogic;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using Tournament_Tracker_Project.Global_Classes;

namespace Tournament_Tracker_Project
{
    public partial class frmCreateTournament : Form
    {
        public event EventHandler<clsTournament> OnCreateTournamentCompleted;
        protected virtual void RaiseCompleteTournamentCreated(clsTournament tournament) => OnCreateTournamentCompleted.Invoke(this,tournament);


        private decimal CurTotalPrizesMoney = 0;
        private decimal CurPercentage = 0;
        private decimal TotalTournamentMoney = 0;

        List<clsTeam> AllTeams = new List<clsTeam>();
        public clsTournament Tournament = new clsTournament();
        public frmCreateTournament()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTournamentName_Validating(object sender, CancelEventArgs e)
        {
            if (!clsValidation.IsValidName(txtTournamentName.Text.Trim()))
            {
                errorProvider1.SetError(txtTournamentName, "Enter A Valid Tournament Name.");
                e.Cancel = true;
            }
            else errorProvider1.SetError(this, null);
        }

        private void txtEntryFeeValue_Validating(object sender, CancelEventArgs e)
        {
            if(!clsValidation.IsValidNumber(txtEntryFeeValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEntryFeeValue, "Enter A Valid Fees.");
                TotalTournamentMoney = 0;
                CurPercentage = 0;
                CurTotalPrizesMoney = 0;
            }
            else
            {
                TotalTournamentMoney = (Convert.ToDecimal(txtEntryFeeValue.Text.Trim()) * lbTeamsList.Items.Count);
                if (CurTotalPrizesMoney > TotalTournamentMoney)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtEntryFeeValue, $"Total Entry Fee Should be at least equal {CurTotalPrizesMoney}");
                    return;
                }
                errorProvider1.SetError(txtEntryFeeValue, null);
            }
            
        }

        private void FailTeamList()
        {
            foreach(var team in AllTeams)
            {
                cbxTeamList.Items.Add(team.TeamName);
            }
            if(cbxTeamList.Items.Count > 0)
                cbxTeamList.SelectedIndex = 0;
        }
        private async Task GetAllTeams()
        {
            DataTable Teams = await clsTeam.GetAllTeams();
            foreach (DataRow row in Teams.Rows)
            {
                clsTeam team = new clsTeam(Convert.ToInt32(row["TeamID"]), row["TeamName"].ToString());
                AllTeams.Add(team);
            }
        }
        private async void frmCreateTournament_Load(object sender, EventArgs e)
        {
            await GetAllTeams();
            clsGlobel.AllPeople = await clsPerson.GetListOfPerson();
            FailTeamList();

        }

        private void btnAddTeam_Click(object sender, EventArgs e)
        {
            if(cbxTeamList.Items.Count > 0)
            {
                clsTeam Team = AllTeams[cbxTeamList.SelectedIndex];
                Tournament.Teams.Add(Team);// add to teams in tournament object
                lbTeamsList.Items.Add(Team.TeamName); // add team to team's list box
                cbxTeamList.Items.Remove(Team.TeamName);// remove from ComboBox TeamList
                AllTeams.Remove(Team);// remove form all team in list
                if (cbxTeamList.Items.Count > 0)
                    cbxTeamList.SelectedIndex = 0;
            }
            else
                MessageBox.Show("No Selected Item To Add It ,Member List Maybe Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDeleteSelectedTeam_Click(object sender, EventArgs e)
        {
            if (lbTeamsList.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Not Selected Team To remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsTeam SelectedTeam = Tournament.Teams[lbTeamsList.SelectedIndex];
            lbTeamsList.Items.Remove(SelectedTeam.TeamName);// remove from team list'
            Tournament.Teams.Remove(SelectedTeam);// remove from team's in tournament object
            AllTeams.Add(SelectedTeam);// add to all teams
            cbxTeamList.Items.Add(SelectedTeam.TeamName);// add to teams drop list
            if (cbxTeamList.Items.Count == 1)
                cbxTeamList.SelectedIndex = 0;
            txtEntryFeeValue_Validating(txtEntryFeeValue, new CancelEventArgs());// validate the Fee
            
            // add to all people 
            foreach(var Person in SelectedTeam.TeamMember)
            {
                clsGlobel.AllPeople.Add(Person);
            }
        }

        private void lilbCreateTeam_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCreateTeam frm = new frmCreateTeam();
            frm.TeamAdded += CreatedTeamBack;
            frm.ShowDialog();
        }
        private void CreatedTeamBack(object Sender, clsTeam CreatedTeam)
        {
            cbxTeamList.Items.Add(CreatedTeam.TeamName);
            AllTeams.Add(CreatedTeam);
            if(cbxTeamList.Items.Count == 1)
                cbxTeamList.SelectedIndex = 0;
        }

        private void btnCreatePrize_Click(object sender, EventArgs e)
        {
            if (lbTeamsList.Items.Count < 1)
            {
                MessageBox.Show("You Should enter at least one team to create prizes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            txtEntryFeeValue_Validating(txtEntryFeeValue, new CancelEventArgs());
            if (!string.IsNullOrEmpty(txtEntryFeeValue.Text.Trim()) && clsValidation.IsValidNumber(txtEntryFeeValue.Text.Trim()))
            {
                frmCreatePrize frm = new frmCreatePrize(CurPercentage, TotalTournamentMoney - CurTotalPrizesMoney, TotalTournamentMoney);
                frm.OnPrizeCreated += PrizeDataBack;
                frm.ShowDialog();
            }
            else MessageBox.Show("You Should enter a Valid entry fee before create prizes", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void PrizeDataBack(object Sender, clsPrize AddedPrize)
        {
            lbPrizesList.Items.Add($"Place Number: {AddedPrize.PlaceNumber},  PrizeAmount : {AddedPrize.PrizeAmount}");
            Tournament.Prizes.Add(AddedPrize);
            CurPercentage += AddedPrize.PrizePercentage;
            CurTotalPrizesMoney += AddedPrize.PrizeAmount;
        }

        private void btnDeleteSeletedPrize_Click(object sender, EventArgs e)
        {
            if(lbPrizesList.SelectedIndices.Count < 1)
            {
                MessageBox.Show("Not Selected Prize To remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            clsPrize SelectedPrize = Tournament.Prizes[lbPrizesList.SelectedIndices.Count - 1];
            lbPrizesList.Items.RemoveAt(lbPrizesList.SelectedIndices.Count - 1);// remove from Prizes List
            Tournament.Prizes.Remove(SelectedPrize);// remove from Prizes
            lbPrizesList.SelectedIndices.Clear();// clear selected indices
            CurTotalPrizesMoney -= SelectedPrize.PrizeAmount;// remove from Cur total prizes

        }

        private async void btnCreateTournament_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are fields that are not Valid In Add New Member Info. Point to the red dots to read the message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Tournament.TournamentName = txtTournamentName.Text.Trim();
            Tournament.EntryFees = decimal.Parse(txtEntryFeeValue.Text.Trim());
            Tournament.CreatedByUserID = clsGlobel.User.UserID;
            Tournament.CreateAllRounds();

            if(MessageBox.Show("Are you Sure You Want To Create This Tournament", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (await Tournament.SaveTournament())
                {
                    MessageBox.Show("Tournament Added Sucessfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RaiseCompleteTournamentCreated(Tournament);
                }
                else MessageBox.Show("Process is Faild", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
