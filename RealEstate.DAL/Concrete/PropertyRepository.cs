using RealEstate.DAL.Abstract;
using RealEstate.Entities.Entities;

namespace RealEstate.DAL.Concrete
{
    public class PropertyRepository : BaseRepository<Property, Context>, IPropertyRepository
    {
        public PropertyRepository(Context context) : base(context)
        {
        }
    }
}
