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
    public class ISubscribleManager : ISubscribleService
    {
        private readonly ISubscribleDal _subscribleDal;

        public ISubscribleManager(ISubscribleDal subscribleDal)
        {
            _subscribleDal = subscribleDal;
        }

        public void TDelete(Subscribe entity)
        {
            _subscribleDal.Delete(entity);
        }

        public Subscribe TGetByID(int id)
        {
           return _subscribleDal.GetByID(id);   
        }

        public List<Subscribe> TGetList()
        {
            return _subscribleDal.GetList();
        }

        public void TInsert(Subscribe entity)
        {
            _subscribleDal.Insert(entity);  
        }

        public void TUpdate(Subscribe entity)
        {
            _subscribleDal.Update(entity);
        }
    }
}
