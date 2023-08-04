using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class ilce
    {
        [Key]
        public int ilce_id { get; set; }
        public string ilce_title { get; set; }
        public int ilce_key { get; set; }
        public int ilce_sehirkey { get; set; }
    }
}
