using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tournament_Tracker_Project.Users
{
    public partial class frmUserInfo : Form
    {
        int _UserID = -1;
        public frmUserInfo(int userID)
        {
            InitializeComponent();
            _UserID = userID;
        }

        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            ctrUserInfo1.LoadInfo(_UserID);
        }
    }
}
