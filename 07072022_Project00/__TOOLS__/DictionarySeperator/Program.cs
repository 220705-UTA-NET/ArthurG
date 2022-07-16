using System;
using System.IO;

namespace DictionarySeperator
{
    class Program 
    {
        static void Main(string[] args)
        {
            string INPUT_filepath = @"./__INPUT__/words_alpha.txt";

            //Creates all needed output files
            string OUTPUT_filepath_word04 = @"./__OUTPUT__/Sorted_Words_04.txt";
            string OUTPUT_filepath_word05 = @"./__OUTPUT__/Sorted_Words_Classic.txt";
            string OUTPUT_filepath_word06 = @"./__OUTPUT__/Sorted_Words_06.txt";
            string OUTPUT_filepath_word07 = @"./__OUTPUT__/Sorted_Words_07.txt";
            string OUTPUT_filepath_word08 = @"./__OUTPUT__/Sorted_Words_08.txt";
            string OUTPUT_filepath_wordELSE = @"./__OUTPUT__/Sorted_Words_ELSE.txt";

            File.Create(OUTPUT_filepath_word04).Dispose();
            File.Create(OUTPUT_filepath_word05).Dispose();
            File.Create(OUTPUT_filepath_word06).Dispose();
            File.Create(OUTPUT_filepath_word07).Dispose();
            File.Create(OUTPUT_filepath_word08).Dispose();
            File.Create(OUTPUT_filepath_wordELSE).Dispose();
            
            
            // Sorts the words to the corresponding files
            using StreamReader INPUT_fileStream = new StreamReader(INPUT_filepath);
            {
                string WORK_fsLine;
                while ((WORK_fsLine = INPUT_fileStream.ReadLine()) != null)
                {
                    // TESTING - Try word dictionary commands -> console
                    // Console.WriteLine(WORK_fsLine.Length + " - " + WORK_fsLine);


                    // Check Length of Word for Sorting
                    string OUTPUT_filepath_current = "";
                    switch (WORK_fsLine.Length)
                    {
                        case 4:
                            OUTPUT_filepath_current = OUTPUT_filepath_word04;
                            break;
                        case 5:
                            OUTPUT_filepath_current = OUTPUT_filepath_word05;
                            break;
                        case 6:
                            OUTPUT_filepath_current = OUTPUT_filepath_word06;
                            break;
                        case 7:
                            OUTPUT_filepath_current = OUTPUT_filepath_word07;
                            break;
                        case 8:
                            OUTPUT_filepath_current = OUTPUT_filepath_word08;
                            break;
                        default:
                            OUTPUT_filepath_current = OUTPUT_filepath_wordELSE;
                            break;
                    }
                    

                    // Writes to corresponding file
                    using (StreamWriter OUTPUT_fs = File.AppendText(OUTPUT_filepath_current))
                    {
                        OUTPUT_fs.WriteLine(WORK_fsLine.Length + "," + WORK_fsLine);
                    }

                }
            }

        }
    }
}