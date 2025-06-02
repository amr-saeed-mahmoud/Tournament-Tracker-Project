using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Tracker_DataLayer;

namespace Tracker_BusinessLogic
{
    public class clsTeam
    {
        public enum enMode { AddNew = 0, Update = 1}
        enMode Mode = enMode.AddNew;

        /// <summary>
        /// Represent Team ID for this object
        /// </summary>
        public int TeamID { get; set; }

        /// <summary>
        /// Represent list of person for this team
        /// </summary>
        public List<clsPerson> TeamMember { get; set; } = new List<clsPerson>();
        /// <summary>
        /// Represent Team Name for this object
        /// </summary>
        public string TeamName { get; set; }

        public clsTeam()
        {
            this.TeamID = -1;
            this.TeamName = "";
            Mode = enMode.AddNew;
        }
        public clsTeam(int TeamID, string TeamName)
        {
            this.TeamID = TeamID;
            this.TeamName = TeamName;
            Mode = enMode.AddNew;
        }
        private clsTeam(string TeamName, List<clsPerson> Members)
        {
            this.TeamName = TeamName;
            this.TeamMember = Members;
            Mode = enMode.Update;
        }
        /// <summary>
        /// this function use only in AddMode that create a new Team with empty members
        /// </summary>
        /// <returns>true if created succesflly otherwise false</returns>
        private async Task<bool> _CreateNewTeam()
        {
            TeamID =  await clsTeamData.CreateNewTeam(TeamName);
            if (TeamID > 0) return true;
            else return false;
        }
        /// <summary>
        /// this function Save All team Info
        /// </summary>
        /// <returns>true : if Added Sucessfuly otherwise false</returns>
        public async Task<bool> Save()
        {
            if (TeamMember.Count < 1)
                return false;
            switch(Mode)
            {
                case enMode.AddNew:
                    if (await _CreateNewTeam())
                    {
                        if (await _SaveMembersToDatabase())
                        {
                            Mode = enMode.Update;
                            return true;
                        }
                    }
                    break;
                case enMode.Update:
                    // do anything
                    break;
            }
            return false;
        }
        /// <summary>
        /// this function Add a list of Person in team to database and save it
        /// </summary>
        /// <returns>true if added sucessfuly otherwise false</returns>
        private async Task<bool> _SaveMembersToDatabase()
        {
            foreach (clsPerson Person in TeamMember)
            {
                if (await clsTeamData.AddNewMemberToSpecificTeam(this.TeamID, Person.PersonID) <= 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// this function add new Person to team Members list without save it in database
        /// </summary>
        /// <param name="Person">Person Whojoin for this team</param>
        public void AddNewMemberToTeamList(clsPerson Person)
        { 
            TeamMember.Add(Person);
        }
        public void RemoveMemberFromTeamList(clsPerson Person)
        {
            TeamMember.Remove(Person);
        }

        public static async Task<DataTable> GetAllTeams()
        {
            return await clsTeamData.GetAllTeamsInSystem();
        }

        public static async Task<string> GetTeamNameByID(int SelectedTeamID)// find team name
        {
            string result = await clsTeamData.GetTeamNameByID(SelectedTeamID);
            return result;
        }
        
        public static async Task<clsTeam> GetTeamInfoByID(int SelectedTeamID)
        {
            clsTeam Team = new clsTeam();
            Team.TeamName = await clsTeam.GetTeamNameByID(SelectedTeamID);
            
            if(!string.IsNullOrEmpty(Team.TeamName))
            {
                Team.TeamID = SelectedTeamID;
                DataTable Members = await clsTeamData.GetTeamMembersByTeamID(SelectedTeamID);

                foreach(DataRow member in Members.Rows)
                {
                    clsPerson Person = await clsPerson.FindPersonByID((int)member["PersonID"]);
                    Team.TeamMember.Add(Person);
                }
            }
            return Team;
        }

        public static async Task<DataTable> GetAllTeamsInTournament(int TournamentID)
        {
            return await clsTeamData.GetAllTeamsInTournament(TournamentID);
        }
    }
}
