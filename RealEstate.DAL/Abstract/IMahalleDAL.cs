using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Abstract
{
    public interface IMahalleDAL
    {
        IEnumerable<mahalle> GetMahalles();
        mahalle GetMahalleByTitle(string title);
        mahalle GetMahalleByKey(int key);
    }
}
