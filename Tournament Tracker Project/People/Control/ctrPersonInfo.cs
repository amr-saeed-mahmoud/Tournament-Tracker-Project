using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tracker_BusinessLogic;
using static System.Net.Mime.MediaTypeNames;

namespace Tournament_Tracker_Project
{
    public partial class ctrPersonInfo : UserControl
    {

        public event EventHandler<clsPerson> PersonSelected;

        protected virtual void OnPersonSelected(clsPerson person) => PersonSelected?.Invoke(this, person);

        int _PersonID = -1;
        clsPerson _Person = new clsPerson();

        public int GetPersonID 
        {
            get { return _PersonID; }
        }

        public clsPerson GetCurPerson 
        {
            get { return _Person; }
        }
        public ctrPersonInfo()
        {
            InitializeComponent();
        }

        private void _ResetDafaultValue()
        {
            linkLabel1.Enabled = false;
            _PersonID = -1;
            _Person = new clsPerson();

            lbPersonID.Text = "[  ]";
            lbName.Text = "[  ]";
            lbNationalNo.Text = "[  ]";
            lbPhone.Text = "[  ]";
            lbEmail.Text = "[  ]";
        }

        private void _Loadinfo()
        {
            linkLabel1.Enabled = true;
            _PersonID = _Person.PersonID;

            lbPersonID.Text = _Person.PersonID.ToString();
            lbNationalNo.Text = _Person.NationalNo;
            lbName.Text = _Person.FullName;
            lbPhone.Text = _Person.PhoneNumber;
            lbEmail.Text = _Person.Email;
        }

        public async void LoadInfo(int PersonID)
        {
            _Person = await clsPerson.FindPersonByID(PersonID);

            if(_Person == null)
            {
                _ResetDafaultValue();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Loadinfo();
        }

        public async void LoadInfo(string NationalNo)
        {
            _Person = await clsPerson.FindPersonByNationalNo(NationalNo);

            if (_Person == null)
            {
                _ResetDafaultValue();
                MessageBox.Show("No Person with National No = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _Loadinfo();
            OnPersonSelected(_Person);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.SavePersonInfo += DataBack;
            frm.ShowDialog();
        }

        private void DataBack(object sender, clsPerson person)
        {
            LoadInfo(_PersonID);
        }

        
    }
}
