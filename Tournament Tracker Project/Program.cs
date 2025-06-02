using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tournament_Tracker_Project.Login;
using Tournament_Tracker_Project.Matchs;
using Tournament_Tracker_Project.People;
using Tournament_Tracker_Project.Users;

namespace Tournament_Tracker_Project
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
        }
    }
}
