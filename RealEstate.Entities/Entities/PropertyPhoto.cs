using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class PropertyPhoto : BaseEntity
    {      
        public string PhotoPath { get; set; }
        public Guid PropertyId { get; set; }
        public Property Property { get; set; }
    }
}
