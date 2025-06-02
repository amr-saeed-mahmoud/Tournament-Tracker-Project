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

namespace Tournament_Tracker_Project
{
    public partial class frmAddPlayerBySearchFilter : Form
    {
        public event EventHandler<clsPerson> SelectedPerson;

        protected virtual void OnSelectPerson(clsPerson person) => SelectedPerson?.Invoke(this, person);

        public frmAddPlayerBySearchFilter()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if(ctrPersonInfoByFilter1.PersonID <= 0)
            {
                MessageBox.Show("No person selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Person select sucessully.","Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            OnSelectPerson(ctrPersonInfoByFilter1.CurPerson);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
