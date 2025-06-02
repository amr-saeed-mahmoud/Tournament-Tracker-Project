using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker_BusinessLogic;

namespace Tournament_Tracker_Project.Global_Classes
{
    public static class clsGlobel
    {
        public static List<clsPerson> AllPeople = new List<clsPerson>();

        //public static async Task RefailPeopleList()
        //{
        //    AllPeople = new List<clsPerson>();
        //    AllPeople = await clsPerson.GetListOfPerson();
        //}

        public static clsTournament CurTournament { get; set; }

        public static clsUser User { get; set; }

        public static string RegistryPath = @"HKEY_CURRENT_USER\Tournament_Tricker";

        private static string RegistryName = "Tournament_Tricker";


        public static bool SaveUserCredentialToRegistry(string UserName, string Password)
        {
            string RegistryName = "User Credential";
            string RegistryValue = UserName + "#//#" + Password;

            if (UserName == "" || Password == "")
            {
                try
                {
                    Registry.SetValue(RegistryPath, RegistryName, "", RegistryValueKind.String);
                }
                catch { return false; }
            }
            else
            {
                try
                {
                    Registry.SetValue(RegistryPath, RegistryName, RegistryValue, RegistryValueKind.String);
                }
                catch { return false; }
            }
            return true;
        }

        public static bool GetStoredCredentialFromRegistry(ref string UserName, ref string Password)
        {
            string RegistryName = "User Credential";
            try
            {

                string Credential = Registry.GetValue(RegistryPath, RegistryName, null) as string;
                if (Credential == null)
                    return false;

                string[] Result = Credential.Split(new string[] { "#//#" }, StringSplitOptions.None);

                UserName = Result[0];
                Password = Result[1];
            }
            catch { return false; }
            return true;
        }
    }
}
