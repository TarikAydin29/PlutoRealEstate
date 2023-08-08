using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.DAL.Repositories;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.EntityFramework
{
    public class EFPropertyPhotoDAL : GenericRepository<PropertyPhoto>, IPropertyPhotoDAL
    {
        private readonly Context context;

        public EFPropertyPhotoDAL(Context context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<PropertyPhoto> GetByPropertyIdList(Guid id)
        {
            var values = context.PropertyPhotos.Where(x => x.PropertyId == id && x.IsActive == true).ToList();

            return values;
        }
    }
}
