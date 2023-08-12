using Microsoft.EntityFrameworkCore.Query.Internal;
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
    public class SehirManager : ISehirService
    {
        private readonly ISehirDAL sehirDAL;

        public SehirManager(ISehirDAL sehirDAL)
        {
            this.sehirDAL = sehirDAL;
        }
        public sehir TGetSehirByKey(int key)
        {
            return sehirDAL.GetSehirByKey(key);
        }

        public sehir TGetSehirByTitle(string title)
        {
            return sehirDAL.GetSehirByTitle(title);
        }

        public IEnumerable<sehir> TGetSehirs()
        {
            return sehirDAL.GetSehirs();
        }
    }
}
