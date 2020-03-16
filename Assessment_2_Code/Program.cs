using System;
using System.IO;
using System.Collections.Generic;

namespace Assessment_2_Code
{
    class Program
    {
        private static string[] FileReader(string file) // Method for fetching the chosen files from the directory. 
        {
            string[] txtArray = { }; // Initialise the array.
            string path = Directory.GetCurrentDirectory();
            txtArray = File.ReadAllLines(path.Substring(0, path.IndexOf("bin")) + (file + ".txt")); // Adds contents of file to an array by searching the directory until the "bin" folder is found, where the txt files should be.
            return txtArray; // If file choice input doesn't exist in the directory, the method will not return an array for use.
        }
        private static bool CompareFiles(string[] txt1, string[] txt2) // Method for comparing the two arrays.
        {
            int equalLines = 0;
            int notEqualLines = 0; // Initialising the number of equal and unqual lines.

            if (txt1.Length == txt2.Length) // Early check for if the lengths of the array are equal, before checking individual lines.
            {
                for(int i = 0; i < txt1.Length && i < txt2.Length; i++) // Loop through the lines of the arrays from 0 to the end of either array length.
                {
                    if(txt1[i] != txt2[i]) // Check for each line to be equal or not.
                    {
                        notEqualLines++;
                    }
                    else { equalLines++; }
                }
                if(notEqualLines == 0) // If true then the files are the same.
                {
                    return true;
                }
                else { return false;  }
            }
            else { return false; }
        }
        static void Main(string[] args)
        {
            string[] txt1 = { };
            string[] txt2 = { };
            string fileChoice1 = "";
            string fileChoice2 = ""; // Initialise the two arrays and file choices.

            while (true) // Error handling if the file choice doesn't exist in the directory, loops until a valid file name is inputted.
            {
                Console.Write("Enter File Choice 1: ");
                try 
                {
                    fileChoice1 = Console.ReadLine();
                    txt1 = FileReader(fileChoice1); // Fetches user input and calls file reader method with the 1st file choice as the argument given.
                    break;
                }
                catch (Exception) // Occurs if the file reader method fails.
                {
                    Console.WriteLine("This File Does Not Exist In This Directory");
                }                
            }

            while (true)
            {
                Console.Write("Enter File Choice 2: ");
                try
                {
                    fileChoice2 = Console.ReadLine();
                    txt2 = FileReader(fileChoice2);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("This File Does Not Exist In This Directory");
                }
            }

            bool result = CompareFiles(txt1, txt2); // Calls comparing method with the two chosen files as arguments.
            if(result == true)
            {
                Console.WriteLine($"{fileChoice1}.txt And {fileChoice2}.txt Are Not Different");
            }
            else { Console.WriteLine($"{fileChoice1}.txt And {fileChoice2}.txt Are Different"); }
        }
    }
}
