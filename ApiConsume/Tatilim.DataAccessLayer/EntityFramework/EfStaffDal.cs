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
    public class EfStaffDal : GenericRepository<Staff>, IStaffDal
    {
        public EfStaffDal(Context context) : base(context)
        {
        }

        public int GetStaffCount()
        {
            using var context = new Context();
            var value = context.Staffs.Count();
            return value;
        }

        public List<Staff> LastFourStaff()
        {
            using var context = new Context();
            var values = context.Staffs.OrderByDescending(x=>x.StaffID).Take(4).ToList();//orderdescending sıralar ve take ile 4 tane veri çekeriz
            return values;
        }
    }
}
