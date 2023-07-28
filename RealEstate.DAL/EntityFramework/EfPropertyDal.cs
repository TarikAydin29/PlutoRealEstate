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
    public class EfPropertyDal : GenericRepository<Property>, IPropertyDal
    {
        public EfPropertyDal(Context context) : base(context)
        {
        }
    }
}
