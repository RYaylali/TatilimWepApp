using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.DataAccessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.BusinessLayer.Concrete
{
	public class AppUserManarger : IAppUserService
	{
		private readonly IAppUserDal _appUserDal;

		public AppUserManarger(IAppUserDal appUserDal)
		{
			_appUserDal = appUserDal;
		}

		public void TDelete(AppUser entity)
		{
			throw new NotImplementedException();
		}

		public AppUser TGetByID(int id)
		{
			throw new NotImplementedException();
		}

		public List<AppUser> TGetList()
		{
			return _appUserDal.GetList();
		}

		public void TInsert(AppUser entity)
		{
			throw new NotImplementedException();
		}

		public void TUpdate(AppUser entity)
		{
			throw new NotImplementedException();
		}

		public List<AppUser> TUserListWithWorkLocation()
		{
			return _appUserDal.UserListWithWorkLocation();
		}
	}
}
