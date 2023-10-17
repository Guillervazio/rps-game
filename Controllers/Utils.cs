using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
namespace paper_rock_scissors.Controllers
{
    public class Utils : Controller
    {
        //return the choice label
        public static string ChoiceLabel(int handNumber)
        {
            string label = string.Empty;
            switch (handNumber)
            {
                case 1:
                    label = "rock";
                    break;
                case 2:
                    label = "paper";
                    break;
                case 3:
                    label = "scissors";
                    break;
            }
            return label;
        }
        public static void GenerateStatistics(string result)
        {
            string path = GetGameFilePath();
            CreateDirectory();
            try
            {
               
                if (!System.IO.File.Exists(path))
                {
                    System.IO.File.Create(path).Dispose();

                    using (TextWriter tw = new StreamWriter(path))
                    {
                        tw.WriteLine(result);
                    }

                }
                else if (System.IO.File.Exists(path))
                {
                    System.IO.File.AppendAllText(path, result);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error trying to generate statistics file", e.ToString());
            }

        }
        public static void GetStatistics()
        {
            Console.WriteLine("\n-----Your statistics-----");
            Console.WriteLine("\n");
            string path = GetGameFilePath();
            try
            {
                if (System.IO.File.Exists(path))
                {
                    // Read all the content in one string 
                    // and display the string 
                    string str = System.IO.File.ReadAllText(path);
                    Console.WriteLine(str);
                }
                else
                {
                    Console.WriteLine("Game data not found. Go and play now!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error retrieving statistics", e.ToString());
            }
            Program.MainMenu();
        }
        public static void CreateDirectory()
        {
            string path = @"c:\RPS";

            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    // Try to create the directory.
                    DirectoryInfo di = Directory.CreateDirectory(path);
                    Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error trying to create game directory: {0}", e.ToString());
            }
        }
        public static string GetGameFilePath()
        {
            return @"C:\RPS\RockPaperScissors-Statistics.txt";
        }
    }
}
