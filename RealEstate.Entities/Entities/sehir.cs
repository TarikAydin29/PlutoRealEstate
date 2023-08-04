using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class sehir
    {
        [Key]
        public int sehir_id { get; set; }
        public string sehir_title { get; set; }
        public int sehir_key { get; set; }       
    }
}
