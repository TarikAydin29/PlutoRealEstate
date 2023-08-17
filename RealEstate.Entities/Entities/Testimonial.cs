using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class Testimonial :BaseEntity
    {
        public string CustomerName { get; set; }      
        public string Comment { get; set; }
        public string ImageUrl { get; set; }

    }
}
