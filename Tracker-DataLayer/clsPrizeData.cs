using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Tracker_DataLayer
{
    public static class clsPrizeData
    {
        /// <summary>
        /// this function add new prize for spesific place
        /// </summary>
        /// <param name="PlaceNumber">place number for the team who take this prize</param>
        /// <param name="PlaceName">place Name for thse team who take this prize</param>
        /// <param name="PrizeAmount">prize amount</param>
        /// <param name="PricePercentage">prize percentage from total prize</param>
        /// <returns>if prize ID = -1 since prize not added successfuly otherwize prize added succesfuly</returns>
        private static async Task<int> CreatePrizeForPlace(int PlaceNumber, string PlaceName, decimal PrizeAmount, decimal PricePercentage)
        {
            int PrizeID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = "INSERT INTO [dbo].[Prizes]([PlaceNumber],[PlaceName],[PrizeAmount],[PrizePercentage]) " +
                                   "VALUES " +
                                   "(@PlaceNumber, @PlaceName, @PrizeAmount, @PrizePercentage) " +
                                   "SELECT SCOPE_IDENTITY();";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.Parameters.AddWithValue("@PlaceNumber", PlaceNumber);
                        Command.Parameters.AddWithValue("@PlaceName", PlaceName);
                        Command.Parameters.AddWithValue("@PrizeAmount", PrizeAmount);
                        Command.Parameters.AddWithValue("@PrizePercentage", PricePercentage);

                        await Connection.OpenAsync();
                        object Result = Command.ExecuteScalar();
                        if (Result != null)
                            PrizeID = Convert.ToInt32(Result);
                    }
                }
            }
            catch(Exception e) 
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return PrizeID;
        }
        /// <summary>
        /// this function add new prize to spesific tournament by ID
        /// </summary>
        /// <param name="TournamentID">tournament for tourament the prize add to it</param>
        /// <param name="PlaceNumber">place number for the team who take this prize</param>
        /// <param name="PlaceName">place Name for thse team who take this prize</param>
        /// <param name="PrizeAmount">prize amount</param>
        /// <param name="PricePercentage">prize percentage from total prize</param>
        /// <returns> Prize ID for this Prize</returns>
        public static async Task<int> AddNewPrizeByTournamentID(int TournamentID, int PlaceNumber, string PlaceName, decimal PrizeAmount, decimal PricePercentage)
        {
            int TournamentPrizeID = -1;
            try
            {
                int PrizeID = await CreatePrizeForPlace(PlaceNumber, PlaceName, PrizeAmount, PricePercentage);
                if (PrizeID == -1)
                    return -1;

                using(SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = "INSERT INTO [dbo].[TournamentPrizes]([PrizeID],[TournamentID]) " +
                                   "VALUES " +
                                   "(@PrizeID, @TournamentID) " +
                                   "SELECT SCOPE_IDENTITY();";
                    using(SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.Parameters.AddWithValue("@PrizeID", PrizeID);
                        Command.Parameters.AddWithValue("@TournamentID", TournamentID);

                        await Connection.OpenAsync();
                        object Result = Command.ExecuteScalar();
                        if (Result != null)
                            TournamentPrizeID = Convert.ToInt32(Result);
                    }
                }
            }
            catch(Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return TournamentPrizeID;
        }
    }
}
