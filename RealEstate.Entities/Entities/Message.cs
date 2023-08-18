using RealEstate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Entities.Entities
{
    public class Message : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Guid PropertyId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserMessage { get; set; }
    }
}
