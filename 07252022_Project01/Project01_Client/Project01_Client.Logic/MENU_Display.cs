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
    }
}
