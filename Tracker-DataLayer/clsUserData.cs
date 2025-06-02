using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Tracker_DataLayer
{
    public class clsUserData
    {
        public static async Task<DataTable> FindUserByID(int UserID)
        {
            DataTable User = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = "SELECT * FROM Users WHERE UserID = @UserID";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();

                        Command.Parameters.AddWithValue("@UserID", UserID);

                        using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                        {
                            if (Reader.HasRows)
                                User.Load(Reader);
                        }
                    }
                }
            }
            catch (Exception ex) { clsLogger.LogErrorToEventLog(ex.Message); }
            return User;
        }

        public static async Task<DataTable> FindByUsernameAndPassword(string UserName, string Password)
        {

            DataTable User = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SELECT * FROM Users 
                                       WHERE
                                         Password = @Password AND UserName = @UserName;";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();

                        Command.Parameters.AddWithValue("@Password", Password);
                        Command.Parameters.AddWithValue("@UserName", UserName);

                        using (SqlDataReader Reader = await Command.ExecuteReaderAsync())
                        {
                            if (Reader.HasRows)
                                User.Load(Reader);
                        }
                    }
                }
            }
            catch (Exception ex) { clsLogger.LogErrorToEventLog(ex.Message); }
            return User;

        }

        public static async Task<int> AddNewUser(int PersonID, string UserName, string Password, bool IsActive)
        {
            object UserID;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"INSERT INTO [dbo].[Users]
                                     ([PersonID]
                                     ,[UserName]
                                     ,[Password]
                                     ,[IsActive])
                               VALUES
                                     (@PersonID
                                     ,@UserName
                                     ,@Password
                                     ,@IsActive); 
                                 SELECT SCOPE_IDENTITY();";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();

                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        Command.Parameters.AddWithValue("@UserName", UserName);
                        Command.Parameters.AddWithValue("@Password", Password);
                        Command.Parameters.AddWithValue("@IsActive", IsActive);

                        UserID = await Command.ExecuteScalarAsync();

                        if (UserID != null)
                            return int.Parse(UserID.ToString());
                    }

                }
            }
            catch (Exception e) { clsLogger.LogErrorToEventLog(e.Message); }

            return -1;
        }

        public static async Task<bool> UpdateUser(int UserID, string UserName, string Password, bool IsActive)
        {
            int AffectedRows = 0;

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"UPDATE [dbo].[Users]
                                 SET [UserName] = @UserName,
                                     [Password] = @Password,
                              	   [IsActive] = @IsActive 
                                     
                                WHERE UserID = @UserID";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();

                        Command.Parameters.AddWithValue("@UserName", UserName);
                        Command.Parameters.AddWithValue("@Password", Password);
                        Command.Parameters.AddWithValue("@IsActive", IsActive);
                        Command.Parameters.AddWithValue("@UserID", UserID);

                        AffectedRows = await Command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception e) { clsLogger.LogErrorToEventLog(e.Message); }

            return AffectedRows > 0;
        }

        public static async Task<DataTable> GetAllUsers()
        {
            DataTable Users = new DataTable();

            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SELECT * FROM [dbo].[AllUsersView]";

                    using (SqlCommand command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                                Users.Load(reader);
                        }
                    }
                }
            }
            catch (Exception e) { clsLogger.LogErrorToEventLog(e.Message); }

            return Users;
        }

        public static async Task<bool> IsUserExistByPersonID(int PersonID)
        {
            object IsFound = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SELECT Find = 1 FROM Users 
                                      WHERE PersonID = @PersonID;";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();
                        Command.Parameters.AddWithValue("@PersonID", PersonID);
                        IsFound = await Command.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog($"{e.Message}");
            }

            return IsFound != null;
        }

        public static async Task<bool> IsUserExistByUserName(string UserName)
        {
            object IsFound = null;
            try
            {
                using (SqlConnection Connection = new SqlConnection(ConnectionSettings.DatabaseLink))
                {
                    string quiry = @"SELECT Find = 1 FROM Users 
                                      WHERE UserName = @UserName;";

                    using (SqlCommand Command = new SqlCommand(quiry, Connection))
                    {
                        await Connection.OpenAsync();
                        Command.Parameters.AddWithValue("@UserName", UserName);
                        IsFound = await Command.ExecuteScalarAsync();
                    }
                }
            }
            catch (Exception e)
            {
                clsLogger.LogErrorToEventLog($"{e.Message}");
            }

            return IsFound != null;
        }
    }
}
