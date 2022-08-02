using System;
using System.Text.Json;

namespace Project01_Client.Data
{
    public class API_CONNECTION
    {
        // FIELDS
        private static readonly HttpClient API_PROP_HTTPClient = new HttpClient();
        private readonly string API_PROP_requestBase = @"https://localhost:7100/api/CONTROLLER_UserData/";

        // CONSTRUCTOR
        public API_CONNECTION() { }

        // METHODS
        public async Task<API_DTO> API_REQUEST_Login(string INPUT_Username, string INPUT_Password)
        {
            string API_commandURI = API_PROP_requestBase + @"CheckLogin?INPUT_Username=" + INPUT_Username + "&INPUT_Password=" + INPUT_Password;

            var API_request = new HttpRequestMessage();
            API_request.RequestUri = new Uri(API_commandURI);
            API_request.Method = HttpMethod.Post;

            var API_responseVar = await API_PROP_HTTPClient.SendAsync(API_request);
            string API_responseString = await API_responseVar.Content.ReadAsStringAsync();

            API_DTO API_responseDTO = JsonSerializer.Deserialize<API_DTO>(API_responseString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            //API_responseDTO.API_DTO_DEBUG();

            return API_responseDTO;
        }

        public async Task<bool> API_REQUST_NewUser(string INPUT_Username, string INPUT_Password)
        {
            string API_commandURI = API_PROP_requestBase + @"CreateNewUser?INPUT_Username=" + INPUT_Username + "&INPUT_Password=" + INPUT_Password;

            var API_request = new HttpRequestMessage();
            API_request.RequestUri = new Uri(API_commandURI);
            API_request.Method = HttpMethod.Post;

            var API_responseVar = await API_PROP_HTTPClient.SendAsync(API_request);
            string API_responseString = await API_responseVar.Content.ReadAsStringAsync();

            if (API_responseString == "true")
            { 
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> API_Request_UpdateTokens(int INPUT_ID, int INPUT_Tokens)
        {
            string API_commandURI = API_PROP_requestBase + @"SetTokens?INPUT_ID=" + INPUT_ID + "&INPUT_Tokens=" + INPUT_Tokens;

            var API_request = new HttpRequestMessage();
            API_request.RequestUri = new Uri(API_commandURI);
            API_request.Method = HttpMethod.Post;

            var API_responseVar = await API_PROP_HTTPClient.SendAsync(API_request);
            string API_responseString = await API_responseVar.Content.ReadAsStringAsync();

            int OUTPUT_TokenAmount = int.Parse(API_responseString);
            return OUTPUT_TokenAmount;
        }

        public async Task<bool> API_Request_UpdateProAccount(int INPUT_ID, bool INPUT_ProAccount)
        {
            string API_commandURI = API_PROP_requestBase + @"SetProAccount?INPUT_ID=" + INPUT_ID + "&INPUT_ProAccount=" + INPUT_ProAccount;

            var API_request = new HttpRequestMessage();
            API_request.RequestUri = new Uri(API_commandURI);
            API_request.Method = HttpMethod.Post;

            var API_responseVar = await API_PROP_HTTPClient.SendAsync(API_request);
            string API_responseString = await API_responseVar.Content.ReadAsStringAsync();

            return INPUT_ProAccount;
        }
    }
}