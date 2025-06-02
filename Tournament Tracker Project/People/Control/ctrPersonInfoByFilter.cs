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

namespace Tournament_Tracker_Project.Control
{
    public partial class ctrPersonInfoByFilter : UserControl
    {
        public int PersonID { get { return ctrPersonInfo1.GetPersonID; } }
        public clsPerson CurPerson { get { return ctrPersonInfo1.GetCurPerson; } }
        public bool FilterEnable { set { gbFilters.Enabled = value; } }
        public ctrPersonInfoByFilter()
        {
            InitializeComponent();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnFind.PerformClick();

            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Text = "";
            txtFilterValue.Focus();
        }

        private void _FindNow()
        {
            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrPersonInfo1.LoadInfo(int.Parse(txtFilterValue.Text));

                    break;

                case "National No.":
                    ctrPersonInfo1.LoadInfo(txtFilterValue.Text);
                    break;

                default:
                    break;
            }
            
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FindNow();
        }

        private void txtFilterValue_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFilterValue.Text))
            {
                errorProvider1.SetError(txtFilterValue, "Enter a valid value.");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtFilterValue, null);
        }

        private void ctrPersonInfoByFilter_Load(object sender, EventArgs e)
        {
            txtFilterValue.Focus();
            cbFilterBy.SelectedIndex = 0;
        }
        public void FilterFocus()
        {
            txtFilterValue.Focus();
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtFilterValue.Text = PersonID.ToString();
            _FindNow();
        }
    }
}
