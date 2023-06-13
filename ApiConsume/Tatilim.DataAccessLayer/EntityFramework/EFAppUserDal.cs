using Microsoft.EntityFrameworkCore;
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
	public class EFAppUserDal : GenericRepository<AppUser>, IAppUserDal
	{
		public EFAppUserDal(Context context) : base(context)
		{
		}

        public int AppUserCount()
        {
           var context= new Context();
			return context.Users.Count();
        }

        public List<AppUser> UserListWithWorkLocation()
		{
			var context = new Context();
			return  context.Users.Include(x=>x.WorkLocation).ToList();
		}

		public List<AppUser> UsersListWithWorkLocations()
		{
			var context = new Context();
			var values = context.Users.Include(x => x.WorkLocation).ToList();
			return values;
		}
	}
}
