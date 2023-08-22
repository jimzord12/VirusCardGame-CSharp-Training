using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Deck_NS;
using OrganCard_NS;
using Card_NS;
using Helpers_NS;
using Rules_NS;
using CardEnums_NS;
using System.ComponentModel;
using VirusCard_NS;
using MedCard_NS;
using DoctorCard_NS;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Player_NS
{
    internal class Player
    {
        public Deck deckRef;
        public Player[] otherPlayersRef;
        public string Name { get; init; }
        public int ID { get; init; }
        public List<OrganCard> Body { get; set; } = new List<OrganCard>();
        public List<Card> Hand { get; set; }

        public Player(Deck _deck, string _name, int _id)
        {
            deckRef = _deck;
            Name = _name;
            ID = _id;

            Draw(Rules.StartingCards);
        }
        public void Draw(int _amount)
        {
            Hand = deckRef.Draw(_amount);
        }
        public void Draw()
        {
            Hand = deckRef.Draw(1);
        }

        public void Act()
        {
            // 1. Show the Player his/her Cards from Hand
            DisplayHand(this);

            // 2. Get Player's Action
            Console.WriteLine("You can perform the following actions:");
            Console.WriteLine("1 - Discard a Card and get a New one");
            Console.WriteLine("2 - Play a Card from your Hand");
            uint choice = Helpers.GetUintInput(1, 2);

            // 3. Based on Player Input Perform Action
            if (choice == 1) { Discard(); } 
            else { PlayCard(); }
        }

        // - Private Methods -
        private void Discard()
        {
            Card selectedCard = SelectCard(); // Get Player's Card Selection
            Hand.Remove(selectedCard); // Remove It
            // Draw(Rules.MaxCardsInHand - Hand.Count); 
            Draw(); // Grab a new One

        }
        private void PlayCard()
        {
            Card selectedCard = SelectCard();
            switch (selectedCard.Category)
            {
                case CardEnums.Category.Organ:

                    if (HasOrganAlready((OrganCard)selectedCard)) break;
                    Body.Add((OrganCard)selectedCard);
                    Hand.Remove(selectedCard);
                    break;

                case CardEnums.Category.Virus:
                    // DisplayOtherPlayerBodies();
                    break;

                case CardEnums.Category.Med:

                    break;

                case CardEnums.Category.Doctor:

                    break;

                default:
                    throw new Exception("Game Error: 0001");
            }
        }

        private void SeeOtherPlayerBodies()
        {
            foreach (var player in otherPlayersRef)
            {
                if (player.Name == Name) continue;
                DisplayHand(player);
            }
        }

        private Card SelectCard()
        {
            Console.WriteLine("Select a Card by Entering its Number");
            int choice = (int)Helpers.GetUintInput(1, 3);
            return Hand[choice - 1];
        }

        private void DisplayHand(Player player)
        {
            // Render the Cards with ASCII Art
            // 1. Retrieve Player's Cards in Hand
            foreach (var card in player.Hand)
            {
                switch (card)
                {
                    case OrganCard organCard:
                        DrawCardFrame(organCard, organCard.SubCategory);
                        break;

                    case VirusCard virusCard:
                        DrawCardFrame(virusCard, virusCard.SubCategory);
                        break;

                    case MedCard medCard:
                        DrawCardFrame(medCard, medCard.SubCategory);
                        break;

                    case DoctorCard doctorCard:
                        DrawCardFrame(doctorCard, doctorCard.SubDocCategory);
                        break;

                    default:
                        throw new Exception("Game Error: 0003");
                }
            }
        }

        private bool HasOrganAlready(OrganCard _organ)
        {
            if (Body.Count == 0) return false;

            bool result = false;

            foreach (var cardFromHand in Body)
            {
                // If, even once, the Same Organ Exists. Returns true
                if (cardFromHand.Category == _organ.Category)
                    result = true;
            }
            return result;
        }

        private void DrawCardFrame(Card card, CardEnums.SubCategory subcat)
        {
            int titleSize = card.Name == null ? 0 : card.Name.Length;
            int categorySize = card.Category.ToString().Length;
            int subCategorySize = subcat.ToString().Length;
            int[] numbers = new int[3] { titleSize, categorySize, subCategorySize };

            Console.WriteLine();
            Console.WriteLine("+" + RepeatChar('-', numbers.Max()) + "+");
            Console.WriteLine($"|                   |");
            Console.WriteLine("+\" + RepeatChar('-', numbers.Max()) + \"+");
        }

        private static void DrawCardFrame(Card card, CardEnums.SubDocCategory subcat)
        {
            int titleSize = card.Name == null ? 0 : card.Name.Length;
            int categorySize = card.Category.ToString().Length;
            int subCategorySize = subcat.ToString().Length;
            int[] numbers = new int[3] { titleSize , categorySize , subCategorySize };
            int maxLineLength = numbers.Max();



            Console.WriteLine();
            Console.WriteLine("+" + RepeatChar('-', maxLineLength) + "+");
            Console.WriteLine("|" + CenterInMiddle(maxLineLength, card.Name ?? "XXXXX") + "|");
            Console.WriteLine("|" + CenterInMiddle(maxLineLength, card.Category.ToString() ?? "XXXXX") + "|");
            Console.WriteLine("|" + CenterInMiddle(maxLineLength, subcat.ToString() ?? "XXXXX") + "|");
            Console.WriteLine("+" + RepeatChar('-', maxLineLength) + "+");
        }
        private static string RepeatChar(char characterToRepeat, int numberOfRepeats)
        {
            return new string(characterToRepeat, numberOfRepeats);
        }
        private static (int totalPadding, int leftPadding, int rightPadding) CalcPadding(int maxLineLength, int dataLength)
        {
            int totalPadding = maxLineLength - dataLength;
            int leftPadding = totalPadding / 2;
            int rightPadding = totalPadding - leftPadding;

            return (totalPadding, leftPadding, rightPadding);
        }

        private static string CenterInMiddle(int maxLineLength, string data)
        {
            (int totalPadding, int leftPadding, int rightPadding) = CalcPadding(maxLineLength, data.Length);
            return RepeatChar(' ', leftPadding) + data + RepeatChar(' ', rightPadding);
        }

    }
}
