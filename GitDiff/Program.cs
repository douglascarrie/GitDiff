using System;
using System.IO;
namespace GitDiff
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please Enter A Git Command:");
			// User input
            string input = Console.ReadLine();    
			// Remove white spaces
            input = input.Trim();
			// if the input doesnt start with diff, then enter new command
            while (!input.StartsWith("diff"))
            {
                Console.WriteLine("Could not read command! Try again:");
                input = Console.ReadLine();
                input = input.Trim();
            }
			// Removes the diff word from input string
            input = input.Remove(0, 5);

          
			// Array of the two user entered text file names
            string[] files = input.Split(" ", 2);



            // if both files exist
            if (ExceptionIO(files[0], files[1]) == true)
            {
                string file1 = File.ReadAllText(files[0]);
                string file2 = File.ReadAllText(files[1]);
                // if files are the same
                if (file1 == file2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Files are the same");
                    Console.ResetColor();
                }
                // files not the same
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Files are differnt");
                    Console.ResetColor();

                }
            }
            // The files don't exist
            else { Console.WriteLine("Could not find files!"); }

        }

        /// <summary>
        /// Checks whether files exist
        /// </summary>
        /// <param name="file1">First file being checked</param>
        /// <param name="file2">Second file being checked</param>
        /// <returns></returns>
        public static bool ExceptionIO(string file1, string file2)
        {

            try
            {
                File.ReadAllText(file1);
                File.ReadAllText(file2);
                return true;
                
            }
            catch                                                   
            {
                return false;
            }

        }
    }
}
