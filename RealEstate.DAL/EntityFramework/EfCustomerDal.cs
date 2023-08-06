using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.DAL.Repositories;
using RealEstate.Entities.Entities;

namespace RealEstate.DAL.EntityFramework
{
    public class EfCustomerDal : GenericRepository<Customer>, ICustomerDal
    {
        private readonly Context _context;

        public EfCustomerDal(Context context) : base(context)
        {
            _context = context;
        }
 
    }
}
