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
    public class EFMahalleDAL : IMahalleDAL
    {
        private readonly Context context;

        public EFMahalleDAL(Context context)
        {
            this.context = context;
        }
        public mahalle GetMahalleByKey(int key)
        {
            var value = context.mahalle.FirstOrDefault(x => x.mahalle_key == key);
            return value;
        }

        public mahalle GetMahalleByTitle(string title)
        {
            var value = context.mahalle.FirstOrDefault(x => x.mahalle_title == title);
            return value;
        }

        public IEnumerable<mahalle> GetMahalles()
        {
            var values = context.mahalle.ToList();
            return values;
        }
    }
}
