using Card_NS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers_NS
{
    internal static class Helpers
    {
        public static uint GetUintInput()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            char userInput = keyInfo.KeyChar; // Get the character representation of the key

            while (!char.IsDigit(userInput))
            {
                Console.WriteLine("\n[X] --- You did not press a numeric key. Try Again --- [X]");
                userInput = Console.ReadKey().KeyChar;
            }

            return Convert.ToUInt32(userInput.ToString());
        }

        public static uint GetUintInput(int start, int end)
        {
            bool inputIsValid;
            uint input;
            do
            {
                inputIsValid = true;
                input = Convert.ToUInt32(Console.ReadKey());
                if (input < start || input > end)
                {
                    Console.WriteLine("Wrong Input! Please try again.");
                    inputIsValid = false;
                }
            } while (inputIsValid);

            return input;
        }
    }
}
