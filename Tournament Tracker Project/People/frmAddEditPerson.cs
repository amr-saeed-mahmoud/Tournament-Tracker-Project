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
using static System.Net.Mime.MediaTypeNames;

namespace Tournament_Tracker_Project
{
    public partial class frmAddEditPerson : Form
    {

        public event EventHandler<clsPerson> SavePersonInfo;

        protected virtual void OnSavePersonInfo(clsPerson person) => SavePersonInfo?.Invoke(this, person);

        int _PersonID = -1;

        clsPerson _Person = new clsPerson();
        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        public frmAddEditPerson()
        {
            InitializeComponent();
        }

        private void frmEditPersonInfo_Load(object sender, EventArgs e)
        {
            if(_PersonID != -1)
            {
                _LoadInfo();
                this.Text = "Update Person Secren";
                lbTitle.Text = "Update Person";
            }
            else
            {
                this.Text = "Add Person Secren";
                lbTitle.Text = "Add Person";
            }
        }

        private async void _LoadInfo()
        {
            _Person = await clsPerson.FindPersonByID(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("No Person with PersonID = " + _PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FailInfo();
        }
        private void _FailInfo()
        {
            lbPersonID.Text = _Person.PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.PhoneNumber;
            txtNationalNo.Text = _Person.NationalNo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if(!this.ValidateChildren())
            {
                MessageBox.Show("There are fields that are not Valid In Add New Member Info. Point to the red dots to read the message", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.PhoneNumber = txtPhone.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();

            if (MessageBox.Show("Are you sure you want to save new person info ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(await _Person.Save())
                {
                    if(_PersonID != -1)
                        MessageBox.Show("Person updated sucessfully", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Person Added sucessfully", "Info", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                    lbPersonID.Text = _Person.PersonID.ToString();
                    this.Text = "Edit Person Secren";
                    lbTitle.Text = "Update Person";

                    OnSavePersonInfo(_Person);
                }
                else
                    MessageBox.Show("Process is Faild", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _ValidName(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (!clsValidation.IsValidName(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "Enter a valid name.");
            }
            else
                errorProvider1.SetError(txt, null);
        }
        private void _ValidEmail(object sender, CancelEventArgs e)
        {
            if(!clsValidation.IsValidEmail(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Enter a valid email.");
            }
            else
                errorProvider1.SetError(txtEmail, null);
        }
        private void _ValidPhone(object sender, CancelEventArgs e)
        {
            if(!clsValidation.IsValidNumber(txtPhone.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtPhone, "Enter a valid phone number.");
            }
            else
                errorProvider1.SetError(txtPhone, null);
        }

        private async void _ValidNationalNo(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "No NationalNo is enterd.");
                e.Cancel = true;
            }
            else if (txtNationalNo.Text != _Person.NationalNo && await clsPerson.IsExist(txtNationalNo.Text))
            {
                errorProvider1.SetError(txtNationalNo, "NationalNo is already used.");
                e.Cancel = true;
            }
            else
                errorProvider1.SetError(txtNationalNo, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
