namespace Project01_Server.Model
{
    public class DATA_UserData
    {
        // FIELDS
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Tokens { get; set; }
        public bool ProAccount { get; set; }


        // CONSTRUCTORS
        public DATA_UserData () { }

        public DATA_UserData (int INPUT_ID, string INPUT_Username, string INPUT_Password, int INPUT_Tokens, bool INPUT_ProAccount)
        {
            this.ID = INPUT_ID;
            this.Username = INPUT_Username;
            this.Password = INPUT_Password;
            this.Tokens = INPUT_Tokens;
            this.ProAccount = INPUT_ProAccount;
        }

        // METHODS
    }
}