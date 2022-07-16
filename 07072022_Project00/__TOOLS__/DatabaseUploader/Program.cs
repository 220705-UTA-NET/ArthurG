using System;
using System.IO;
using System.Data.SqlClient;

namespace DatabaseUplodaer
{
    class Program 
    {
        static void Main(string[] args)
        {
            // All Possible Input File Paths            
                // @"./__INPUT__/Sorted_Words_04.txt"
                // @"./__INPUT__/Sorted_Words_Classic.txt"
                // @"./__INPUT__/Sorted_Words_06.txt"
                // @"./__INPUT__/Sorted_Words_07.txt"
                // @"./__INPUT__/Sorted_Words_08.txt"
                // @"./__INPUT__/Sorted_Words_ELSE.txt"

                // @"./__INPUT__/__TEST__.txt"

            string INPUT_filepath = @"./__INPUT__/Sorted_Words_Classic.txt";


            // Setting Up Connection and Command with Database
            string DB_connectionString = "";
            using SqlConnection DB_connection = new SqlConnection(DB_connectionString);

            DB_connection.Open();
            string WORK_DBInsert_TEXT = @"INSERT INTO Project00_Wordle.WordDB_Classic (Word) VALUES (@Word)";


            // Function Implementation
            using StreamReader INPUT_fileStream = new StreamReader(INPUT_filepath);
            {
                string WORK_fsLine;
                while ((WORK_fsLine = INPUT_fileStream.ReadLine()) != null)
                {
                    // TESTING - Try sample output commands -> console
                    // Console.WriteLine(WORK_fsLine.Substring(2));

                    using SqlCommand WORK_DBInsert = new SqlCommand(WORK_DBInsert_TEXT, DB_connection);
                    WORK_DBInsert.Parameters.AddWithValue("@Word", WORK_fsLine.Substring(2));

                    WORK_DBInsert.ExecuteNonQuery();
                }
            }

            DB_connection.Close();
        }
    }
}