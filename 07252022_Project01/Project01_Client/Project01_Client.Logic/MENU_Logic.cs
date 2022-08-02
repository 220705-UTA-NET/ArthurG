using System;
using Project01_Client.Data;

namespace Project01_Client.Logic
{
    public class MENU_LOGIC
    {
        // FIELDS
        private MENU_DISPLAY MENU_PROP_menuNavigator = new MENU_DISPLAY();
        private API_CONNECTION API_COMMANDS = new API_CONNECTION();
        private API_DTO MENU_PROP_userDATA = new API_DTO();
        // CONSTRUCTORS
        // METHODS
        public async Task MENU_LOGIC_MAIN()
        {
            MENU_LOGIC_START MENU_startMenu = new MENU_LOGIC_START();
            MENU_PROP_userDATA = await MENU_startMenu.MENU_LOGIC_START_MAIN();

            if(MENU_PROP_userDATA.id == -1)
            {
                return;
            }

            bool FLAG_runMainMenu = true;
            ConsoleKeyInfo INPUT_userMenu = new ConsoleKeyInfo();
            while (FLAG_runMainMenu)
            {
                Console.Clear();
                MENU_PROP_menuNavigator.MENU_DISPLAY_printMainMenu(MENU_PROP_userDATA.username, MENU_PROP_userDATA.tokens, MENU_PROP_userDATA.proAccount);

                INPUT_userMenu = Console.ReadKey();
                switch (INPUT_userMenu.Key)
                {
                    case ConsoleKey.S:
                        if (MENU_PROP_userDATA.proAccount)
                        {
                            Console.Clear();
                            GAME_LOGIC MENU_PROP_gameSession = new GAME_LOGIC(100, 30, 100);
                            MENU_PROP_gameSession.GAME_LOGIC_MAIN();
                        }
                        else
                        {
                            if(MENU_PROP_userDATA.tokens > 0)
                            {
                                Console.Clear();
                                int TEMP = await API_COMMANDS.API_Request_UpdateTokens(MENU_PROP_userDATA.id, MENU_PROP_userDATA.tokens - 1);
                                MENU_PROP_userDATA.tokens--;
                                GAME_LOGIC MENU_PROP_gameSession = new GAME_LOGIC(100, 30, 100);
                                MENU_PROP_gameSession.GAME_LOGIC_MAIN(); 
                            }
                            else
                            {
                                Console.SetCursorPosition(0, 25);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Sorry, Out of Tokens!");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine();
                                Console.WriteLine("Press Anything To Continue");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case ConsoleKey.C:
                        if(MENU_PROP_userDATA.proAccount)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.SetCursorPosition(0, 25);
                            int INPUT_gameSpeed = 0;
                            while (INPUT_gameSpeed == 0)
                            {
                                Console.WriteLine("Please Enter Desired Game Speed (Milliseconds)");
                                string TEMP_gameSpeed = Console.ReadLine();
                                int.TryParse(TEMP_gameSpeed, out INPUT_gameSpeed);
                            }

                            Console.WriteLine("Please Resize Window To Desired Game Size");
                            Console.WriteLine("    Press Anything To Continue");
                            Console.ReadKey();

                            Console.Clear();
                            GAME_LOGIC MENU_PROP_gameSession = new GAME_LOGIC(INPUT_gameSpeed);
                            MENU_PROP_gameSession.GAME_LOGIC_MAIN();
                        }
                        else
                        {
                            Console.SetCursorPosition(0, 25);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Sorry, Custom Game Mode Is For PRO Members Only!");

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine();
                            Console.WriteLine("Press Anything To Continue");
                            Console.ReadKey();
                        }
                        break;
                    case ConsoleKey.A:
                        ConsoleKeyInfo INPUT_userAccountMenu;
                        bool FLAG_runAccountMenu = true;
                        while(FLAG_runAccountMenu)
                        {
                            Console.Clear();
                            MENU_PROP_menuNavigator.MENU_DISPLAY_printAccountMenu(MENU_PROP_userDATA);
                            INPUT_userAccountMenu = Console.ReadKey();
                            switch (INPUT_userAccountMenu.Key)
                            {
                                case ConsoleKey.B:
                                    Console.SetCursorPosition(0, 25);
                                    Console.WriteLine("Not Implemented - Add Way To Link to Payment System");
                                    Console.WriteLine(@"Please Enter 'I need sleep' To Upgrade to PRO Account");
                                    Console.WriteLine();
                                    string INPUT_textB = Console.ReadLine();
                                    if (INPUT_textB == "I need sleep")
                                    {
                                        await API_COMMANDS.API_Request_UpdateProAccount(MENU_PROP_userDATA.id, true);
                                        MENU_PROP_userDATA.proAccount = true;
                                    }
                                    break;
                                case ConsoleKey.P:
                                    Console.SetCursorPosition(0, 25);
                                    Console.WriteLine("Not Implemented - Add Way To Link to Payment System");
                                    Console.WriteLine(@"Please Enter 'I need sleep' To Buy 5 Tokens");
                                    Console.WriteLine();
                                    string INPUT_textP = Console.ReadLine();
                                    if (INPUT_textP == "I need sleep")
                                    {
                                        MENU_PROP_userDATA.tokens = MENU_PROP_userDATA.tokens + 5;
                                        await API_COMMANDS.API_Request_UpdateTokens(MENU_PROP_userDATA.id, MENU_PROP_userDATA.tokens);
                                    }
                                    break;
                                case ConsoleKey.E:
                                    Console.SetCursorPosition(0, 25);
                                    Console.WriteLine("Not Implemented - Add Way To Link Google Adsense");
                                    Console.WriteLine(@"Please Enter 'I need sleep' To Earn 1 Token");
                                    Console.WriteLine();
                                    string INPUT_textE = Console.ReadLine();
                                    if (INPUT_textE == "I need sleep")
                                    {
                                        MENU_PROP_userDATA.tokens = MENU_PROP_userDATA.tokens + 1;
                                        await API_COMMANDS.API_Request_UpdateTokens(MENU_PROP_userDATA.id, MENU_PROP_userDATA.tokens);
                                    }
                                    break;
                                case ConsoleKey.R:
                                    FLAG_runAccountMenu = false;
                                    break;
                            }

                        }
                        break;
                    case ConsoleKey.Q:
                        Console.SetCursorPosition(0, 25);
                        FLAG_runMainMenu = false; 
                        break;
                }
            }
        }
    }
}
