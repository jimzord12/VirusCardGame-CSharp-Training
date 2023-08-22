using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Card_NS;
using CardEnums_NS;

namespace OrganCard_NS
{

    internal class OrganCard : Card
    {
        public CardEnums.SubCategory SubCategory { get; set; }

        public OrganCard(CardEnums.Category _cat, CardEnums.SubCategory _subCat) : base(_cat)
        {
            SubCategory = _subCat;
            Name = _subCat.ToString();
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
