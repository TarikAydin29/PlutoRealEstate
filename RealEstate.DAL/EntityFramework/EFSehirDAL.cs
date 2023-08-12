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
    public class EFSehirDAL : ISehirDAL
    {
        private readonly Context context;

        public EFSehirDAL(Context context)
        {
            this.context = context;
        }
        public sehir GetSehirByKey(int key)
        {
            var value = context.sehir.FirstOrDefault(x=>x.sehir_key==key);
            return value;
        }

        public sehir GetSehirByTitle(string title)
        {
            var value = context.sehir.FirstOrDefault(x => x.sehir_title == title);
            return value;
        }

        public IEnumerable<sehir> GetSehirs()
        {
            var values = context.sehir.ToList();
            return values;
        }
    }
}
