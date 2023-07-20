using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class Land : BaseProperty
    {
        public int Ada { get; set; }
        public int Parsel { get; set; }
        public int Pafta { get; set; }
        public int MyProperty { get; set; }
    }
}
