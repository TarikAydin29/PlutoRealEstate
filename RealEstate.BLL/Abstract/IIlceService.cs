﻿using RealEstate.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.BLL.Abstract
{
    public interface IIlceService
    {
        IEnumerable<ilce> TGetIlces();
        ilce TGetIlceByTitle(string title);
        ilce TGetIlceByKey(int key);
    }
}
