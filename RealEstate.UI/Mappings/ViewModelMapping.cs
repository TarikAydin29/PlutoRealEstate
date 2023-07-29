using AutoMapper;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Models.AgentVMs;

namespace RealEstate.UI.Mappings
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<CreateAgentVM, Agent>().ReverseMap();
        }
    }
}
