using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.BusinessLayer.Abstract
{
    public interface IStaffService:IGenericService<Staff>
    {
        int TGetStaffCount();
        List<Staff> TLastFourStaff();
    }
}
