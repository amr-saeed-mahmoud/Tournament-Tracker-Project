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

namespace Tournament_Tracker_Project.Users
{
    public partial class frmChangeUserPassowd : Form
    {
        int _UserID = -1;
        clsUser _User;

        public frmChangeUserPassowd(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
        }



        private void SetDefaultValues()
        {
            txtCurrentPassword.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            txtCurrentPassword.Focus();
        }

        private async void frmChangeUserPassowd_Load(object sender, EventArgs e)
        {
            SetDefaultValues();

            _User = await clsUser.FindUserByUserID(_UserID);
            if (_User == null)
            {
                MessageBox.Show("Could not Find User With ID = " + _UserID, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrUserInfo1.LoadInfo(_UserID);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _User.Password = txtPassword.Text.Trim();

            if (await _User.Save())
            {
                MessageBox.Show("Password Changed successfully", "Info",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                SetDefaultValues();
            }
            else
            {
                MessageBox.Show("Unsuccessfull Process", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtCurrentPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtCurrentPassword, "This Feild Is Require");
                e.Cancel = true;
            }
            else errorProvider1.SetError(txtCurrentPassword, null);

            if (txtCurrentPassword.Text.Trim() != _User.Password)
                errorProvider1.SetError(txtCurrentPassword, "Current Password Is Wrong");
            else errorProvider1.SetError(txtCurrentPassword, null);
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "This Feild Is Require");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password Not Equel New Password");
                e.Cancel = true;
            }
            else errorProvider1.SetError(txtConfirmPassword, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
