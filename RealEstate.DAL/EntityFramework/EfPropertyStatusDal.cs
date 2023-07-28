using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.DAL.Repositories;
using RealEstate.Entities.Entities;

namespace RealEstate.DAL.EntityFramework
{
    public class EfPropertyStatusDal : GenericRepository<PropertyStatus>, IPropertyStatusDal
    {
        public EfPropertyStatusDal(Context context) : base(context)
        {
        }
    }
}
