using System;
using System.Collections;
using System.Timers;
using System.Threading;

namespace Project01_Client.Logic
{
    internal class GAME_LOGIC
    {
        // FIELDS
        internal int GAME_PROP_Width;
        internal int GAME_PROP_Height;
        internal int GAME_PROP_Speed;
        internal Random GAME_PROP_randomGen = new Random();

        private int GAME_DATA_snakeLength;
        private List<GAME_LOGIC_COORDINATES> GAME_DATA_snakeLocation = new List<GAME_LOGIC_COORDINATES>();
        private GAME_LOGIC_COORDINATES GAME_DATA_foodLocation;

        GAME_DISPLAY GAME_UI_Display = new GAME_DISPLAY();

        // CONSTRUCTOR
        internal GAME_LOGIC()
        {
            GAME_PROP_Width = Console.WindowWidth;
            GAME_PROP_Height = Console.WindowHeight;
            Console.SetWindowSize(GAME_PROP_Width, GAME_PROP_Height);

            GAME_PROP_Speed = 100;

            GAME_DATA_snakeLength = 1;

            GAME_LOGIC_COORDINATES WORK_startCoordinates = new(GAME_PROP_Width / 2, GAME_PROP_Height / 2);
            GAME_DATA_snakeLocation.Add(WORK_startCoordinates);

            GAME_UI_Display.GAME_DISPLAY_printBorder(GAME_PROP_Width, GAME_PROP_Height);
            GAME_UI_Display.GAME_DISPLAY_printSnakeHead(GAME_DATA_snakeLocation.Last());

            GAME_DATA_foodLocation = GAME_LOGIC_genFoodLocation();
            GAME_UI_Display.GAME_DISPLAY_printFoodLocation(GAME_DATA_foodLocation);
        }

        // METHODS
        internal int GAME_LOGIC_MAIN()
        {
            int INPUT_currUserChoice = 0;
            int INPUT_prevUserChoice = 0;

            bool FLAG_wonGame = false;
            INPUT_currUserChoice = GAME_LOGIC_getUserDirectionInput();
            while (FLAG_wonGame == false)
            {
                if (INPUT_currUserChoice == -1)
                {
                    break;
                }

                if (INPUT_currUserChoice == 0)
                {
                    INPUT_currUserChoice = INPUT_prevUserChoice;
                }

                GAME_LOGIC_convertSnakeMovement(INPUT_currUserChoice);

                int WORK_currentLocationState = GAME_LOGIC_checkSnakeLocation(GAME_DATA_snakeLocation.Last());
                if (WORK_currentLocationState == -1)
                {
                    //Snake head hits invalid block
                    break;
                }
                else if (WORK_currentLocationState == 1)
                {
                    //Snake head hits food
                    GAME_UI_Display.GAME_DISPLAY_printSnakeHead(GAME_DATA_snakeLocation.Last());
                    GAME_DATA_snakeLength++;

                    GAME_DATA_foodLocation = GAME_LOGIC_genFoodLocation();
                    GAME_UI_Display.GAME_DISPLAY_printFoodLocation(GAME_DATA_foodLocation);

                }
                else if (WORK_currentLocationState == 0)
                {
                    //Snake head hits nothing
                    GAME_UI_Display.GAME_DISPLAY_printSnakeHead(GAME_DATA_snakeLocation.Last());
                    GAME_UI_Display.GAME_DISPLAY_clearSnakeTail(GAME_DATA_snakeLocation[0]);
                    GAME_DATA_snakeLocation.RemoveAt(0);
                }

                /*// DEBUG - MANUAL CONTROL INPUTS
                INPUT_prevUserChoice = INPUT_currUserChoice;
                INPUT_currUserChoice = GAME_LOGIC_getUserDirectionInput();*/

                if (Console.KeyAvailable)
                {
                    INPUT_prevUserChoice = INPUT_currUserChoice;
                    INPUT_currUserChoice = GAME_LOGIC_getUserDirectionInput();
                }

                Thread.Sleep(GAME_PROP_Speed);
            }

            Console.Clear();
            Console.WriteLine(GAME_DATA_snakeLength);
            Console.ReadLine();
            return GAME_DATA_snakeLength;
        }
        private void GAME_LOGIC_convertSnakeMovement(int INPUT_snakeDirection)
        {
            GAME_LOGIC_COORDINATES WORK_newCoordinate = new GAME_LOGIC_COORDINATES(GAME_DATA_snakeLocation.Last().COORDINATE_X, GAME_DATA_snakeLocation.Last().COORDINATE_Y);
            switch (INPUT_snakeDirection)
            {
                case 1:
                    WORK_newCoordinate.COORDINATE_Y --;
                    break;
                case 2:
                    WORK_newCoordinate.COORDINATE_X --;
                    break;
                case 3:
                    WORK_newCoordinate.COORDINATE_X ++;
                    break;
                case 4:
                    WORK_newCoordinate.COORDINATE_Y ++;
                    break;
            }
            GAME_DATA_snakeLocation.Add(WORK_newCoordinate);
        }

        private int GAME_LOGIC_getUserDirectionInput()
        {
            // Directional Correspondance
            //          1
            //      2       3
            //          4
            //
            //      ~~ OR ~~
            //
            // -1 for exiting the game (Escape Key)
            // 0 for nonsense inputs

            ConsoleKeyInfo INPUT_userDirection = Console.ReadKey(false);
            if (INPUT_userDirection.Key == ConsoleKey.Escape)
            {
                return -1;
            }

            int OUTPUT = 0;
            switch (INPUT_userDirection.Key)
            {
                case ConsoleKey.UpArrow:
                    OUTPUT = 1;
                    break;
                case ConsoleKey.W:
                    OUTPUT = 1;
                    break;

                case ConsoleKey.LeftArrow:
                    OUTPUT = 2;
                    break;
                case ConsoleKey.A:
                    OUTPUT = 2;
                    break;

                case ConsoleKey.RightArrow:
                    OUTPUT = 3;
                    break;
                case ConsoleKey.D:
                    OUTPUT = 3;
                    break;

                case ConsoleKey.DownArrow:
                    OUTPUT = 4;
                    break;
                case ConsoleKey.S:
                    OUTPUT = 4;
                    break;
            }
            return OUTPUT;
        }

        private int GAME_LOGIC_checkSnakeLocation(GAME_LOGIC_COORDINATES INPUT_coordinate)
        {
            // Checks for outside boundary
            if (INPUT_coordinate.COORDINATE_X < 1 || INPUT_coordinate.COORDINATE_X > GAME_PROP_Width-1-1)
            {
                return  -1;
            }
            if (INPUT_coordinate.COORDINATE_Y < 1 || INPUT_coordinate.COORDINATE_Y > GAME_PROP_Height-1-1)
            {
                return -1;
            }

            // Checks for food location
            if (INPUT_coordinate.COORDINATE_X  == GAME_DATA_foodLocation.COORDINATE_X && INPUT_coordinate.COORDINATE_Y == GAME_DATA_foodLocation.COORDINATE_Y)
            {
                return  1;
            }

            // Checks for hitting snake body
            for (int i = 0; i < GAME_DATA_snakeLocation.Count() - 1; i++)
            {
                if (GAME_DATA_snakeLocation[i].COORDINATE_X == INPUT_coordinate.COORDINATE_X && GAME_DATA_snakeLocation[i].COORDINATE_Y == INPUT_coordinate.COORDINATE_Y)
                {
                    return -1;
                }
            }

            return 0;
        }

        private GAME_LOGIC_COORDINATES GAME_LOGIC_genFoodLocation()
        {
            GAME_LOGIC_COORDINATES OUTPUT = new GAME_LOGIC_COORDINATES();
            int WORK_randomX;
            int WORK_randomY;
            while (true)
            {
                WORK_randomX = GAME_PROP_randomGen.Next(1, GAME_PROP_Width - 1 - 1);
                WORK_randomY = GAME_PROP_randomGen.Next(1, GAME_PROP_Height - 1 - 1);
                OUTPUT.COORDINATE_X = WORK_randomX;
                OUTPUT.COORDINATE_Y = WORK_randomY;

                if (!GAME_DATA_snakeLocation.Contains(OUTPUT))
                {
                    break;
                }
            }
            return OUTPUT;
        }

        internal void DEBUG_printList(List<GAME_LOGIC_COORDINATES> INPUT_LIST)
        {
            foreach (GAME_LOGIC_COORDINATES coordinate in INPUT_LIST)
                coordinate.GAME_LOGIC_COORDINATE_print();
        }
    }
}