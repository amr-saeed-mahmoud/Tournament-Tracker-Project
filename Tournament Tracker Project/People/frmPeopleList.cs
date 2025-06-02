using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project.People
{
    public partial class frmPeopleList : Form
    {

        DataTable People = new DataTable();

        public frmPeopleList()
        {
            InitializeComponent();
        }

        private async void frmPeopleList_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtFilterValue.Text = "";

            People = await clsPerson.GetAllPeople();

            if (People.Rows.Count > 0)
            {
                dgvPeople.DataSource = People;

                dgvPeople.Columns[0].HeaderText = "PersonID";
                dgvPeople.Columns[0].Width = 110;

                dgvPeople.Columns[1].HeaderText = "National No.";
                dgvPeople.Columns[1].Width = 120;

                dgvPeople.Columns[2].HeaderText = "Full Name";
                dgvPeople.Columns[2].Width = 220;

                dgvPeople.Columns[3].HeaderText = "Email";
                dgvPeople.Columns[3].Width = 183;

                dgvPeople.Columns[4].HeaderText = "Phone";
                dgvPeople.Columns[4].Width = 175;
                lbRowCount.Text = People.Rows.Count.ToString();
            }
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterBy.SelectedIndex == 0)
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
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;
                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "Full Name":
                    FilterColumn = "FullName";
                    break;


                case "Email":
                    FilterColumn = "Email";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
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
            if (FilterColumn != "FullName" && FilterColumn != "Email" && FilterColumn != "Phone" && FilterColumn != "NationalNo" )
                People.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, txtFilterValue.Text.Trim());
            else
                People.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, txtFilterValue.Text.Trim());

            lbRowCount.Text = dgvPeople.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddPerson_Click(object sender, EventArgs e, frmAddEditPerson frm)
        {
            frmAddEditPerson fr = new frmAddEditPerson();
            frm.SavePersonInfo += _RefrechFrm;
            frm.ShowDialog();
        }
        private void _RefrechFrm(object sender, clsPerson e)
        {
            frmPeopleList_Load(null, null);
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow != null)
            {
                int selectedPersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
                frmPersonInfo frm = new frmPersonInfo(selectedPersonID);
                frm.ShowDialog();
                _RefrechFrm(null, null);
            }
            else
            {
                MessageBox.Show("Please select a person from the list first.");
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.SavePersonInfo += _RefrechFrm;
            frm.ShowDialog();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow != null)
            {
                int selectedPersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
                frmAddEditPerson frm = new frmAddEditPerson(selectedPersonID);
                frm.SavePersonInfo += _RefrechFrm;
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a person from the list first.");
            }
        }

        private async void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvPeople.CurrentRow != null)
            {
                if (MessageBox.Show("Are you sure you want to delete Person [" + dgvPeople.CurrentRow.Cells[0].Value + "]", "Confirm Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    int selectedPersonID = (int)dgvPeople.CurrentRow.Cells[0].Value;
                    if (await clsPerson.DeletePerson(selectedPersonID))
                    {
                        MessageBox.Show("Person Deleted Successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _RefrechFrm(null, null);
                    }
                    else
                        MessageBox.Show("Person was not deleted because it has data linked to it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a person from the list first.");
            }
        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void phoneCallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This Feature Is Not Implemented Yet!", "Not Ready!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson();
            frm.SavePersonInfo += _RefrechFrm;
            frm.ShowDialog();
        }
    }
}
