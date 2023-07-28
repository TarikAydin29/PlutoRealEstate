using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.DAL.Repositories;
using RealEstate.Entities.Entities;

namespace RealEstate.DAL.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
        public EfAdminDal(Context context) : base(context)
        {
        }
    }
}
