using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class Favorite : BaseEntity
    {
        public Guid CustomerID { get; set; }
        public Guid PropertyID { get; set; }

        public Customer Customer { get; set; }
        public Property Property { get; set; }
    }
}
