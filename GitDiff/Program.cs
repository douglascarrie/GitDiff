using System;
using System.IO;
namespace GitDiff
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Please Enter A Git Command:");
            string input = Console.ReadLine();                            
            input = input.Trim();
            while (!input.StartsWith("diff"))
            {
                Console.WriteLine("Could not read command! Try again:");
                input = Console.ReadLine();
                input = input.Trim();
            }
            input = input.Remove(0, 5);

            //Console.WriteLine(input);

            string[] files = input.Split(" ", 2);




            if (ExceptionIO(files[0], files[1]) == true)
            {
                string file1 = File.ReadAllText(files[0]);
                string file2 = File.ReadAllText(files[1]);
                if (file1 == file2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Files are the same");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Files are differnt");
                    Console.ResetColor();

                }
            }
            else { Console.WriteLine("Could not find files!"); }

        }

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
