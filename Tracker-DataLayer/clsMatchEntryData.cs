using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_DataLayer
{
    public static class clsMatchEntryData
    {
        public static async Task<int> AddNewMatchEntryByMatchID(int MatchID, int TeamID, int Score)
        {
            int MatchEntryID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"INSERT INTO [dbo].[MatchEntries]([TeamID],[MatchID],[Score])
                                     VALUES (@TeamID, @MatchID, @Score)
                                     SELECT SCOPE_IDENTITY();";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.Parameters.AddWithValue("@MatchID", MatchID);
                        // handel null values
                        if(TeamID == -1)
                            Command.Parameters.AddWithValue("@TeamID", DBNull.Value);
                        else Command.Parameters.AddWithValue("@TeamID", TeamID);
                        if(Score == -1)
                            Command.Parameters.AddWithValue("@Score", DBNull.Value);
                        else Command.Parameters.AddWithValue("@Score", Score);
                        //----------------------
                        await Connection.OpenAsync();

                        object Result = Command.ExecuteScalar();
                        if (Result != null)
                            MatchEntryID = Convert.ToInt32(Result);
                    }
                }
            }
            catch(Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return MatchEntryID;
        }

        public static async Task<DataTable> FindMatchEntryByMatchID(int MatchID)
        {
            DataTable Entries = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string query = @"SELECT * FROM MatchEntries
                                 WHERE MatchID = @MatchID;";
                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.Parameters.AddWithValue("@MatchID", MatchID);
                        await Connection.OpenAsync();
                        using (SqlDataReader reader = Command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                Entries.Load(reader);
                            }
                        }
                    }
                }
            }
            catch(Exception e) { clsLogger.LogErrorToEventLog (e.Message); }
            return Entries;
        }

        public static async Task<bool> SaveEntryResult(int MatchEntryID, int Score)
        {
            int AffectedRows = -1;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"UPDATE [dbo].[MatchEntries]
                                 SET [Score] = @Score
                                 WHERE MatchEntries.MatchEntryID = @MatchEntryID;";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.Parameters.AddWithValue("@MatchEntryID", MatchEntryID);
                        Command.Parameters.AddWithValue("@Score", Score);

                        await Connection.OpenAsync();
                        AffectedRows = await Command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception e) { clsLogger.LogErrorToEventLog(e.Message); }

            return AffectedRows > 0;
        }
    }
}
