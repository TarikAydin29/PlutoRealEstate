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
    public class AgentManager : IAgentService
    {
        private readonly IAgentDal _agentDal;

        public AgentManager(IAgentDal agentDal)
        {
            _agentDal = agentDal;
        }

        public Task<Agent> TInsertAsync(Agent entity)
        {
            return _agentDal.InsertAsync(entity);
        }
        public void TDelete(Agent entity)
        {
             _agentDal.Delete(entity);
        }
        public Task<Guid> TUpdateAsync(Agent entity)
        {
            return _agentDal.UpdateAsync(entity);
        }

        public Task<List<Agent>> TGetAllAsync()
        {
            return _agentDal.GetAllAsync();
        }

        public Task<Agent> TGetByIdAsync(Guid Id)
        {
            return _agentDal.GetByIdAsync(Id);
        }
        public Task<int> TSaveAsync()
        {
            return (_agentDal.SaveAsync());
        }

    }
}
