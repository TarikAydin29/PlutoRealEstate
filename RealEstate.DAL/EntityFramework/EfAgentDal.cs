using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.DAL.Repositories;
using RealEstate.Entities.Entities;

namespace RealEstate.DAL.EntityFramework
{
    public class EfAgentDal : GenericRepository<Agent>, IAgentDal
    {
        public EfAgentDal(Context context) : base(context)
        {
        }
    }
}
