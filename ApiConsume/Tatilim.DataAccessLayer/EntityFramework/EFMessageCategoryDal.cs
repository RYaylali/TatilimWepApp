﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatilim.DataAccessLayer.Abstract;
using Tatilim.DataAccessLayer.Concrete;
using Tatilim.DataAccessLayer.Repositories;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.DataAccessLayer.EntityFramework
{
    public class EFMessageCategoryDal : GenericRepository<MessageCategory>, IMessageCategoryDal
    {
        public EFMessageCategoryDal(Context context) : base(context)
        {
        }
    }
}