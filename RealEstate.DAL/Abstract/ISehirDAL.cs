using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Abstract
{
    public interface ISehirDAL
    {
        IEnumerable<sehir> GetSehirs();
        sehir GetSehirByTitle(string title);
        sehir GetSehirByKey(int key);
    }
}
