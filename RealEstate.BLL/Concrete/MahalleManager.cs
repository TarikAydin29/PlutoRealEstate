using RealEstate.BLL.Abstract;
using RealEstate.DAL.Abstract;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Concrete
{
    public class MahalleManager : IMahalleService
    {
        private readonly IMahalleDAL mahalleDAL;

        public MahalleManager(IMahalleDAL mahalleDAL)
        {
            this.mahalleDAL = mahalleDAL;
        }
        public mahalle TGetMahalleByKey(int key)
        {
            return mahalleDAL.GetMahalleByKey(key);
        }

        public mahalle TGetMahalleByTitle(string title)
        {
            return mahalleDAL.GetMahalleByTitle(title);
        }

        public IEnumerable<mahalle> TGetMahalles()
        {
            return mahalleDAL.GetMahalles();
        }
    }
}
