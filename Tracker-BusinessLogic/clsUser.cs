using System;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using Tracker_DataLayer;

namespace Tracker_BusinessLogic
{
    public class clsUser
    {
        public enum enUserMode { Add, Update};

        private enUserMode _Mode = enUserMode.Add;

        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public clsPerson UserInfo { get; set; }
        public bool IsActive { get; set; }

        public clsUser()
        {
            UserID = 0;
            UserName = "";
            UserInfo = new clsPerson();
            IsActive = true;
            _Mode = enUserMode.Add;
        }

        public clsUser(int UserID, string UserName, clsPerson Person, bool IsActive)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.UserInfo = Person;
            this.IsActive = IsActive;

            _Mode = enUserMode.Update;
        }

        public static async Task<clsUser> FindUserByUserID(int UserID)
        {
            DataTable DataUser = await clsUserData.FindUserByID(UserID);

            clsUser User = new clsUser();

            if (DataUser != null && DataUser.Rows.Count > 0)
            {
                User.UserID = UserID;
                User.Password = DataUser.Rows[0]["Password"].ToString();
                User.UserName = DataUser.Rows[0]["UserName"].ToString();
                User.IsActive = (bool)DataUser.Rows[0]["IsActive"];
                int PersonID = Convert.ToInt32(DataUser.Rows[0]["PersonID"]);
                User.UserInfo = await clsPerson.FindPersonByID(PersonID);
                User._Mode = enUserMode.Update;
            }

            return User;
        }

        public static async Task<clsUser> FindUserByUserNameAndPassword(string UserName, string Password)
        {
            DataTable result = await clsUserData.FindByUsernameAndPassword(UserName, Password);

            if (result.Rows.Count == 0)
                return null;

            clsUser User = new clsUser();
            User.UserID = int.Parse(result.Rows[0]["UserID"].ToString());
            User.UserName = UserName;
            User.Password = Password;
            User.IsActive = (bool)result.Rows[0]["IsActive"];
            int PersonID = int.Parse(result.Rows[0]["PersonID"].ToString());
            User.UserInfo = await clsPerson.FindPersonByID(PersonID);
            return User;
        }

        private async Task<bool> _AddUser()
        {
            UserID = await clsUserData.AddNewUser(UserInfo.PersonID, UserName, Password, IsActive);
            return UserID > 0;
        }

        private async Task<bool> _UpdateUser()
        {
            return await clsUserData.UpdateUser(UserID, UserName, Password, IsActive);
        }

        public async Task<bool> Save()
        {
            switch(_Mode)
            {
                case enUserMode.Add:
                    if(await _AddUser())
                        _Mode = enUserMode.Update;
                    return UserID > 0;

                case enUserMode.Update:
                    return await _UpdateUser();

                default:
                    return false;
            }
            
        }

        public static async Task<DataTable> GetAllUsers()
        {
            return await clsUserData.GetAllUsers();
        }
        
        public static async Task<bool> IsUserExistByPersonID(int PersonID)
        {
            return await clsUserData.IsUserExistByPersonID(PersonID);
        }

        public static async Task<bool> IsUserExistByUserName(string UserName)
        {
            return await clsUserData.IsUserExistByUserName(UserName);
        }
    }
}
