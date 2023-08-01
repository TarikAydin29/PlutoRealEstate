using RealEstate.Entities.Entities;

namespace RealEstate.DAL.Abstract
{
    public interface IAgentDal : IGenericDal<Agent>
    {
        Agent GetByEmail(string email);

    }

}
