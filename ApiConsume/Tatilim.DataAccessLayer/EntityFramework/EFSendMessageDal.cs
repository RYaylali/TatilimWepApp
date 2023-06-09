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
    public class EFSendMessageDal : GenericRepository<SendMessage>, ISendMessageDal
    {
        public EFSendMessageDal(Context context) : base(context)
        {
        }

        public int SendMessageCount()
        {
            var context = new Context();
            var value = context.SendMessages.Count();
            return value;
        }
    }
}
