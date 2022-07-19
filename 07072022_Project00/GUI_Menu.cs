//Class loads menus from directory to print to console.

using System;

namespace Project_00
{
    class GUI_Menu
    {
        // Fields
        
        // Constructors

        // Methods
        public void GUI_MENU_printMainMenu()
        {
            string PATH_mainMenu = @"./MENUS/MENU_Main.txt";

            StreamReader WORK_fsStream = new StreamReader(PATH_mainMenu);
            string WORK_fsLine;
            while((WORK_fsLine = WORK_fsStream.ReadLine()) != null)
            {
                Console.WriteLine(WORK_fsLine);
            }
        }

        public void GUI_MENU_printCredits()
        {
            Console.Clear();
            string PATH_mainMenu = @"./MENUS/MENU_Credits.txt";

            StreamReader WORK_fsStream = new StreamReader(PATH_mainMenu);
            string WORK_fsLine;
            while((WORK_fsLine = WORK_fsStream.ReadLine()) != null)
            {
                Console.WriteLine(WORK_fsLine);
            }

            Console.WriteLine();
            Console.WriteLine("Press anything to return to main menu");
            Console.ReadKey();
        }
    }
}