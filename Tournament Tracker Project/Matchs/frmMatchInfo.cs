using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tournament_Tracker_Project.Matchs
{
    public partial class frmMatchInfo : Form
    {
        public event Action MatchInfoUpdated;

        protected virtual void OnMatchInfoUpdated() => MatchInfoUpdated?.Invoke();

        int _MatchID = -1;

        public frmMatchInfo(int MatchID)
        {
            InitializeComponent();
            this._MatchID = MatchID;
        }

        private void frmMatchInfo_Load(object sender, EventArgs e)
        {
            ctrMatchInfo1.LoadInfo(_MatchID);
        }

        private void ctrMatchInfo1_DataUpdated()
        {
            OnMatchInfoUpdated();
        }
    }
}
