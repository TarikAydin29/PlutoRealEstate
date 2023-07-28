using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.DAL.Repositories;
using RealEstate.Entities.Entities;

namespace RealEstate.DAL.EntityFramework
{
    public class EfFavoriteDal : GenericRepository<Favorite>, IFavoriteDal
    {
        public EfFavoriteDal(Context context) : base(context)
        {
        }
    }
}
