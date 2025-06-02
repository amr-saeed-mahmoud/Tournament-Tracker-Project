using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tournament_Tracker_Project.Global_Classes;
using Tracker_BusinessLogic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Tournament_Tracker_Project
{
    public partial class frmCreateTeam : Form
    {
        public event EventHandler<clsTeam> TeamAdded;
        protected virtual void OnTeamAdded(clsTeam Team) => TeamAdded?.Invoke(this, Team);

        clsTeam Team = new clsTeam();

        public frmCreateTeam()
        {
            InitializeComponent();
        }

        private void frmCreateTeam_Load(object sender, EventArgs e)
        {
            FailTeamMember();
        }

        private void FailTeamMember()
        {
            
            foreach (clsPerson Person in clsGlobel.AllPeople)
                cbxTeamMemberList.Items.Add(Person.FirstName + " " + Person.LastName);
            if(cbxTeamMemberList.Items.Count > 0)
                cbxTeamMemberList.SelectedIndex = 0;
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            if(cbxTeamMemberList.Items.Count > 0 && cbxTeamMemberList.SelectedIndex > -1)
            {
                clsPerson SelectedPerson = clsGlobel.AllPeople[cbxTeamMemberList.SelectedIndex];
                Team.AddNewMemberToTeamList(SelectedPerson);// add Person to team member list
                lbTeamMembers.Items.Add($"{SelectedPerson.FirstName} {SelectedPerson.LastName}");// add it to list view
                cbxTeamMemberList.Items.RemoveAt(cbxTeamMemberList.SelectedIndex);// remove selected item after add it to list view
                clsGlobel.AllPeople.Remove(SelectedPerson); // remove selected person from people list
                if (cbxTeamMemberList.Items.Count > 0)// change selected item
                    cbxTeamMemberList.SelectedIndex = 0;

                
            }
            else
            {
                MessageBox.Show("No Selected Item To Add It ,Member List Maybe Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
        private bool NewMemberInofIsValid = true;

        private void IsValidName(object Sender, CancelEventArgs e)
        {
            TextBox Input = (TextBox)Sender;
            if (!clsValidation.IsValidName(Input.Text.Trim()))
            {
                if (Input.Name != "txtTeamName")
                    NewMemberInofIsValid = false;
                e.Cancel = true;
                errorProvider1.SetError(Input, "Enter A Vlaid Name");
            }
            else errorProvider1.SetError(Input, null);
        }

        



        private void btnCreateTeam_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTeamName.Text.Trim()))
            {
                IsValidName(txtTeamName, new CancelEventArgs());
                MessageBox.Show("Enter A Valid Team Name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else Team.TeamName = txtTeamName.Text;// if txtTeamName Correct then Add TeamName To Team object

            if (lbTeamMembers.Items.Count < 1)
            {
                MessageBox.Show("The Team Should Have at least one player", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(MessageBox.Show("Are you Sure You Want To Create This Team", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (Team.Save().Result)
                {
                    MessageBox.Show("The Team Added Sucessfuly", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OnTeamAdded(Team);
                }
                else
                    MessageBox.Show("Unsucessful Process", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                frmCreateTeam_Load(null, null);
            }

        }

        private void btnDeleteSelectedMember_Click(object sender, EventArgs e)
        {
            if (lbTeamMembers.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Not Selected Person To remove", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            clsPerson SelectedPerson = Team.TeamMember[lbTeamMembers.SelectedIndex];// get selected person
            lbTeamMembers.Items.RemoveAt(lbTeamMembers.SelectedIndex);// remove from Team Members List
            Team.RemoveMemberFromTeamList(SelectedPerson);// remove from Team object member 
            clsGlobel.AllPeople.Add(SelectedPerson);// add it to people
            lbTeamMembers.SelectedIndices.Clear(); // clear selected indices
            cbxTeamMemberList.Items.Add($"{SelectedPerson.FirstName} {SelectedPerson.LastName}");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmAddPlayerBySearchFilter frm = new frmAddPlayerBySearchFilter();
            frm.SelectedPerson += AddReturnedPlayerToTeam;
            frm.ShowDialog();
        }

        private void AddReturnedPlayerToTeam(object sender, clsPerson e)
        {
            Team.AddNewMemberToTeamList(e);// add Person to team member list
            lbTeamMembers.Items.Add($"{e.FirstName} {e.LastName}");// add it to list view

            clsPerson personToRemove = clsGlobel.AllPeople.FirstOrDefault(person => e.PersonID == person.PersonID);
            if (personToRemove != null)
            {
                clsGlobel.AllPeople.Remove(personToRemove);
                cbxTeamMemberList.Items.Remove(personToRemove.FirstName + " " + personToRemove.LastName);
                if (cbxTeamMemberList.SelectedIndex < 0 && cbxTeamMemberList.Items.Count > 0)
                    cbxTeamMemberList.SelectedIndex = 0;
                    
            }
        }

        private void btnCreateMember_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.SavePersonInfo += AddReturnedPlayerToTeam;
            frm.ShowDialog();
        }


       
    }
}
