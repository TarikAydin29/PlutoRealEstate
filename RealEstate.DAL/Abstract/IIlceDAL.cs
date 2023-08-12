using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.Abstract
{
    public interface IIlceDAL
    {
        IEnumerable<ilce> GetIlces();
        ilce GetIlceByTitle(string title);
        ilce GetIlceByKey(int key);
    }
}
