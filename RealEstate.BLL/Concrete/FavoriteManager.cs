using RealEstate.BLL.Abstract;
using RealEstate.DAL.Abstract;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Concrete
{
    public class FavoriteManager : IFavoriteService
    {
        private readonly IFavoriteDal _favoriteDal;

        public FavoriteManager(IFavoriteDal favoriteDal)
        {
            _favoriteDal = favoriteDal;
        }
        public Task<Favorite> TInsertAsync(Favorite entity)
        {
            return _favoriteDal.InsertAsync(entity);
        }
        public bool TDelete(Favorite entity)
        {
            return _favoriteDal.Delete(entity);
        }
        public Task<Guid> TUpdateAsync(Favorite entity)
        {
            return _favoriteDal.UpdateAsync(entity);
        }
        public Task<List<Favorite>> TGetAllAsync()
        {
            return _favoriteDal.GetAllAsync();
        }

        public Task<Favorite> TGetByIdAsync(Guid Id)
        {
            return _favoriteDal.GetByIdAsync(Id);
        }
        public Task<int> TSaveAsync()
        {
            return (_favoriteDal.SaveAsync());
        }
    }
}
