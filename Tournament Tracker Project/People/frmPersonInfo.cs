using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tournament_Tracker_Project.People
{
    public partial class frmPersonInfo : Form
    {
        int _PersonID = -1;
        public frmPersonInfo(int PersonID)
        {
            InitializeComponent();
            _PersonID = PersonID;
        }

        private void frmPersonInfo_Load(object sender, EventArgs e)
        {
            ctrPersonInfo1.LoadInfo(_PersonID);
        }
    }
}
