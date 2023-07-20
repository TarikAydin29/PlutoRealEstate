using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Core.Entities
{
    public class BaseProperty
    {
        public int ID { get; set; }
        public Guid PropertyNo { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Area { get; set; }
        public string Description { get; set; }


        //İl,ilçe, mahalle nav olarak mı string olarak mı gelicek
    }
}
