using RealEstate.Core.Entities;

namespace RealEstate.Entities.Entities
{
    public class Favorite : BaseEntity
    {
        public Guid CustomerID { get; set; }
        public Guid PropertyID { get; set; }

        public Customer Customer { get; set; }
        public Property Property { get; set; }
    }
}
