using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RealEstate.DAL.Abstract;
using RealEstate.DAL.Concrete;
using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.DAL.EntityFramework
{
    public class EFIlceDAL : IIlceDAL
    {
        private readonly Context context;

        public EFIlceDAL(Context context)
        {
            this.context = context;
        }
        public ilce GetIlceByKey(int key)
        {
            var value = context.ilce.FirstOrDefault(x=>x.ilce_key==key);
            return value;
        }

        public ilce GetIlceByTitle(string title)
        {
            var value = context.ilce.FirstOrDefault(x => x.ilce_title == title);
            return value;
        }

        public IEnumerable<ilce> GetIlces()
        {
            var values = context.ilce.ToList();
            return values;
        }
    }
}
