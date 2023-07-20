using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class Building : BaseProperty
    {
        public int BedroomCount { get; set; }
        public int BathCount { get; set; }
        public int BalconyCount { get; set; }
        public string Floor { get; set; }
        public decimal Dues { get; set; }
        public bool IsInSite { get; set; }
    }
}
