using RealEstate.Core.Entities;

namespace RealEstate.Entities.Entities
{
    public class Category 
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }


        public List<Property> Properties { get; set; }
    }
}
