using RealEstate.Entities.Entities;

namespace RealEstate.BLL.Abstract
{
    public interface IAgentService : IGenericService<Agent>
    {
        Agent TGetByEmail(string email);

    }

}
