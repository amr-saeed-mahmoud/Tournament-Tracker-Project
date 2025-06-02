using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Web;

namespace Tracker_DataLayer
{
    public static class clsPersonData
    {
        public static async Task<DataTable> GetAllPeople()
        {
            DataTable People = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string query = @"SELECT PersonID, NationalNo, FullName = FirstName + ' ' + LastName, Email, Phone
                                     FROM People
                                     WHERE NationalNo IS NOT NULL 
                                     ORDER BY FullName";

                    using (SqlCommand Comamnd = new SqlCommand(query, Connection))
                    {
                        await Connection.OpenAsync();
                        using (SqlDataReader Reader = await Comamnd.ExecuteReaderAsync())
                        {
                            People.Load(Reader);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }
            return People;
        }

        public static async Task<int> AddNewPerson(string NationalNo, string FirstName, string LastName, string Email, string PhoneNumber)
        {
            int PersonID = -1;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string query = "INSERT INTO People (NationalNo, FirstName, LastName, Email, Phone) VALUES (@NationalNo, @FirstName, @LastName, @Email, @Phone); " +
                                   "SELECT SCOPE_IDENTITY();";

                    using (SqlCommand Command = new SqlCommand(query, Connection))
                    {
                        Command.Parameters.AddWithValue("@FirstName", FirstName);
                        Command.Parameters.AddWithValue("@LastName", LastName);
                        Command.Parameters.AddWithValue("@Email", Email);
                        Command.Parameters.AddWithValue("@Phone", PhoneNumber);

                        if (string.IsNullOrEmpty(NationalNo))
                            Command.Parameters.AddWithValue("@NationalNo", DBNull.Value);
                        else Command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        await Connection.OpenAsync();
                        object value = await Command.ExecuteScalarAsync();

                        if (value != null && int.TryParse(value.ToString(), out int insertedID))
                        {
                            PersonID = insertedID;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog(e.Message);
            }

            return PersonID;
        }

        public static async Task<DataTable> FindPersonByPersonID(int PersonID)
        {
            DataTable Person = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SELECT * FROM People
                                 WHERE PersonID = @PersonID;";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                        {
                            if (Reader.HasRows)
                            {
                                Person.Load(Reader);
                            }
                        }
                    }
                }
            }
            catch(Exception e) { clsLogger.LogErrorToEventLog(e.Message); }
            return Person;
        }

        public static async Task<DataTable> FindPersonByNationalNo(string NationalNo)
        {
            DataTable Person = new DataTable();
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SELECT * FROM People
                                 WHERE NationalNo = @NationalNo;";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();

                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                        {
                            if (Reader.HasRows)
                            {
                                Person.Load(Reader);
                            }
                        }
                    }
                }
            }
            catch (Exception e) { clsLogger.LogErrorToEventLog(e.Message); }
            return Person;
        }

        public static async Task<bool> UpdatePerson(int PersonID, string NationalNo, string FirstName, string LastName, string Email, string Phone)
        {
            int AffectedRows = 0;
            
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"UPDATE [dbo].[People]
                                 SET [FirstName] = @FirstName
                                    ,[LastName] = @LastName
                                    ,[Email] = @Email
                                    ,[Phone] = @Phone
                                    ,[NationalNo] = @NationalNo
                               WHERE PersonID = @PersonID";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Command.Parameters.AddWithValue("@FirstName", FirstName);
                        Command.Parameters.AddWithValue("@LastName", LastName);
                        Command.Parameters.AddWithValue("@Email", Email);
                        Command.Parameters.AddWithValue("@Phone", Phone);
                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        await Connection.OpenAsync();

                        AffectedRows = await Command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch(Exception e) { clsLogger.LogErrorToEventLog(e.Message); }

            return AffectedRows > 0;
        }

        public static async Task<bool> IsExist(string NationalNo)
        {
            object IsFound = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = "SELECT Found = 1 FROM People WHERE NationalNo = @NationalNo;";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.Parameters.AddWithValue("@NationalNo", NationalNo);

                        await Connection.OpenAsync();

                        IsFound = await Command.ExecuteScalarAsync();
                    }
                }
            }
            catch(Exception e) { clsLogger.LogErrorToEventLog(e.Message); }

            if (IsFound != null)
                return true;
            
            return false;
        }

        public static async Task<bool> DeletePerson(int PersonID)
        {
            int AffectedRows = 0;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"DELETE FROM [dbo].[People]
                                    WHERE PersonID = @PersonID;";
                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        await Connection.OpenAsync();

                        AffectedRows = await Command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch(Exception e) { clsLogger.LogErrorToEventLog(e.Message); }
            
            return AffectedRows > 0;
        }
    }
}
