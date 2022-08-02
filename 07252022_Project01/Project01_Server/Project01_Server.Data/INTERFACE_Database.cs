using Project01_Server.Model;

namespace Project01_Server.Data
{
    public interface INTERFACE_Database
    {
        Task<DATA_UserData> SQL_Database_CheckUserLogin_ASYNC(string INPUT_username, string INPUT_password);
        Task SQL_Database_SetTokenAmount_ASYNC(int INPUT_ID, int INPUT_Tokens);
        Task<int> SQL_Database_GetTokenAmount_ASYNC(int INPUT_ID);
        Task SQL_Database_SetProAccount_ASYNC(int INPUT_ID, bool INPUT_ProAccount);
        Task<bool> SQL_Database_GetProAccount_ASYNC(int INPUT_ID);
        Task<bool> SQL_Database_CreateNewUser_ASYNC(string INPUT_Username, string INPUT_Password);
    }
}
