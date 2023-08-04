using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class sokak_cadde
    {
        [Key]
        public int sokak_cadde_id { get; set; }
        public string sokak_cadde_title { get; set; }
        public int sokak_cadde_mahallekey { get; set; }
        
    }
}
