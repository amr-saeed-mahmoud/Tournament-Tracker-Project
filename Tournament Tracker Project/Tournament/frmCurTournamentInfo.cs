using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tournament_Tracker_Project.Tournament
{
    public partial class frmCurTournamentInfo : Form
    {
        public frmCurTournamentInfo()
        {
            InitializeComponent();
        }

        private void frmCurTournamentInfo_Load(object sender, EventArgs e)
        {
            ctrTournamentInfo1.LaodInfo();
        }
    }
}
