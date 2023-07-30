using RealEstate.Core.Entities;

namespace RealEstate.Entities.Entities
{
    public class Customer : BaseEntity
    {     
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }


        public List<Favorite> Favorites { get; set; }
    }
}
