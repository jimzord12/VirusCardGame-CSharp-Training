using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Helpers_NS;
using CardEnums_NS;

namespace DeckInstructions_NS
{
    internal class DeckInstructions
    {
        static public int[] organs = new int[5] { 4, 4, 4, 4, 1 };
        static public int[] viruses = new int[5] { 3, 3, 3, 3, 1 };
        static public int[] meds = new int[5] { 4, 4, 4, 4, 4 };
        static public int[] doctors = new int[5] { 2, 2, 2, 2, 1 };

        static public void GetInfo()
        {
            DisplayOptions();
            bool repeatSelection;
            do
            {
                repeatSelection = false;
                uint choice = Helpers.GetUintInput();

                switch (choice)
                {
                    case (uint)CardEnums.Category.Organ:
                        Console.WriteLine($"[1]: Type: Heart | Amount: {organs[0]} \n [2]: Stomach | Amount: {organs[1]}" +
                            $" \n [3]: Brain | Amount: {organs[2]} \n [4]: Bone | Amount: {organs[3]} \n " +
                            $"[5]: Special | Amount: {organs[5]}");
                        break;
                    case (uint)CardEnums.Category.Virus:
                        Console.WriteLine("[1]: Heart \n [2]: Stomach \n [3]: Brain \n [4]: Bone \n [5]: Special");
                        break;
                    case (uint)CardEnums.Category.Med:
                        Console.WriteLine("[1]: Heart \n [2]: Stomach \n [3]: Brain \n [4]: Bone \n [5]: Special");
                        break;
                    case (uint)CardEnums.Category.Doctor:
                        Console.WriteLine("[1]: Heart \n [2]: Stomach \n [3]: Brain \n [4]: Bone \n [5]: Special");
                        break;
                    default:
                        Console.WriteLine("You must enter a number from 1 - 5!");
                        repeatSelection = true; // Invalid choice; repeat the loop
                        break;
                }
            } while (repeatSelection); // Continue looping if an invalid choice was made
        }

        private static void DisplayOptions()
        {
            Console.WriteLine("Get Information about the Indexes");
            Console.WriteLine();
            Console.WriteLine("1 - Organs");
            Console.WriteLine("2 - Viruses");
            Console.WriteLine("3 - Meds");
            Console.WriteLine("4 - Doctors");
        }
    }
}
