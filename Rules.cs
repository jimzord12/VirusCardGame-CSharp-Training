using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rules_NS
{
    internal static class Rules
    {
        public static int StartingCards { get; set; } = 3;
        public static int MaxCardsInHand { get; set; } = 3;
        public static int[] OrganCardsAmounts { get; set; } = new int[5] { 4, 4, 4, 4, 1 };
        public static int[] VirusCardsAmounts { get; set; } = new int[5] { 3, 3, 3, 3, 1 };
        public static int[] MedCardsAmounts { get; set; } = new int[5] { 4, 4, 4, 4, 4 };
        public static int[] DoctorCardsAmounts { get; set; } = new int[5] { 4, 3, 2, 2, 3 };

    }
        
    
}
