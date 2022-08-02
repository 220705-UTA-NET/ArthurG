using System;

namespace Project01_Client.Logic
{
    internal class GAME_LOGIC_COORDINATES
    {
        // Fields
        internal int COORDINATE_X;
        internal int COORDINATE_Y;

        // Constructor
        internal GAME_LOGIC_COORDINATES() { }
        internal GAME_LOGIC_COORDINATES(int INPUT_X, int INPUT_Y)
        {
            this.COORDINATE_X = INPUT_X; 
            this.COORDINATE_Y = INPUT_Y;
        }

        // Methods
        internal void GAME_LOGIC_COORDINATE_print()
        {
            Console.WriteLine("\t" + COORDINATE_X + "," + COORDINATE_Y);
        }
    }
}
