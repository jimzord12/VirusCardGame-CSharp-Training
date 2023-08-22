using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Card_NS;
using CardEnums_NS;

namespace DoctorCard_NS
{
    internal class DoctorCard : Card
    {
        public CardEnums.SubDocCategory SubDocCategory { get; set; }
        public DoctorCard(CardEnums.Category _cat, CardEnums.SubDocCategory _subCat) : base(_cat)
        {
            SubDocCategory = _subCat;
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
