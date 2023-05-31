﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.DataAccessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.BusinessLayer.Concrete
{
	public class WorkLocationManager :IWorkLocationService
	{
		private readonly IWorkLocationDal _workLocationDal;

		public WorkLocationManager(IWorkLocationDal workLocationDal)
		{
			_workLocationDal = workLocationDal;
		}

		public void TDelete(WorkLocation entity)
		{
			_workLocationDal.Delete(entity);
		}

		public WorkLocation TGetByID(int id)
		{
			return _workLocationDal.GetByID(id);
		}

		public List<WorkLocation> TGetList()
		{
			return _workLocationDal.GetList();
		}

		public void TInsert(WorkLocation entity)
		{
			_workLocationDal.Insert(entity);
		}

		public void TUpdate(WorkLocation entity)
		{
			_workLocationDal.Update(entity);
		}
	}
}
