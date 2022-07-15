using System;
using System.IO;

namespace DictionarySeperator
{
    class Program 
    {
        static void Main(string[] args)
        {
            string INPUT_file = @"./__INPUT__/words_alpha.txt";
            
            using StreamReader INPUT_fileStream = new StreamReader(INPUT_file);
            {
                string WORK_fsLine;
                while ((WORK_fsLine = INPUT_fileStream.ReadLine()) != null)
                {
                    Console.WriteLine(WORK_fsLine.Length + " - " + WORK_fsLine);
                }
            }
        }
    }
}