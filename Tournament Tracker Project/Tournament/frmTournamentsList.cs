using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tournament_Tracker_Project.Global_Classes;
using Tournament_Tracker_Project.People;
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project
{
    public partial class frmTournamentsList : Form
    {

        DataTable People = new DataTable();

        public frmTournamentsList()
        {
            InitializeComponent();
        }

        private async void frmTournamentsList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = "";

            People = await clsTournament.GetAllTournamentsInDataTable();

            if (People.Rows.Count > 0)
            {
                dgvTournaments.DataSource = People;

                dgvTournaments.Columns[0].HeaderText = "Tournament ID";
                dgvTournaments.Columns[0].Width = 115;

                dgvTournaments.Columns[1].HeaderText = "TournamentName";
                dgvTournaments.Columns[1].Width = 180;

                dgvTournaments.Columns[2].HeaderText = "Entry Fee";
                dgvTournaments.Columns[2].Width = 155;

                dgvTournaments.Columns[3].HeaderText = "Created by User ID";
                dgvTournaments.Columns[3].Width = 150;
            }
            lbRowCount.Text = People.Rows.Count.ToString();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.SelectedIndex == 0)
                txtFilterValue.Visible = false;
            else txtFilterValue.Visible = true;

            txtFilterValue.Focus();
            txtFilterValue.Text = "";
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "Tournament ID":
                    FilterColumn = "TournamentID";
                    break;
                case "Tournament Name":
                    FilterColumn = "TournamentName";
                    break;

                case "Entry Fee":
                    FilterColumn = "EntryFee";
                    break;


                case "Created by user ID":
                    FilterColumn = "UserID";
                    break;

                
                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                People.DefaultView.RowFilter = "";
                lbRowCount.Text = People.Rows.Count.ToString();
                return;
            }
            if (FilterColumn != "TournamentName")
                People.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                People.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRowCount.Text = dgvTournaments.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text != "Tournament Name")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        
    }
}
