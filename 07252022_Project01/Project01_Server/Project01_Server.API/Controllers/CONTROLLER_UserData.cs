using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project01_Server.Data;
using Project01_Server.Model;

namespace Project01_Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CONTROLLER_UserData : ControllerBase
    {
        // FIELDS
        private readonly INTERFACE_Database API_PROP_interfaceDB;
        private readonly ILogger<CONTROLLER_UserData> API_DATA_Logger;

        // CONSTRUCTORS
        public CONTROLLER_UserData(INTERFACE_Database INPUT_interfaceDB, ILogger<CONTROLLER_UserData> INPUT_logger)
        {
            this.API_PROP_interfaceDB = INPUT_interfaceDB;
            this.API_DATA_Logger = INPUT_logger;
        }

        // METHODS
        // Gets username and password, returns full data if valid or dummy null class if false (-1,null,null,-1,-1)
        [HttpPost]
        [Route("CheckLogin")]
        public async Task<ActionResult<DATA_UserData>> API_checkValidLogin (string INPUT_Username, string INPUT_Password)
        {
            DATA_UserData OUTPUT_currentUser;

            try
            {
                OUTPUT_currentUser = await API_PROP_interfaceDB.SQL_Database_CheckUserLogin_ASYNC(INPUT_Username, INPUT_Password);
            }
            catch (Exception e)
            {
                API_DATA_Logger.LogError(e, e.Message);
                return StatusCode(500);
            }

            return OUTPUT_currentUser;
        }

        [HttpPost]
        [Route("SetTokens")]
        public async Task<ActionResult<int>> API_updateTokens(int INPUT_ID, int INPUT_Tokens)
        {
            int OUTPUT_Tokens;

            try
            {
                await API_PROP_interfaceDB.SQL_Database_SetTokenAmount_ASYNC(INPUT_ID, INPUT_Tokens);
                OUTPUT_Tokens = await API_PROP_interfaceDB.SQL_Database_GetTokenAmount_ASYNC(INPUT_ID);
            }
            catch (Exception e)
            {
                API_DATA_Logger.LogError(e, e.Message);
                return StatusCode(500);
            }

            return OUTPUT_Tokens;
        }

        [HttpPost]
        [Route("SetProAccount")]
        public async Task<ActionResult<bool>> API_updateProAccount(int INPUT_ID, bool INPUT_ProAccount)
        {
            bool OUTPUT_ProAccount;

            try
            {
                await API_PROP_interfaceDB.SQL_Database_SetProAccount_ASYNC(INPUT_ID, INPUT_ProAccount);
                OUTPUT_ProAccount = await API_PROP_interfaceDB.SQL_Database_GetProAccount_ASYNC(INPUT_ID);
            }
            catch (Exception e)
            {
                API_DATA_Logger.LogError(e, e.Message);
                return StatusCode(500);
            }

            return OUTPUT_ProAccount;
        }

        [HttpPost]
        [Route("CreateNewUser")]
        public async Task<ActionResult<bool>> API_createNewUser(string INPUT_Username, string INPUT_Password)
        {
            bool OUTPUT_CreatedUser;

            try
            {
                OUTPUT_CreatedUser = await API_PROP_interfaceDB.SQL_Database_CreateNewUser_ASYNC(INPUT_Username, INPUT_Password);
            }
            catch (Exception e)
            {
                API_DATA_Logger.LogError(e, e.Message);
                return StatusCode(500);
            }

            return OUTPUT_CreatedUser;
        }
    }
}
