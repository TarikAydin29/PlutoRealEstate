using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Abstract
{
    public interface IPropertyPhotoService : IGenericService<PropertyPhoto>
    {
        IEnumerable<PropertyPhoto> TGetByPropertyIdList(Guid id);

    }
}
