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
        private readonly Context context;

        public EfPropertyDal(Context context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<Property> GetByAgentIdList(Guid id)
        {
            var values = context.Properties.ToList().Where(x => x.AgentID == id);
            return values;
        }
    }
}
