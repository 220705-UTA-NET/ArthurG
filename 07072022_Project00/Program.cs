using System;
using System.Text;

namespace Project_00
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wordle");
            LOGIC_Game gameSession = new LOGIC_Game(5,6);
            gameSession.LOGIC_GAME_MAIN();
            
            // gameSession.LOGIC_GAME_MAIN();
            //Console.WriteLine(gameSession.LOGIC_GAME_getValidGuess());

            DATA_Game Database_Validation = new DATA_Game();
            // Console.WriteLine(Database_Validation.DATA_GAME_checkValidChoice("abbey"));
            // Console.WriteLine(Database_Validation.DATA_GAME_checkValidChoice("tree"));
            // Console.WriteLine(Database_Validation.DATA_Game_randWord());
            // Console.WriteLine(Database_Validation.DATA_Game_randWord());
            // Console.WriteLine(Database_Validation.DATA_Game_randWord());
        }
    }
}