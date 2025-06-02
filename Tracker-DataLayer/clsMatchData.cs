using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace Tracker_DataLayer
{
    public static class clsMatchData
    {
        public static async Task<int> CreateMatch(int WinnerTeamID, int Round, int TournamentID)
        {
            int MatchID = -1;

            try
            {
                using (SqlConnection Conection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = "INSERT INTO [dbo].[Matchs]([WinnerTeamID],[Round],[TournamentID]) " +
                                   "VALUES(@WinnerTeamID, @Round, @TournamentID) " +
                                   "SELECT SCOPE_IDENTITY();";
                    using (SqlCommand Command = new SqlCommand(quiry, Conection))
                    {
                        if (WinnerTeamID == -1)// handel null values
                            Command.Parameters.AddWithValue("@WinnerTeamID", DBNull.Value);
                        else Command.Parameters.AddWithValue("@WinnerTeamID", WinnerTeamID);
                        //----------------
                        Command.Parameters.AddWithValue("@Round", Round);
                        Command.Parameters.AddWithValue("@TournamentID", TournamentID);

                        await Conection.OpenAsync();
                        object Result = Command.ExecuteScalar();
                        if (Result != null)
                            MatchID = Convert.ToInt32(Result);
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return MatchID;
        }

        public static async Task<DataTable> GetAllMatchesInTournament(int TournamentID)
        {
            DataTable Matches = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string query = @"SELECT Matchs.MatchID, Matchs.WinnerTeamID, Matchs.Round 
                                     FROM Matchs
                                     INNER JOIN Tournaments
                                     ON Matchs.TournamentID = Tournaments.TournamentID
                                     WHERE Matchs.TournamentID = @TournamentID
                                     ORDER BY Matchs.Round;";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.Parameters.AddWithValue("@TournamentID", TournamentID);// add value

                        await Connection.OpenAsync();

                        using (SqlDataReader reader = await Command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                Matches.Load(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return Matches;
        }

        public static async Task<bool> SaveMatchResult(int MatchID, int WinnerTeamID)
        {
            int affectedRows = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string query = @"UPDATE [dbo].[Matchs]
                                     SET [WinnerTeamID] = @WinnerTeamID 
                                     WHERE Matchs.MatchID = @MatchID;";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@WinnerTeamID", WinnerTeamID);
                        command.Parameters.AddWithValue("@MatchID", MatchID); // Add the MatchID parameter

                        await connection.OpenAsync();
                        affectedRows = await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return affectedRows > 0;
        }

        public static async Task<DataTable> FindMatch(int MatchID)
        {
            DataTable Match = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SELECT * FROM Matchs WHERE MatchID = @MatchID;";

                    using(SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();

                        Command.Parameters.AddWithValue("@MatchID", MatchID);
                        
                        using(SqlDataReader reader = await Command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                Match.Load(reader);
                        }
                    }
                }
            }
            catch(Exception e) { clsLogger.LogErrorToEventLog(e.Message); }

            return Match;
        }

    } 
}
