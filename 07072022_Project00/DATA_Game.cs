// Class to communicate with database regarding game functions.

using System;
using System.Data.SqlClient;

namespace Project_00
{
    class DATA_Game
    {
        // Fields
        private readonly string DB_PROP_connectionString;
        private static readonly string DB_COMMAND_validInput = @"SELECT TOP 1 (ID) FROM Project00_Wordle.WordDB_Classic WHERE Word = @INPUT_WORD;";
        private static readonly string DB_COMMAND_randWord = @"SELECT TOP 1 (Word) FROM Project00_Wordle.WordDB_Classic ORDER BY NEWID();";
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

        public string DATA_Game_randWord()
        {
            string OUTPUT_word = "";
            using SqlConnection DB_connection = new SqlConnection(this.DB_PROP_connectionString);
            DB_connection.Open();
            
            using SqlCommand DB_generateRandWord = new SqlCommand(DB_COMMAND_randWord, DB_connection);
            using SqlDataReader DB_reader = DB_generateRandWord.ExecuteReader();

            if (DB_reader.Read())
            {
                OUTPUT_word = DB_reader.GetString(0);
            }

            DB_connection.Close();
            return OUTPUT_word;
        }
    }
}