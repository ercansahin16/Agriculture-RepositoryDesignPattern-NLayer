﻿using DataAccessLayer.Concrete.Repository;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
   public class EFImageDal:GenericRepository<Image>,IImageDal
   {
   }
}
