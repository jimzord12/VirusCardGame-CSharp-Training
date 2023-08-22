using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Helpers_NS;

using Game_NS;
using Player_NS;


namespace GameRunner_NS
{
    internal static class GameRunner
    {
        public static Dictionary<string, Player[]> Leaderboard { get; set; }
        private static Game CurrentGame { get; set; }

       public static void StartGame()
        {
            Console.WriteLine("****************************");
            Console.WriteLine("***  GameRunner Started  ***");
            Console.WriteLine("****************************");


            // 1. Display Instructions

            // 2. How many players will be participating
            Console.Write("Please Enter the Number of Patients: ");
            uint playerNum = Helpers.GetUintInput();
            Console.WriteLine();
            Console.WriteLine();
            // 3. Create a new Game instace
            CurrentGame = new Game(playerNum);
            // 4. Run the Game Loop
            do
            {
                try
                {
                    CurrentGame.NextRound();
                }
                catch (NotImplementedException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                    Console.WriteLine("My Eyes are getting Heavy... Is this the End?!");
                    Console.WriteLine();
                    Environment.Exit(0);
                }
                catch (Exception)
                {

                    throw;
                }
                 } while (!CurrentGame.HasEnded());

            Console.WriteLine($"The Winner is: {CurrentGame.Winner}");
            Console.WriteLine();
            Console.WriteLine("Would Like to start a New Game?");
            Console.WriteLine("Write: (Yes) and Pressed Enter for another one!");
            
            string answer = Console.ReadLine() ?? "No";
            if(answer == "(Yes)" || answer == "Yes" || answer == "yes" || answer == "y") StartGame();
        }

        static void SaveGameResults() /* NOT Implemented Yet */
        {
            // TODO!
            throw new NotImplementedException("\n[Yoda]:\n- You such an idiot are! \n" +
"- Forgot you have, implement you must: \nGameRunner -> SaveGameResults()"); ;
        }
    }
}
