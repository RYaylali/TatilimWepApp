using System;
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
    public class EfRoomDal : GenericRepository<Room>, IRoomDal
    {
        public EfRoomDal(Context context) : base(context)
        {
        }

        public int RoomCount()
        {
            var context=new Context();  
            return context.Rooms.Count();
        }
    }
}
