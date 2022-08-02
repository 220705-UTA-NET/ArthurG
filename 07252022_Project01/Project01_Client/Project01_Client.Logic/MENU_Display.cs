using Project01_Client.Data;
using System;

namespace Project01_Client.Logic
{
    internal class MENU_DISPLAY
    {
        // FIELDS
        // CONSTRUCTORS
        // METHODS

        private void MENU_DISPLAY_printMainMenuBlank()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"||===========================================================||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||       +----  +   |   /-\   |   |  +----                   ||");
            Console.WriteLine(@"||       |      |\  |  |   |  |  /   |        |      |       ||");
            Console.WriteLine(@"||       +---+  | \ |  |   |  +--    +----  --+--  --+--     ||");
            Console.WriteLine(@"||           |  |  \|  +---+  |  \   |        |      |       ||");
            Console.WriteLine(@"||       ----+  |   +  |   |  |   |  +----                   ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||                                                           ||");
            Console.WriteLine(@"||===========================================================||");
            Console.ResetColor();

            Console.SetCursorPosition(19, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Q - Quit Game");

            Console.ResetColor();
        }

        internal void MENU_DISPLAY_printStartMenu()
        {
            MENU_DISPLAY_printMainMenuBlank();

            Console.SetCursorPosition(19, 12);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("L - Login");

            Console.SetCursorPosition(19, 15);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("N - Create New User");

            Console.ResetColor();
        }

        internal void MENU_DISPLAY_printMainMenu(string INPUT_Username, int INPUT_Tokens, bool INPUT_ProAccount)
        {
            MENU_DISPLAY_printMainMenuBlank();

            Console.SetCursorPosition(13, 10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("User: " + INPUT_Username + "       ");
            if (INPUT_ProAccount)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("(PRO)");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.Write("(FREE)");
            }

            Console.SetCursorPosition(14, 11);
            Console.Write("Tokens: " + INPUT_Tokens);

            Console.SetCursorPosition(16, 14);
            Console.Write("S - Start Classic Game");

            Console.SetCursorPosition(16, 15);
            if(INPUT_ProAccount)
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
            Console.Write("C - Start Custom Game       (PRO)");
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(16, 18);
            Console.Write("A - Account Settings");
        }

        internal void MENU_DISPLAY_printAccountMenu(API_DTO INPUT_userData)
        {
            MENU_DISPLAY_printMainMenuBlank();

            Console.SetCursorPosition(19, 20);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("R - Return To Main Menu");

            Console.SetCursorPosition(13, 10);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("User: " + INPUT_userData.username + "       ");
            if (INPUT_userData.proAccount)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("(PRO)");
                Console.ForegroundColor = ConsoleColor.Yellow;
            }
            else
            {
                Console.Write("(FREE)");
            }

            Console.SetCursorPosition(14, 11);
            Console.Write("Tokens: " + INPUT_userData.tokens);

            Console.SetCursorPosition(16, 14);
            Console.Write("B - Upgrade to PRO Account");

            Console.SetCursorPosition(16, 15);
            Console.Write("P - Purchase Tokens");

            Console.SetCursorPosition(16, 17);
            Console.Write("E - Earn Free Tokens");
        }
    }
}
