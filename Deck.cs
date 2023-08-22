using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using DeckInstructions_NS;

using Card_NS;
using OrganCard_NS;
using VirusCard_NS;
using MedCard_NS;
using DoctorCard_NS;

using Constants_NS;
using Rules_NS;
using CardEnums_NS;

namespace Deck_NS;

internal class Deck
{
    private List<Card> Cards { get; set; }
    internal Deck() // GPT-4 Implementation
    {
        Cards = new List<Card>();
        AddCards<CardEnums.SubCategory>(CardEnums.Category.Organ, Rules.OrganCardsAmounts, (subCat) => new OrganCard(CardEnums.Category.Organ, subCat));
        AddCards<CardEnums.SubCategory>(CardEnums.Category.Virus, Rules.VirusCardsAmounts, (subCat) => new VirusCard(CardEnums.Category.Virus, subCat));
        AddCards<CardEnums.SubCategory>(CardEnums.Category.Med, Rules.MedCardsAmounts, (subCat) => new MedCard(CardEnums.Category.Med, subCat));

        // Add Doctor cards (unique case)
        foreach (CardEnums.SubDocCategory subDocCategory in Enum.GetValues(typeof(CardEnums.SubDocCategory)))
        {
            for (int i = 0; i < Rules.DoctorCardsAmounts[(int)subDocCategory]; i++)
            {
                Cards.Add(new DoctorCard(CardEnums.Category.Doctor, subDocCategory));
            }
        }

        Console.WriteLine("[GameInfo]: A Deck with (" + Cards.Count + ") Cards, was generated.");
        Console.WriteLine();
    }

    private void AddCards<TEnum>(CardEnums.Category category, int[] amounts, Func<TEnum, Card> cardFactory)
        where TEnum : Enum
    {
        foreach (TEnum subCategory in Enum.GetValues(typeof(TEnum)))
        {
            for (int i = 0; i < amounts[Convert.ToInt32(subCategory)]; i++)
            {
                Card card = cardFactory(subCategory);
                Cards.Add(card);
            }
        }
    }
    /*
    internal Deck() // Simpler Version
    {
        // Create the Deck based on the "Rules.cs"
        // throw new NotImplementedException(Constants.ErrorMessages.NotImplemeted("Deck", "Constructor"));
        Cards = new List<Card>();

        // Add Organ cards
        //      X     in   [ Heart, Stomach, Brain, Bone, Special ] 
        foreach (CardEnums.SubCategory subCategory in Enum.GetValues(typeof(CardEnums.SubCategory)))
        {
            The 'X' holds the Index of the Array containing the Amount value for each Card
            for (int i = 0; i < Rules.OrganCardsAmounts[(int)subCategory]; i++)
            {
                Cards.Add(new OrganCard(CardEnums.Category.Organ, subCategory));
            }
        }

        // Add Virus cards
        foreach (CardEnums.SubCategory subCategory in Enum.GetValues(typeof(CardEnums.SubCategory)))
        {
            for (int i = 0; i < Rules.VirusCardsAmounts[(int)subCategory]; i++)
            {
                Cards.Add(new VirusCard(CardEnums.Category.Virus, subCategory));
            }
        }

        // Add Med cards
        foreach (CardEnums.SubCategory subCategory in Enum.GetValues(typeof(CardEnums.SubCategory)))
        {
            for (int i = 0; i < Rules.MedCardsAmounts[(int)subCategory]; i++)
            {
                Cards.Add(new MedCard(CardEnums.Category.Med, subCategory));
            }
        }

        // Add Doctor cards
        foreach (CardEnums.SubDocCategory subDocCategory in Enum.GetValues(typeof(CardEnums.SubDocCategory)))
        {
            for (int i = 0; i < Rules.DoctorCardsAmounts[(int)subDocCategory]; i++)
            {
                Cards.Add(new DoctorCard(CardEnums.Category.Doctor, subDocCategory));
            }
        }

        Console.WriteLine("[GameInfo]: A Deck with (" + Cards.Count + ") Cards, was generated.");
        Console.WriteLine();

    }
    */

    public List<Card> Draw(int _amount)
    {
        // Check if there are enough cards to draw
        if (_amount > Cards.Count)
        {
            throw new InvalidOperationException("Not enough cards to draw!");
        }

        // Take the specified number of cards from the top of the deck
        var drawnCards = Cards.GetRange(0, _amount);

        // Remove the drawn cards from the deck
        Cards.RemoveRange(0, _amount);

        return drawnCards;
    }
}
