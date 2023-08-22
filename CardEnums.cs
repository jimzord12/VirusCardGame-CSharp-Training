using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardEnums_NS
{
    static class CardEnums
    {
        public enum Category
        {
            Organ, Virus, Med, Doctor
    };
        public enum SubCategory
        { 
            Heart, Stomach, Brain, Bone, Special 
        }
        public enum SubDocCategory 
        {   
            OrganStealer, 
            OrganSwapper, 
            BodySwapper, 
            HandBreaker, 
            VirusSpreader 
        }
    }
}
