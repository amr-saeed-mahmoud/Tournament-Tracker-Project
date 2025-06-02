using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Security.Authentication;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tracker_DataLayer
{
    public static class clsTournamentData
    {
        /// <summary>
        /// this function create a new Tournament
        /// </summary>
        /// <param name="TournamentName">tournament name</param>
        /// <param name="EntryFee">Entry fee for one team</param>
        /// <returns>Tournament ID</returns>
        public static async Task<int> CreateNewTournament(string TournamentName, decimal EntryFee, int UserID)
        {
            int TournamentID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SP_CreateNewTournament";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@TournamentName", TournamentName);
                        Command.Parameters.AddWithValue("@EntryFee", EntryFee);
                        Command.Parameters.AddWithValue("@UserID", UserID);

                        SqlParameter ReturnTournamentID = new SqlParameter
                        {
                            ParameterName = "@TournamentID",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };
                        Command.Parameters.Add(ReturnTournamentID);

                        await Connection.OpenAsync();

                        // Execute the stored procedure
                        await Command.ExecuteNonQueryAsync();

                        // Retrieve the output parameter value
                        TournamentID = Convert.ToInt32(ReturnTournamentID.Value);
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return TournamentID;
        }

        /// <summary>
        /// this function add new team to tournament by tournament id
        /// </summary>
        /// <param name="TournamentID">tournament id for this tournament</param>
        /// <param name="TeamID">team id for this team</param>
        /// <returns>tournament entry id </returns>
        public static async Task<int> AddTeamToTournament(int TournamentID, int TeamID)
        {
            int TournamentEntryID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SP_AddTeamToTournament";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@TournamentID", TournamentID);
                        Command.Parameters.AddWithValue("@TeamID", TeamID);

                        SqlParameter ReturnTournamentEntryID = new SqlParameter
                        {
                            ParameterName = "@EntryID",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };

                        Command.Parameters.Add(ReturnTournamentEntryID);

                        await Connection.OpenAsync();

                        Command.ExecuteNonQuery();
                        
                        if (ReturnTournamentEntryID != null)
                            TournamentEntryID = Convert.ToInt32(ReturnTournamentEntryID.Value);
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return TournamentEntryID;
        }

        public static async Task<DataTable> GetAllTournaments()
        {
            DataTable Tournaments = new DataTable();
            using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
            {
                string quiry = "SP_GetAllTournaments";

                using (SqlCommand Command = new SqlCommand(quiry, Connection))
                {
                    await Connection.OpenAsync();

                    Command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                    {
                        Tournaments.Load(Reader);
                    }
                }
            }
            return Tournaments;
        }

        public static int GetCurRound(int TournamentID)
        {
            int CurRound = -1; // Initialize CurRound to -1 as a default

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string query = "SP_GetCurRound";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@TournamentID", TournamentID);

                        SqlParameter ReturnCurRound = new SqlParameter
                        {
                            ParameterName = "@CurRound",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };

                        Command.Parameters.Add(ReturnCurRound);

                        Connection.Open();
                        Command.ExecuteNonQuery();

                        if (ReturnCurRound.Value != DBNull.Value)
                        {
                            CurRound = Convert.ToInt32(ReturnCurRound.Value);
                        }
                        else
                            CurRound = -1;

                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }

            return CurRound;
        }




        /// <summary>
        /// this function help function (AddWinnerTeamsToNextRound) to add winners team to next round
        /// </summary>
        /// <param name="TournamentID">tournmantID</param>
        /// <param name="TeamID">winner teamID</param>
        /// <returns>true: true if Added Sucessfully else return false</returns>
        private static async Task<bool> _AddWinnerTeamToNextRound(int TeamID, int MatchID)
        {
            object AffectedRows = null;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SP_AddWinnerTeamToNextRound";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();

                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("@TeamID", TeamID);
                        Command.Parameters.AddWithValue("@MatchID", MatchID);

                        SqlParameter ReturnAffectedRows = new SqlParameter
                        {
                            ParameterName = "@AffectedRows",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };

                        Command.Parameters.Add(ReturnAffectedRows);

                        await Command.ExecuteNonQueryAsync();

                        AffectedRows = ReturnAffectedRows.Value;
                    }

                }
            }
            catch (Exception e) { clsLogger.LogErrorToEventLog(e.Message); }

            if (AffectedRows != null)
                return (int)AffectedRows > 0;
            
            else return false;
        }
        
        /// <summary>
        /// thia function add winners in perf round to next round
        /// </summary>
        /// <param name="TournamentID">tournamentID for this tournament</param>
        /// <param name="WinnersID">ID for winner team</param>
        /// <param name="FirstMatchIDInNewRound">first matchID in next round</param>
        /// <returns></returns>
        public static async Task<bool> AddWinnerTeamsToNextRound(List<int> WinnersID, int FirstMatchIDInNewRound)
        {
            int rest = 2;
            foreach (var Winner in WinnersID)
            {
                if(rest == 0)
                {
                    rest = 2;
                    FirstMatchIDInNewRound++;
                }

                if (!await _AddWinnerTeamToNextRound(Winner, FirstMatchIDInNewRound))
                {
                    return false;
                }
                rest--;
            }
            return true;
        }

        public static int NumberOFRoundInTournament(int TournamentID)
        {
            object result = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SP_NumberOFRoundInTournament";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Connection.Open();

                        Command.CommandType = CommandType.StoredProcedure;

                        Command.Parameters.AddWithValue("TournamentID", TournamentID);

                        SqlParameter ReturnResult = new SqlParameter
                        {
                            ParameterName = "@result",
                            DbType = DbType.Int32,
                            Direction = ParameterDirection.Output
                        };

                        Command.Parameters.Add(ReturnResult);

                        Command.ExecuteNonQuery();

                        result = ReturnResult.Value;
                    }
                }
            }
            catch(Exception ex) { clsLogger.LogErrorToEventLog(ex.Message); }

            if(result != DBNull.Value)
                return (int)result;
            return -1;
        }

        public static async Task<DataTable> FindTournamentByID(int TournamentID)
        {
            DataTable Tournament = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SELECT * FROM Tournaments WHERE TournamentID = @TournamentID;";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();
                        Command.Parameters.AddWithValue("@TournamentID", TournamentID);
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                Tournament.Load(reader);
                        }

                    }
                }
            }
            catch(Exception e) { clsLogger.LogErrorToEventLog(e.Message); }

            return Tournament;  
        }

    }

}
