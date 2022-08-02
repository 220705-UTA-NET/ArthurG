using System;

namespace Project01_Client.Logic
{
    public class MENU_LOGIC
    {
        // FIELDS
        private MENU_DISPLAY MENU_PROP_menuNavigator = new MENU_DISPLAY();
        // CONSTRUCTORS
        // METHODS
        public void MENU_LOGIC_MAIN()
        {
            MENU_PROP_menuNavigator.MENU_DISPLAY_printStartMenu();
        }

        private void MENU_LOGIC_startMenu()
        {
            MENU_PROP_menuNavigator.MENU_DISPLAY_printStartMenu();

            ConsoleKeyInfo INPUT_userMenu = new ConsoleKeyInfo();
            bool FLAG_runMenu = true;
            while (FLAG_runMenu)
            {
                INPUT_userMenu = Console.ReadKey();

                switch(INPUT_userMenu.KeyChar)
                {
                    case 'L':
                        break;
                    case 'N':
                        break;
                    case 'Q':
                        FLAG_runMenu = false;
                        break;
                }
            }
        }
    }
}
