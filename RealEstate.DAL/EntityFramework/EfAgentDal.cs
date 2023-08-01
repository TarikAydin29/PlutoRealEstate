using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.DAL.Repositories;
using RealEstate.Entities.Entities;
using System.Xml.Linq;

namespace RealEstate.DAL.EntityFramework
{
    public class EfAgentDal : GenericRepository<Agent>, IAgentDal
    {
        private readonly Context context;

        public EfAgentDal(Context context) : base(context)
        {
            this.context = context;
        }

        public Agent GetByEmail(string email)
        {
            return context.Agents.FirstOrDefault(x => x.Email == email);
        }
    }
}
