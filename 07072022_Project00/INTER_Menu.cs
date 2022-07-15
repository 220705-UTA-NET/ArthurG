using System;

namespace Project_00
{
    class GUI
    {
        static void GUI_Game(string[] INPUT)
        {
            Console.WriteLine("Please enter the size of the grid");
            int INPUT_choice = int.Parse(Console.ReadLine());

            Console.Write(".");
            for (int COUNTER_MENU_row = 0 ; COUNTER_MENU_row < INPUT_choice ; COUNTER_MENU_row++)
                {
                    Console.Write("-------.");
                }
            Console.Write("\n");

            for (int COUNTER_MENU_column = 0 ; COUNTER_MENU_column < INPUT_choice ; COUNTER_MENU_column++)
            {
                for (int COUNTER_MENU_vertical = 0 ; COUNTER_MENU_vertical < 3 ; COUNTER_MENU_vertical++)
                {
                    Console.Write(@"|");
                    for (int COUNTER_MENU_verticalrow = 0 ; COUNTER_MENU_verticalrow < INPUT_choice ; COUNTER_MENU_verticalrow++)
                    {
                        Console.Write("       |");
                    }
                    Console.Write("\n");
                }
                Console.Write(".");
                for (int COUNTER_MENU_row = 0 ; COUNTER_MENU_row < INPUT_choice ; COUNTER_MENU_row++)
                {
                    Console.Write("-------.");
                }
                Console.Write("\n");
            }

            

            // Scalable Grid Format for Game

            // Console.WriteLine(@".-------.-------.-------.");
            // Console.WriteLine(@"|       |       |       |");
            // Console.WriteLine(@"|   A   |   B   |   C   |");
            // Console.WriteLine(@"|       |       |       |");
            // Console.WriteLine(@".-------.-------.-------.");
            // Console.WriteLine(@"|       |       |       |");
            // Console.WriteLine(@"|   A   |   B   |   C   |");
            // Console.WriteLine(@"|       |       |       |");
            // Console.WriteLine(@".-------.-------.-------.");
            // Console.WriteLine(@"|       |       |       |");
            // Console.WriteLine(@"|   A   |   B   |   C   |");
            // Console.WriteLine(@"|       |       |       |");
            // Console.WriteLine(@".-------.-------.-------.");
        }
    }
}