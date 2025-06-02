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

namespace Tournament_Tracker_Project.Users.Control
{
    public partial class ctrUserInfo : UserControl
    {
        private int _UserID = -1;
        
        private clsUser _User = new clsUser();

        public int UserID { get { return _UserID; } }
        public clsUser CurUser { get { return _User; } }

        public ctrUserInfo()
        {
            InitializeComponent();
        }

        private void _Load()
        {
            ctrPersonInfo1.LoadInfo(_User.UserInfo.PersonID);

            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            lblIsActive.Text = _User.IsActive.ToString();
        }

        public async void LoadInfo(int UserID)
        {
            _User = await clsUser.FindUserByUserID(UserID);

            if(_User == null)
            {
                MessageBox.Show($"User with user ID {UserID} not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _UserID = UserID;
            _Load();
        }
    }
}
