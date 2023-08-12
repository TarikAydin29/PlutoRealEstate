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
    public class IlceManager : IIlceService
    {
        private readonly IIlceDAL ılceDAL;

        public IlceManager(IIlceDAL ılceDAL)
        {
            this.ılceDAL = ılceDAL;
        }
        public ilce TGetIlceByKey(int key)
        {
            return ılceDAL.GetIlceByKey(key);
        }

        public ilce TGetIlceByTitle(string title)
        {
            return ılceDAL.GetIlceByTitle(title);
        }

        public IEnumerable<ilce> TGetIlces()
        {
            return ılceDAL.GetIlces();
        }
    }
}
