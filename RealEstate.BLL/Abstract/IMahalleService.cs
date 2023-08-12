using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Abstract
{
    public interface IMahalleService
    {
        IEnumerable<mahalle> TGetMahalles();
        mahalle TGetMahalleByTitle(string title);
        mahalle TGetMahalleByKey(int key);
    }
}
