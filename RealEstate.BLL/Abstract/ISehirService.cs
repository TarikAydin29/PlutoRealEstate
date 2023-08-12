using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Abstract
{
    public interface ISehirService
    {
        IEnumerable<sehir> TGetSehirs();
        sehir TGetSehirByTitle(string title);
        sehir TGetSehirByKey(int key);
    }
}
