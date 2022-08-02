using System;

namespace Project01_Client.Logic
{
    internal class GAME_DISPLAY
    {
        // CONSTRUCTOR
        internal GAME_DISPLAY() 
        {
            Console.CursorVisible = false;
        }

        // METHODS
        internal void GAME_DISPLAY_printBorder(int GAME_PROP_Width, int GAME_PROP_Height)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;

            // Prints Horizontal Border
            for (int i = 0; i < GAME_PROP_Width-1 ; i++)
            {
                Console.SetCursorPosition(i , 0);
                Console.Write("-");
            }
            for (int i = 0; i < GAME_PROP_Width-1 ; i++)
            {
                Console.SetCursorPosition(i , GAME_PROP_Height-1);
                Console.Write("-");
            }

            // Prints Vertical Border
            for (int i = 0; i < GAME_PROP_Height ; i++)
            {
                Console.SetCursorPosition(0 , i);
                Console.Write("|");
            }
            for(int i = 0; i < GAME_PROP_Height ; i++)
            {
                Console.SetCursorPosition(GAME_PROP_Width-1, i);
                Console.Write("|");
            }
        }

        // Implementaion of reprinting entire snake
        /*internal void GAME_DISPLAY_printSnake(List<GAME_LOGIC_COORDINATES> INPUT_snakeLocation)
        {
            GAME_LOGIC_COORDINATES WORK_currentCoordinate;
            for (int i = 0; i < INPUT_snakeLocation.Count; i++)
            {
                WORK_currentCoordinate = INPUT_snakeLocation[i];
                Console.SetCursorPosition(WORK_currentCoordinate.COORDINATE_X, WORK_currentCoordinate.COORDINATE_Y);
                Console.Write("+");

            }
        }*/

        // Implementation of just changing head and tail.
        internal void GAME_DISPLAY_printSnakeHead(GAME_LOGIC_COORDINATES INPUT_snakeHead)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;

            Console.SetCursorPosition(INPUT_snakeHead.COORDINATE_X, INPUT_snakeHead.COORDINATE_Y);
            Console.Write("+");
        }
        internal void GAME_DISPLAY_clearSnakeTail(GAME_LOGIC_COORDINATES INPUT_snakeTail)
        {
            Console.SetCursorPosition(INPUT_snakeTail.COORDINATE_X, INPUT_snakeTail.COORDINATE_Y);
            Console.Write(" ");
        }

        internal void GAME_DISPLAY_printFoodLocation(GAME_LOGIC_COORDINATES INPUT_foodLocal)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.SetCursorPosition(INPUT_foodLocal.COORDINATE_X, INPUT_foodLocal.COORDINATE_Y);
            Console.Write("@");
        }
    }
}
