using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CardEnums_NS;

namespace Card_NS
{
    internal abstract class Card
    {
        public bool IsActive { get; set; } = false;
        public string? Name { get; init; }

        public uint Meds { get; set; } = 0;
        public uint Viruses { get; set; } = 0;
        public CardEnums.Category Category { get; set; }

        public abstract void Activate();
        public abstract void GetDesc();

        public Card(CardEnums.Category _cat)
        {
            Category = _cat;
        }
    }
}
