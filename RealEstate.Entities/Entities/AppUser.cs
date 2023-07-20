using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class AppUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int? ConfirmCode { get; set; }
    }
}
