using System;
using Project01_Client.Data;


namespace Project01_Client.Logic
{
    internal class MENU_LOGIC_START
    {
        // FIELDS
        private MENU_DISPLAY MENU_PROP_menuNavigator = new MENU_DISPLAY();
        private API_CONNECTION API_COMMANDS = new API_CONNECTION();

        // CONSTRUCTORS

        // METHODS
        internal async Task<API_DTO> MENU_LOGIC_START_MAIN()
        {
            Console.CursorVisible = false;

            API_DTO OUTPUT_DTO = new API_DTO(-1, "", "", -1, false);

            ConsoleKeyInfo INPUT_userMenu = new ConsoleKeyInfo();
            bool FLAG_runStartMenu = true;
            while (FLAG_runStartMenu)
            {
                Console.Clear();
                MENU_PROP_menuNavigator.MENU_DISPLAY_printStartMenu();
                INPUT_userMenu = Console.ReadKey(true);

                switch (INPUT_userMenu.Key)
                {
                    case ConsoleKey.L:
                        API_DTO WORK_currentUserData = await MENU_LOGIC_START_Login();
                        if (WORK_currentUserData.id != -1)
                        {
                            FLAG_runStartMenu = false;
                            OUTPUT_DTO = WORK_currentUserData;
                        }
                        break;
                    case ConsoleKey.N:
                        await MENU_LOGIC_START_NewUser();
                        break;
                    case ConsoleKey.Q:
                        Console.SetCursorPosition(0, 25);
                        FLAG_runStartMenu = false;
                        break;
                }
            }

            return OUTPUT_DTO;
        }

        private async Task<API_DTO> MENU_LOGIC_START_Login()
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("\tLOGIN");

            string INPUT_Username = "";
            string INPUT_Password = "";

            while (INPUT_Username == "")
            {
                Console.WriteLine("Please Enter Username:");
                INPUT_Username = Console.ReadLine();
            }

            while (INPUT_Password == "")
            {
                Console.WriteLine("Please Enter Password:");
                INPUT_Password = Console.ReadLine();
            }

            API_DTO API_response = await API_COMMANDS.API_REQUEST_Login(INPUT_Username, INPUT_Password);

            if (API_response.id == -1)
            {
                Console.WriteLine("Login Failed");
            }
            else
            {
                Console.WriteLine("Login Succesful");
            }

            Console.WriteLine();
            Console.WriteLine("Press Anything To Continue");
            Console.ReadKey();
            return API_response;
        }
        private async Task MENU_LOGIC_START_NewUser()
        {
            Console.SetCursorPosition(0, 25);
            Console.WriteLine("\tCreate New User");

            string INPUT_Username = "";
            string INPUT_Password = "";

            while (INPUT_Username == "")
            {
                Console.WriteLine("Please Enter Username:");
                INPUT_Username = Console.ReadLine();
            }

            while (INPUT_Password == "")
            {
                Console.WriteLine("Please Enter Password:");
                INPUT_Password = Console.ReadLine();
            }

            bool FLAG_CreatedUser = await API_COMMANDS.API_REQUST_NewUser(INPUT_Username, INPUT_Password);

            if (FLAG_CreatedUser == true)
            {
                Console.WriteLine("Successfully Created New User");
            }
            else
            {
                Console.WriteLine("Failed To Create New User");
            }

            Console.WriteLine();
            Console.WriteLine("Press Anything To Continue");
            Console.ReadKey();
        }
    }
}