using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class Category : BaseEntity
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }


        public List<Property> Properties { get; set; }
    }
}
