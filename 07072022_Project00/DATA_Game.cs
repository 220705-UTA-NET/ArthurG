using System;
using System.Data.SqlClient;

namespace Project_00
{
    class DATA_Game
    {
        // Fields
        private readonly string DB_PROP_connectionString;
        private static readonly string DB_COMMAND_validInput = "SELECT TOP 1 (ID) FROM Project00_Wordle.WordDB_Classic WHERE Word = @INPUT_WORD;";
        // Constructor
        public DATA_Game()
        {
            string PATH_connectionString = @"./../../connectionString.txt";
            DB_PROP_connectionString = File.ReadAllText(PATH_connectionString);

            // Console.WriteLine(DB_PROP_connectionString);
        }

        // Methods

        public bool DATA_GAME_checkValidChoice(string INPUT_word)
        {
            using SqlConnection DB_connection = new SqlConnection(this.DB_PROP_connectionString);
            DB_connection.Open();
            
            using SqlCommand DB_CheckInput = new SqlCommand(DB_COMMAND_validInput, DB_connection);
            DB_CheckInput.Parameters.AddWithValue("@INPUT_WORD", INPUT_word);

            if(DB_CheckInput.ExecuteScalar() == null)
            {
                DB_connection.Close();
                return false;
            }
            else
            {
                DB_connection.Close();
                return true;
            }
        }

    }
}