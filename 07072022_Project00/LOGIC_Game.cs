// Class used to control the logic of game (Wordle) for classic (5x6 grid)

using System;
using System.IO;
using System.Text;

namespace Project_00
{
    class LOGIC_Game
    {
        // Fields
        private int GAME_PROP_numWordLength;
        private int GAME_PROP_numGuesses;
        private string GAME_PROP_blankGuess;
        private string GAME_DATA_correctWord  = "";
        private List<string> GAME_DATA_wordList = new List<string>{};

        // Constructors
        public LOGIC_Game(int INPUT_numWordLength, int INPUT_numGuesses)
        {
            this.GAME_PROP_numWordLength = INPUT_numWordLength;
            this.GAME_PROP_numGuesses = INPUT_numGuesses;
            this.GAME_PROP_blankGuess = string.Concat(Enumerable.Repeat(" ", INPUT_numWordLength));
            
            DATA_Game GEN_randWord = new DATA_Game();
            this.GAME_DATA_correctWord = GEN_randWord.DATA_Game_randWord();

            for (int i = 0 ; i < INPUT_numGuesses ; i++)
            {
                GAME_DATA_wordList.Add(GAME_PROP_blankGuess);
            }
        }

            // Constructor for testing, has argument to input correct word
        // public LOGIC_Game(int INPUT_numWordLength, int INPUT_numGuesses, string INPUT_randWord)
        // {
        //     this.GAME_PROP_numWordLength = INPUT_numWordLength;
        //     this.GAME_PROP_numGuesses = INPUT_numGuesses;
        //     this.GAME_PROP_blankGuess = string.Concat(Enumerable.Repeat(" ", INPUT_numWordLength));
        //     this.GAME_DATA_correctWord = INPUT_randWord;

        //     for (int i = 0 ; i < INPUT_numGuesses ; i++)
        //     {
        //         GAME_DATA_wordList.Add(GAME_PROP_blankGuess);
        //     }
        // }
    
        // Methods

        public void LOGIC_GAME_MAIN()
        {
            int COUNTER_numGuesses = 0;
            bool FLAG_wonGame = false;
            
            DateTime WORK_TimerPrior = DateTime.Now;
            GUI_Game GAME_Display = new GUI_Game();
            for (int i = 0 ; i < GAME_PROP_numGuesses ; i++)
            {
                Console.Clear();
                GAME_Display.GUI_PrintGameGrid(GAME_DATA_wordList);
                
                COUNTER_numGuesses++;

                string INPUT_userWord = LOGIC_GAME_getValidGuess();
                string WORK_userWord = LOGIC_GAME_capCorrectChars(INPUT_userWord);
                GAME_DATA_wordList[i] = WORK_userWord;   

                if(INPUT_userWord == "quit")
                {
                    break;
                }
                if(INPUT_userWord == GAME_DATA_correctWord)
                {
                    FLAG_wonGame = true;
                    break;
                }        
            }
            DateTime WORK_TimerPost = DateTime.Now;
            int WORK_usedTime = (WORK_TimerPost - WORK_TimerPrior).Seconds;

            Console.Clear();

            GAME_Display.GUI_PrintGameGrid(GAME_DATA_wordList);


            Console.WriteLine();
            Console.WriteLine();
            if (FLAG_wonGame == true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("   !! CONGRATULATIONS !!");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine("   Nice attempt, please try again.");
            }            

            Console.WriteLine("\nGame Stats: ");
            Console.WriteLine("\tCorrect Word: " + GAME_DATA_correctWord);
            Console.WriteLine("\tNumber of Guesses: " + COUNTER_numGuesses);    
            Console.WriteLine("\tTime Used: " + WORK_usedTime + " sec");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press anything to continue");
            Console.ReadKey();
        }

        private string LOGIC_GAME_getValidGuess()
        {
            string OUTPUT_Guess = "";
            bool FLAG_hasValidGuess = false;

            DATA_Game DB_currentWord = new DATA_Game();
            
            while (FLAG_hasValidGuess == false)
            {
                string? INPUT_userWord = "";
                Console.WriteLine(@"Please enter a word or type ""quit"" to exit: ");
                INPUT_userWord = Console.ReadLine();
                INPUT_userWord.ToLower();

                if (INPUT_userWord == "debug_showcorrectword")
                {
                    Console.WriteLine(GAME_DATA_correctWord);
                }
                else if (INPUT_userWord == "quit")
                {
                    OUTPUT_Guess = INPUT_userWord;
                    FLAG_hasValidGuess = true;
                }
                else if (INPUT_userWord.Length < this.GAME_PROP_numWordLength)
                {
                    Console.WriteLine(" ~ Sorry, inputed word is too short, please try again.");
                }
                else if (INPUT_userWord.Length > this.GAME_PROP_numWordLength)
                {
                    Console.WriteLine(" ~ Sorry, inputed word is too long, please try again.");  
                }
                else if (DB_currentWord.DATA_GAME_checkValidChoice(INPUT_userWord) == false)
                {
                    Console.WriteLine(" ~ Sorry, inputed word does not exist, please try again.");
                }
                else
                {
                    OUTPUT_Guess = INPUT_userWord;
                    FLAG_hasValidGuess = true;
                }
            }

            return OUTPUT_Guess;
        }

        public string LOGIC_GAME_capCorrectChars(string INPUT_word)
        {
            StringBuilder WORK_userWord = new StringBuilder(INPUT_word);

            for(int j = 0 ; j < this.GAME_DATA_correctWord.Length ; j++)
            {
                if (WORK_userWord[j] == GAME_DATA_correctWord[j])
                {
                    WORK_userWord[j] = char.ToUpper(WORK_userWord[j]);
                }
            }

            string OUTPUT_word = WORK_userWord.ToString();
            return OUTPUT_word;
        }
    }
}