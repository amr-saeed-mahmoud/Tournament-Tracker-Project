using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_DataLayer
{
    public static class clsTeamData
    {

        /// <summary>
        /// this function resbonsible for Create a new Team (this team is empty and you should add Member in it)
        /// </summary>
        /// <param name="TeamName">Name for it Team</param>
        /// <returns>ID for this Team</returns>
        public async static Task<int> CreateNewTeam(string TeamName)
        {
            int TeamID = -1;
            
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SP_Team_CreateNewTeam";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@TeamName", TeamName);

                        SqlParameter returnID = new SqlParameter
                        {
                            ParameterName = "@TeamID",
                            DbType = DbType.Int32,
                            Direction = ParameterDirection.Output
                        };

                        Command.Parameters.Add(returnID);

                        await Connection.OpenAsync();

                        Command.ExecuteNonQuery();

                        if((int)returnID.Value > 0)
                            TeamID = Convert.ToInt32(returnID.Value);
                        
                    }
                }
            }
            catch(Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return TeamID;
        }

        /// <summary>
        /// this function add new Member to specific team by TeamID and PersonID for this Member
        /// </summary>
        /// <param name="TeamID">the team's ID that Person will be entring to </param>
        /// <param name="PersonID">ID for the Person who join for this team</param>
        /// <returns>return MemberID for this person</returns>
        public static async Task<int> AddNewMemberToSpecificTeam(int TeamID, int PersonID)
        {
            int MemberID = -1;
            
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = "SP_Team_AddNewMemberToSpecificTeam";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@TeamID", TeamID);
                        Command.Parameters.AddWithValue("@PersonID", PersonID);

                        SqlParameter ReturnID = new SqlParameter
                        {
                            ParameterName = "@MemberID",
                            DbType = DbType.Int32,
                            Direction = ParameterDirection.Output
                        };

                        Command.Parameters.Add(ReturnID);

                        await Connection.OpenAsync();
                        Command.ExecuteNonQuery();

                        if((int)ReturnID.Value > 0)
                            MemberID = Convert.ToInt32(ReturnID.Value);

                    }
                }
            }
            catch(Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return MemberID;
        }
        /// <summary>
        /// this function get all teams from database
        /// </summary>
        /// <returns>all teams in data base</returns>
        public static async Task<DataTable> GetAllTeamsInSystem()
        {
            DataTable Teams = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    await Connection.OpenAsync();
                    string query = "SP_Teams_GetAllTeams";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.CommandType= CommandType.StoredProcedure;

                        using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                        {
                            Teams.Load(Reader); // Load all rows from the result set
                        }
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return Teams;
        }

        public static async Task<string> GetTeamNameByID(int TeamID)
        {
            string TeamName = string.Empty; // Initialize TeamName as an empty string

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string query = "SP_Teams_GetTeamNameByID";
                    using (SqlCommand command = new SqlCommand(query, Connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@TeamID", TeamID);

                        SqlParameter returnName = new SqlParameter
                        {
                            ParameterName = "@TeamName",
                            DbType = DbType.String,
                            Size = 50, // Set the appropriate size based on your database schema
                            Direction = ParameterDirection.Output
                        };

                        command.Parameters.Add(returnName);

                        await Connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();

                        if (returnName.Value != DBNull.Value)
                        {
                            TeamName = returnName.Value.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsLogger.LogErrorToEventLog(ex.Message);
            }

            return TeamName;
        }


        public static async Task<DataTable> GetTeamMembersByTeamID(int TeamID)
        {
            DataTable Members = new DataTable();
            
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SP_Teams_GetTeamMembersByTeamID";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@TeamID", TeamID);
                        await Connection.OpenAsync();
                        using (SqlDataReader reader = await Command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                Members.Load(reader);
                            }
                        }
                    }
                }
            }
            catch(Exception e) { clsLogger.LogErrorToEventLog(e.Message); }
            return Members;
        }

        public static async Task<DataTable> GetAllTeamsInTournament(int TournamentID)
        {
            DataTable Teams = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SELECT Teams.TeamID, Teams.TeamName
                                 FROM   TournamentEntries INNER JOIN
                                                   Teams ON TournamentEntries.TeamID = Teams.TeamID
                                 				  where TournamentID = @TournamentID;";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();
                        Command.Parameters.AddWithValue("@TournamentID", TournamentID);
                        
                        using(SqlDataReader reader = await Command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                Teams.Load(reader);
                        }
                    }
                }
            }
            catch(Exception e) { clsLogger.LogErrorToEventLog(e.Message); }
            
            return Teams;
        }
    }
}
