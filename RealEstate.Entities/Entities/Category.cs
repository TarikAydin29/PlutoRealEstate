using RealEstate.Core.Entities;

namespace RealEstate.Entities.Entities
{
    public class Category : BaseEntity
    {
          
      
        public string Name { get; set; }


        public List<Property> Properties { get; set; }
    }
}
