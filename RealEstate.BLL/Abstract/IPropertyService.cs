using RealEstate.Entities.Entities;

namespace RealEstate.BLL.Abstract
{
    public interface IPropertyService : IGenericService<Property>
    {
        IEnumerable<Property> TGetByAgentIdList(Guid id);

    }

}
