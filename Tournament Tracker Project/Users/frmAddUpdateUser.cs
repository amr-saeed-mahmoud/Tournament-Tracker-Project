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
    public partial class frmAddUpdateUser : Form
    {
        public event EventHandler<clsUser> SaveUser;

        protected virtual void OnSaveUser(clsUser user) => SaveUser?.Invoke(this, user);

        public enum enMode { add, Update};
        private enMode _Mode = enMode.add;

        private int _UserID = -1;
        private clsUser _User = new clsUser();

        public frmAddUpdateUser()
        {
            InitializeComponent();
            _Mode = enMode.add;
        }
        public frmAddUpdateUser(int UserID)
        {
            InitializeComponent();
            this._UserID = UserID;
            _Mode = enMode.Update;
        }

        private void SetDefultValues()
        {
            switch (_Mode)
            {
                case enMode.add:
                    lbTitle.Text = "Add New User";
                    this.Text = "Add New User";
                    _User = new clsUser();
                    tgLoginInfo.Enabled = false;
                    ctrPersonInfoByFilter1.FilterFocus();
                    break;
                case enMode.Update:
                    lbTitle.Text = "Update User";
                    this.Text = "Update User";
                    btnSave.Enabled = true;
                    tgLoginInfo.Enabled = true;
                    break;
            }
            lblUserID.Text = "???";
            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            chkIsActive.Checked = true;

        }

        private async void LoadData()
        {
            _User = await clsUser.FindUserByUserID(_UserID);
            ctrPersonInfoByFilter1.FilterEnable = false;
            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _UserID, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            chkIsActive.Checked = _User.IsActive;
            ctrPersonInfoByFilter1.LoadPersonInfo(_User.UserInfo.PersonID);
        }

        private void frmAddUpdateUser_Load(object sender, EventArgs e)
        {
            SetDefultValues();
            if (_Mode == enMode.Update)
                LoadData();
        }

        private async void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                tgLoginInfo.Enabled = true;
                btnSave.Enabled = true;
                tabUserInfoSecreen.SelectedIndex = 1;
                return;
            }
            int x = ctrPersonInfoByFilter1.PersonID;
            if (ctrPersonInfoByFilter1.PersonID != -1)
            {

                if (await clsUser.IsUserExistByPersonID(ctrPersonInfoByFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrPersonInfoByFilter1.FilterFocus();
                }
                else
                {
                    btnSave.Enabled = true;
                    tgLoginInfo.Enabled = true;
                    tabUserInfoSecreen.SelectedIndex = 1;
                }
            }
            else
            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrPersonInfoByFilter1.FilterFocus();

            }
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

            _User.UserInfo.PersonID = ctrPersonInfoByFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = chkIsActive.Checked;

            if (await _User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                lbTitle.Text = "Update User";
                this.Text = "Update User";
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                OnSaveUser(_User);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private async void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                errorProvider1.SetError(txtUserName, "This Field Is Reqired");
                e.Cancel = true;
                return;
            }
            else errorProvider1.SetError(txtUserName, null);

            if (_Mode == enMode.add)
            {
                if (await clsUser.IsUserExistByUserName(txtUserName.Text.Trim()))
                {
                    errorProvider1.SetError(txtUserName, "User Name Is Used By Another Person");
                    e.Cancel = true;
                }
                else errorProvider1.SetError(txtUserName, null);
            }
            else
            {
                if (_User.UserName != txtUserName.Text.Trim())
                {
                    if (await clsUser.IsUserExistByUserName(txtUserName.Text.Trim()))
                    {
                        errorProvider1.SetError(txtUserName, "User Name Is Used By Another Person");
                        e.Cancel = true;
                    }
                    else errorProvider1.SetError(txtUserName, null);
                }
            }


        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
            {
                errorProvider1.SetError(txtPassword, "This Field Is Reqired");
                e.Cancel = true;
            }
            else errorProvider1.SetError(txtPassword, null);
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password Is Not Correct");
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
