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
    public class ServiceManager : IServiceService
    {
        private readonly IServicesDal _servicesDal;

        public ServiceManager(IServicesDal servicesDal)
        {
            _servicesDal = servicesDal;
        }

        public void TDelete(Service entity)
        {
            _servicesDal.Delete(entity);
        }

        public Service TGetByID(int id)
        {
            return _servicesDal.GetByID(id);
        }

        public List<Service> TGetList()
        {
            return _servicesDal.GetList();
        }

        public void TInsert(Service entity)
        {
            _servicesDal.Insert(entity);
        }

        public void TUpdate(Service entity)
        {
            _servicesDal.Update(entity);
        }
    }
}
