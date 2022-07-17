// Class used to display the ingame grid.

using System;

namespace Project_00
{
    public class GUI_Game
    {
        // Fields

        // Constructor

        //  Methods
        public void GUI_PrintGameGrid(List<string> INPUT_wordList)
        {
            int WORK_numColumns = INPUT_wordList[0].Length;
            for (int i = 0 ; i < INPUT_wordList.Count ; i++)
            {
                GUI_GAME_PrintHorizontal(WORK_numColumns);
                GUI_GAME_PrintVertial(WORK_numColumns, INPUT_wordList[i]);
            }
            GUI_GAME_PrintHorizontal(WORK_numColumns);
        }

        void GUI_GAME_PrintHorizontal(int INPUT_numColumns)
        {
            Console.WriteLine("+" + string.Concat(Enumerable.Repeat("-------+", INPUT_numColumns)));
        }
        void GUI_GAME_PrintVertial(int INPUT_numRows, string INPUT_currentWord)
        {
            Console.WriteLine("|" + string.Concat(Enumerable.Repeat("       |", INPUT_numRows)));
            Console.Write("|");
            for (int i = 0 ; i < INPUT_numRows ; i++)
            {
                Console.Write("   " + INPUT_currentWord[i] + "   |");
            }
            Console.Write("\n");
            Console.WriteLine("|" + string.Concat(Enumerable.Repeat("       |", INPUT_numRows)));
        }
    }
}