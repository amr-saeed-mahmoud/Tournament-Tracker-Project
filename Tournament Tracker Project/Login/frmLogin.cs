using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tournament_Tracker_Project.Global_Classes;
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project.Login
{
    public partial class frmLogin : Form
    {
        private int NumOfWrongRegistration = 0;
        string SourceName = "Tournament_Tricker";

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            clsUser user = await clsUser.FindUserByUserNameAndPassword(txtUserName.Text.Trim(), txtPassword.Text.Trim());

            if (user != null)
            {
                if (chkRememberMe.Checked)
                {
                    clsGlobel.SaveUserCredentialToRegistry(txtUserName.Text.Trim(), txtPassword.Text.Trim());// Update 1
                }
                else
                {
                    clsGlobel.SaveUserCredentialToRegistry("", "");
                }
                if (!user.IsActive)
                {

                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobel.User = user;
                this.Hide();
                frmMainSecreen frm = new frmMainSecreen(this);
                frm.Show();
            }
            else
            {
                NumOfWrongRegistration++;
                txtUserName.Focus();
                MessageBox.Show("Invalid Username/Password.", "Wrong Credintials", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (NumOfWrongRegistration == 3)
                {
                    EventLog.WriteEntry(SourceName, "You Register Grater Than Three Time", EventLogEntryType.Error);
                    this.Close();
                }
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "", Password = "";
            if (clsGlobel.GetStoredCredentialFromRegistry(ref UserName, ref Password))
            {
                txtUserName.Text = UserName;
                txtPassword.Text = Password;
                chkRememberMe.Checked = true;
            }
            else chkRememberMe.Checked = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
