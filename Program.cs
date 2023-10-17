using System;
using System.IO;

namespace paper_rock_scissors
{
    public class Program : Controllers.Utils
    {
        static void Main(string[] args)
        {
            MainMenu();
        }
        public static void MainMenu()
        {
            Console.WriteLine("\n-----Welcome to Rock*Paper*Scissors Battle!!-----");
            Console.WriteLine("\n1) Start Game");
            Console.WriteLine("2) Statistics");
            Console.WriteLine("3) Exit");
            string option = Console.ReadLine();
            Int32.TryParse(option, out int optionNumber);
            if (optionNumber.Equals(1) || optionNumber.Equals(2) || optionNumber.Equals(3))
            {
                switch (optionNumber)
                {
                    case 1:
                        Console.Clear();
                        StartGame();
                        break;

                    case 2:
                        Console.Clear();
                        GetStatistics();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public static void StartGame()
        {
            bool keepPlaying = false;
            Random random = new Random();
            int cpuHand;
            do
            {
                Console.WriteLine("\n-----Choose your weapon!-----");
                Console.WriteLine("\n1) Rock");
                Console.WriteLine("2) Paper");
                Console.WriteLine("3) Scissors");
                string userHand = Console.ReadLine();
                Int32.TryParse(userHand, out int userHandNumber);
                cpuHand = random.Next(1, 3);
                if (userHandNumber.Equals(1) || userHandNumber.Equals(2) || userHandNumber.Equals(3))
                {
                    Console.WriteLine($"\nYou chose {ChoiceLabel(userHandNumber)}...");
                    Console.WriteLine($"CPU chose {ChoiceLabel(cpuHand)}...");
                    switch (cpuHand)
                    {
                        case 1:
                            Result(userHandNumber, cpuHand);
                            break;

                        case 2:
                            Result(userHandNumber, cpuHand);
                            break;

                        case 3:
                            Result(userHandNumber, cpuHand);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\nInvalid Input !!! please enter valid input, 1 = rock. 2 = paper. 3 = scissors");
                }
                Console.WriteLine("\nDo you  want to continue? y/n");
                var isContinue = Console.ReadKey();
                //Console.();
                keepPlaying = isContinue.Key.ToString().ToLower() == "y";
            } while (keepPlaying);
            Console.Clear();
            MainMenu();

        }
        public static void Result(int userHand, int cpuHand)
        {
            try
            {   //the logic behind this calculation is that we set static number values for each choice
                //rock value = 1, paper value = 2, scissor value = 3
                //we subtract between both values (user and cpu choices) knowing that the left side of the subtraction is user choice and the right side cpu choice
                //Ej: user chose "rock" that its value is 1 and cpu chose "paper" that its value is 2. Result: 1(rock) - 2(paper) = -1, that means user lost ()
                int dif = (userHand - cpuHand);
                string result = string.Empty;
                if (dif.Equals(-1) || dif.Equals(2))//when user lose
                    result = "you lost!";
                if (dif.Equals(1) || dif.Equals(-2))//when user win
                    result = "you won!";
                if (dif.Equals(0))//when tie
                    result = "it's a tie!";
                //summary for statistics
                string summary = $"\nyou({ChoiceLabel(userHand)}) vs CPU({ChoiceLabel(cpuHand)}) - {result}";
                GenerateStatistics(summary);
                Console.WriteLine(result);

            }
            catch (Exception e)
            {
                Console.WriteLine("There was an error in game result: {0}", e.ToString());
            }

        }
    }
}
//////RESULT MATRIX///////
//---------------------------------------------------
//user choice    (-)  cpu choice  (=) Result | winner
//---------------------------------------------------
// 1 (rock)       -   1(rock)      =   0     |   tie
// 1 (rock)       -   2(paper)     =  -1     |   cpu
// 1 (rock)       -   3(scissors)  =  -2     |   user
// 2 (paper)      -   1(rock)      =   1     |   user
// 2 (paper)      -   2(paper)     =   0     |   tie
// 2 (paper)      -   3(scissors)  =  -1     |   cpu
// 3 (scissors)   -   1(rock)      =   2     |   cpu
// 3 (scissors)   -   2(paper)     =   1     |   user
// 3 (scissors)   -   3(scissors)  =   0     |   tie