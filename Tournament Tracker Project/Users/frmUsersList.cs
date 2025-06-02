using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tournament_Tracker_Project.Matchs;
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project.Users
{
    public partial class frmUsersList : Form
    {
        DataTable AllUsers = new DataTable();
        public frmUsersList()
        {
            InitializeComponent();
        }

        private async void frmUsersList_Load(object sender, EventArgs e)
        {
            AllUsers = await clsUser.GetAllUsers();
            lbRowCount.Text = AllUsers.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

            if (AllUsers.Rows.Count > 0)
            {
                dgvUsers.DataSource = AllUsers;

                dgvUsers.Columns[0].HeaderText = "User ID";
                dgvUsers.Columns[0].Width = 110;

                dgvUsers.Columns[1].HeaderText = "Person ID";
                dgvUsers.Columns[1].Width = 111;

                dgvUsers.Columns[2].HeaderText = "Full Name";
                dgvUsers.Columns[2].Width = 177;

                dgvUsers.Columns[3].HeaderText = "UserName";
                dgvUsers.Columns[3].Width = 112;

                dgvUsers.Columns[4].HeaderText = "Is Active";
                dgvUsers.Columns[4].Width = 90;
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "Is Active")
            {
                txtFilterValue.Visible = false;
                cbIsActive.Visible = true;
                cbIsActive.SelectedIndex = 0;
                cbIsActive.Focus();
            }
            else
            {
                cbIsActive.Visible = false;
                txtFilterValue.Visible = (cbFilterBy.Text != "None");
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
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;
            }

            if (txtFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                AllUsers.DefaultView.RowFilter = "";
                lbRowCount.Text = AllUsers.Rows.Count.ToString();
                return;
            }
            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                AllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                AllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRowCount.Text = dgvUsers.Rows.Count.ToString();

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilterValue = cbIsActive.Text;
            string SeletedFilter = "IsActive";

            switch (FilterValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilterValue = "1";
                    break;
                case "No":
                    FilterValue = "0";
                    break;
            }

            if (FilterValue == "All")
                AllUsers.DefaultView.RowFilter = "";
            else
                AllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", SeletedFilter, FilterValue);

            lbRowCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "Person ID" || cbFilterBy.Text == "User ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int SelectedUserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

                frmUserInfo frm = new frmUserInfo(SelectedUserID);
                frm.ShowDialog();
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdateUser frm = new frmAddUpdateUser();
            frm.SaveUser += refreshFrom;
            frm.ShowDialog();
        }

        private void refreshFrom(object sender, clsUser user)
        {
            frmUsersList_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvUsers.CurrentRow != null)
            {
                int SelectedUserID = (int)dgvUsers.CurrentRow.Cells[0].Value;

                frmAddUpdateUser frm = new frmAddUpdateUser(SelectedUserID);
                frm.SaveUser += refreshFrom;
                frm.ShowDialog();
            }
        }
    }
}
