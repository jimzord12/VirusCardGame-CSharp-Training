using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Deck_NS;
using Player_NS;

using Card_NS;
using OrganCard_NS;
using VirusCard_NS;
using MedCard_NS;
using DoctorCard_NS;

namespace Game_NS
{
    internal class Game
    {
        public Player[] Players { get; set; }
        public Deck Deck { get; set; }
        public Player? Winner { get; set; }

        public Game(uint _playerNum)
        {
            try
            {
                Deck = new Deck();
                Players = CreatePlayers(_playerNum, Deck);
                foreach (var player in Players)
                {
                    player.otherPlayersRef = Players;
                }
            }
            catch (NotImplementedException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            
        }

        private static Player[] CreatePlayers(uint _playerNum, Deck _deck)
        {
            Player[] temp = new Player[_playerNum];
            for (int i = 0; i < _playerNum; i++)
            {
                Console.WriteLine($" | Please enter a name for (Player #{i + 1}) |");
                Console.WriteLine(" | > Note: If you Do NOT provide a (Name) a default will be assigned <|");
                string name = Console.ReadLine() ?? "Player-" + (i + 1);
                temp[i] = new Player(_deck, name, i+1);
            }
            
            return temp;
        }

        public void NextRound()
        {
            try
            {
                Console.WriteLine("|> NextRound is Called");
                throw new NotImplementedException("\n[Yoda]:\n- You such an idiot are! \n" +
                "- Forgot you have, implement you must: \nGame -> NextRound()"); ;
            }
            catch (NotImplementedException e)
            {
                if (e.Message == "Not enough cards to draw!")
                {
                    Console.WriteLine("It Appears that there are no Cards left in the Deck...");
                    Console.WriteLine("No Worries! A new fresh one is being generated.");

                    Deck = new Deck();

                    // Updating the Player's Deck Reference, from the Old one to the New one.
                    foreach (var player in Players)
                    {
                        player.deckRef = Deck; // Updating the reference in each player
                    }

                } else
                {
                    throw;
                }
            }
            catch (Exception e)
            {
                if (e.Message.Contains("0001"))
                {
                    Console.WriteLine("Error at: Player.cs > PlayCard() \n Message: Something Went Wrong");
                }
            }
        }

        public bool HasEnded()
        {
            throw new NotImplementedException("You such an Idiot you are! \n " +
                "Forgot you have, to Implement: Game -> HasEnded()");
        }
    }
}
