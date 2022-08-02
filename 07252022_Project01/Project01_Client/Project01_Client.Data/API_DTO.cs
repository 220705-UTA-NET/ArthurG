using System;

namespace Project01_Client.Data
{
    public class API_DTO
    {
        // FIELDS
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public int tokens { get; set; }
        public bool proAccount { get; set; }

        // CONSTRUCTORS
        public API_DTO () { }
        public API_DTO (int id, string username, string password, int tokens, bool proAccount)
        {
            this.id = id;
            this.username = username;
            this.password = password;
            this.tokens = tokens; ;
            this.proAccount = proAccount;
        }


        // METHODS
        public void API_DTO_DEBUG()
        {
            Console.WriteLine(id);
            Console.WriteLine(username);
            Console.WriteLine(password);
            Console.WriteLine(tokens);
            Console.WriteLine(proAccount);
        }
    }
}
