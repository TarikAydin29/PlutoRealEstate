using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class mahalle
    {
        [Key]
        public int mahalle_id { get; set; }
        public string mahalle_title { get; set; }
        public int mahalle_key { get; set; }
        public int mahalle_ilcekey { get; set; }
    }
}
