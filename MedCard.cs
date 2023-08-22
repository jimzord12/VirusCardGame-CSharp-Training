using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Card_NS;
using CardEnums_NS;

namespace MedCard_NS
{
    internal class MedCard : Card
    {
        public CardEnums.SubCategory SubCategory { get; set; }
        public MedCard(CardEnums.Category _cat, CardEnums.SubCategory _subCat) : base(_cat)
        {
            SubCategory = _subCat;
        }

        public override void Activate()
        {
            Console.WriteLine("aaaa");
        }
        public override void GetDesc()
        {
            Console.WriteLine("aaaa");
        }
    }
}
