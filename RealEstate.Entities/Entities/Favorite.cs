using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class Favorite
    {
        public Guid ID { get; set; }
        public int CustomerID { get; set; }
        public int PropertyID { get; set; }

        public Customer Customer { get; set; }
        public BaseProperty BaseProperty { get; set; }
    }
}
