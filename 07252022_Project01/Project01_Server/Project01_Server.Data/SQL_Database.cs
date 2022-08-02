using Microsoft.Extensions.Logging;
using Project01_Server.Model;
using System.Data.SqlClient;

namespace Project01_Server.Data
{
    public class SQL_Database : INTERFACE_Database
    {
        // FIELDS
        private readonly string DB_PROP_connectionString;
        private readonly ILogger<SQL_Database> DB_DATA_Logger;

        // CONSTRUCTORS
        public SQL_Database(string INPUT_connectonString, ILogger<SQL_Database> INPUT_logger)
        {
            this.DB_PROP_connectionString = INPUT_connectonString;
            this.DB_DATA_Logger = INPUT_logger;
        }

        // METHODS
        public async Task<DATA_UserData> SQL_Database_CheckUserLogin_ASYNC(string INPUT_username, string INPUT_password)
        {
            using SqlConnection DB_connection = new SqlConnection(DB_PROP_connectionString);
            await DB_connection.OpenAsync();

            string DB_commandText = @"SELECT DB_ID, DB_Username, DB_Password, DB_Tokens, DB_ProAccount FROM Project01_Snake.UserData WHERE DB_Username = @INPUT_Username AND DB_Password = @INPUT_Password;";
           
            using SqlCommand DB_command = new SqlCommand(DB_commandText, DB_connection);
            DB_command.Parameters.AddWithValue("@INPUT_Username", INPUT_username);
            DB_command.Parameters.AddWithValue("@INPUT_Password", INPUT_password);

            using SqlDataReader DB_reader = await DB_command.ExecuteReaderAsync();

            if (DB_reader.HasRows == false)
            {
                DB_DATA_Logger.LogInformation("Executed SQL_Database_checkUserLogin_ASYNC --- Returned User !!! NULL !!!");

                DATA_UserData OUTPUT_currentUser = new DATA_UserData(-1, "", "", -1, false);
                await DB_connection.CloseAsync();
                return OUTPUT_currentUser;
            }
            else
            {
                await DB_reader.ReadAsync();

                int WORK_currentID = DB_reader.GetInt32(0);
                string WORK_currentUsername = DB_reader.GetString(1);
                string WORK_currentPassword = DB_reader.GetString(2);
                int WORK_currentTokens = DB_reader.GetInt32(3);
                bool WORK_currentPro = DB_reader.GetBoolean(4);

                DB_DATA_Logger.LogInformation("Executed SQL_Database_checkUserLogin_ASYNC --- Returned User {0}", WORK_currentUsername);

                DATA_UserData OUTPUT_currentUser = new DATA_UserData(WORK_currentID, WORK_currentUsername, WORK_currentPassword, WORK_currentTokens, WORK_currentPro);
                await DB_connection.CloseAsync();
                return OUTPUT_currentUser;
            }
        }

        public async Task SQL_Database_SetTokenAmount_ASYNC(int INPUT_ID, int INPUT_Tokens)
        {
            using SqlConnection DB_connection = new SqlConnection(DB_PROP_connectionString);
            await DB_connection.OpenAsync();

            string DB_commandText = @"UPDATE Project01_Snake.UserData SET DB_Tokens = @INPUT_Tokens WHERE DB_ID = @INPUT_ID";

            using SqlCommand DB_command = new SqlCommand(DB_commandText, DB_connection);
            DB_command.Parameters.AddWithValue("@INPUT_ID", INPUT_ID);
            DB_command.Parameters.AddWithValue("@INPUT_Tokens", INPUT_Tokens);

            await DB_command.ExecuteNonQueryAsync();

            DB_DATA_Logger.LogInformation("Executed SQL_Database_UpdateTokenAmount_ASYNC --- Set Tokens {0} for User {1}", INPUT_Tokens, INPUT_ID);

            await DB_connection.CloseAsync();
            return;
        }

        public async Task<int> SQL_Database_GetTokenAmount_ASYNC(int INPUT_ID)
        {
            using SqlConnection DB_connection = new SqlConnection(DB_PROP_connectionString);
            await DB_connection.OpenAsync();

            string DB_commandText = @"SELECT DB_Tokens FROM Project01_Snake.UserData WHERE DB_ID = 1;";

            using SqlCommand DB_command = new SqlCommand(DB_commandText, DB_connection);
            DB_command.Parameters.AddWithValue("@INPUT_ID", INPUT_ID);

            using SqlDataReader DB_reader = await DB_command.ExecuteReaderAsync ();

            DB_reader.Read();
            int OUTPUT_Tokens = DB_reader.GetInt32(0);

            DB_DATA_Logger.LogInformation("Executed SQL_Database_UpdateTokenAmount_ASYNC --- Get Tokens {0} for User {1}", OUTPUT_Tokens, INPUT_ID);

            await DB_connection.CloseAsync();
            return OUTPUT_Tokens;
        }

        public async Task SQL_Database_SetProAccount_ASYNC(int INPUT_ID, bool INPUT_ProAccount)
        {
            using SqlConnection DB_connection = new SqlConnection(DB_PROP_connectionString);
            await DB_connection.OpenAsync();

            string DB_commandText = @"UPDATE Project01_Snake.UserData SET DB_ProAccount = @INPUT_ProAccount WHERE DB_ID = @INPUT_ID";

            using SqlCommand DB_command = new SqlCommand(DB_commandText, DB_connection);
            DB_command.Parameters.AddWithValue("@INPUT_ID", INPUT_ID);
            DB_command.Parameters.AddWithValue("@INPUT_ProAccount", INPUT_ProAccount);

            await DB_command.ExecuteNonQueryAsync();

            DB_DATA_Logger.LogInformation("Executed SQL_Database_UpdateTokenAmount_ASYNC --- Set ProAccount {0} for User {1}", INPUT_ProAccount, INPUT_ID);

            await DB_connection.CloseAsync();
            return;
        }
        public async Task<bool> SQL_Database_GetProAccount_ASYNC(int INPUT_ID)
        {
            using SqlConnection DB_connection = new SqlConnection(DB_PROP_connectionString);
            await DB_connection.OpenAsync();

            string DB_commandText = @"SELECT DB_ProAccount FROM Project01_Snake.UserData WHERE DB_ID = 1;";

            using SqlCommand DB_command = new SqlCommand(DB_commandText, DB_connection);
            DB_command.Parameters.AddWithValue("@INPUT_ID", INPUT_ID);

            using SqlDataReader DB_reader = await DB_command.ExecuteReaderAsync();

            DB_reader.Read();
            bool OUTPUT_ProAccount = DB_reader.GetBoolean(0);

            DB_DATA_Logger.LogInformation("Executed SQL_Database_UpdateTokenAmount_ASYNC --- Get ProAccount {0} for User {1}", OUTPUT_ProAccount, INPUT_ID);

            await DB_connection.CloseAsync();
            return OUTPUT_ProAccount;
        }
        public async Task<bool> SQL_Database_CreateNewUser_ASYNC(string INPUT_Username, string INPUT_Password)
        {
            using SqlConnection DB_connection = new SqlConnection(DB_PROP_connectionString);
            await DB_connection.OpenAsync();

            string DB_commandCheckExistsText = @"SELECT DB_ID FROM Project01_Snake.UserData WHERE DB_Username = @INPUT_Username;";
            using SqlCommand DB_commandCheckExists = new SqlCommand(DB_commandCheckExistsText, DB_connection);

            DB_commandCheckExists.Parameters.AddWithValue("@INPUT_Username", INPUT_Username);

            using SqlDataReader DB_reader = await DB_commandCheckExists.ExecuteReaderAsync();
            
            if (DB_reader.HasRows == true)
            {
                DB_DATA_Logger.LogInformation("Executed SQL_Database_checkUserLogin_ASYNC --- FAILED Username {0} Already Exists", INPUT_Username);

                await DB_connection.CloseAsync();
                return false;
            }
            await DB_reader.CloseAsync();

            string DB_commandInsertUserText = @"INSERT INTO Project01_Snake.UserData (DB_Username, DB_Password, DB_Tokens, DB_ProAccount) VALUES (@INPUT_Username, @INPUT_Password, 3, 0);";
            using SqlCommand DB_commandInsertUser = new SqlCommand(DB_commandInsertUserText, DB_connection);
            DB_commandInsertUser.Parameters.AddWithValue("@INPUT_Username", INPUT_Username);
            DB_commandInsertUser.Parameters.AddWithValue("@INPUT_Password", INPUT_Password);

            await DB_commandInsertUser.ExecuteNonQueryAsync();

            DB_DATA_Logger.LogInformation("Executed SQL_Database_checkUserLogin_ASYNC --- RETURNED Created User {0} with Password {1}" , INPUT_Username, INPUT_Password);

            await DB_connection.CloseAsync();
            return true;
        }
    }
}