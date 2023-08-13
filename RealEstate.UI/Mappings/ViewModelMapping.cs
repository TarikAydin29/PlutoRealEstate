using AutoMapper;
using RealEstate.Entities.Entities;
using RealEstate.UI.Areas.AdminArea.Models.AgentVMs;
using RealEstate.UI.Areas.AdminArea.Models.CategoryVMs;
using RealEstate.UI.Areas.AdminArea.Models.PropertyStatusVMs;
using RealEstate.UI.Areas.AgentArea.Models;
using RealEstate.UI.Areas.AgentArea.Models.AgentVM;
using RealEstate.UI.Models;

namespace RealEstate.UI.Mappings
{
    public class ViewModelMapping : Profile
    {
        public ViewModelMapping()
        {
            CreateMap<CreateAgentVM, Agent>().ReverseMap();
            CreateMap<RegisterVM, AppUser>().ReverseMap();
            CreateMap<Agent, GettAllAgentViewModel>().ReverseMap();
            CreateMap<Agent, UpdateAgentVM>().ReverseMap();
            CreateMap<AppUser, UpdateAgentVM>().ReverseMap();

            CreateMap<CreateCategoryViewModel, Category>().ReverseMap();
            CreateMap<Category, GettAllCategoryViewModel>().ReverseMap();
            CreateMap<UpdateCategoryStatusVM, Category>().ReverseMap();

            CreateMap<PropertyStatus, GettAllPropertyStatusViewModel>().ReverseMap();
            CreateMap<PropertyStatus, CreatePropertyStatusVM>().ReverseMap();
            CreateMap<UpdatePropertyStatusVM, PropertyStatus>();

            CreateMap<ListPropertyVM, Property>().ReverseMap();
            CreateMap<CreatePropertyVM, Property>().ReverseMap();
            CreateMap<UpdatePropertyVM, Property>().ReverseMap();

            CreateMap<PropListVM, Property>().ReverseMap();
        }
    }
}
