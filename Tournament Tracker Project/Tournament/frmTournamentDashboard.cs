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
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project
{
    public partial class frmTournamentDashboard : Form
    {
        public event Action SelectTournament;

        protected virtual void OnSelectTournament() => SelectTournament?.Invoke();

        List<clsTournament> Tournaments = new List<clsTournament>();
        public frmTournamentDashboard()
        {
            InitializeComponent();
        }

        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            frmCreateTournament frm = new frmCreateTournament();
            frm.OnCreateTournamentCompleted += HandelDataBack;
            frm.ShowDialog();
        }
        private void HandelDataBack(object sender, clsTournament CreatedTournament)
        {
            cbxTournamentList.Items.Add(CreatedTournament.TournamentName);
            Tournaments.Add(CreatedTournament);
            if (cbxTournamentList.Items.Count == 1)
                cbxTournamentList.SelectedIndex = 0;
        }

        private async void frmTournamentDashboard_Load(object sender, EventArgs e)
        {
            await LoadAllTournament();
            if (cbxTournamentList.Items.Count > 0)
                cbxTournamentList.SelectedIndex = 0;
        }

        private async Task LoadAllTournament()
        {
            Tournaments = await clsTournament.GetAllTournaments();
            AddTournamentsToComcoBox();
        }
        private void AddTournamentsToComcoBox()
        {
            foreach(clsTournament CurTournament in Tournaments)
            {
                cbxTournamentList.Items.Add(CurTournament.TournamentName);
            }
        }

        private async void btnLoadTournament_Click(object sender, EventArgs e)
        {
            if(cbxTournamentList.Items.Count == 0)
            {
                MessageBox.Show("No Tournament Selected To Load.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            clsGlobel.CurTournament = Tournaments[cbxTournamentList.SelectedIndex];
            clsGlobel.CurTournament.Rounds = await clsMatch.GetAllMatchsByTournamentID(clsGlobel.CurTournament.TournamentID);
            MessageBox.Show($"{clsGlobel.CurTournament.TournamentName} Loaded successfully.", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            OnSelectTournament();
        }
    }
}
