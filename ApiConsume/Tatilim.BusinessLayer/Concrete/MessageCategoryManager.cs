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
    public class MessageCategoryManager :IMessageCategoryService
    {
        private readonly IMessageCategoryDal _messageCategory;

        public MessageCategoryManager(IMessageCategoryDal messageCategory)
        {
            _messageCategory = messageCategory;
        }
        public void TDelete(MessageCategory entity)
        {
            _messageCategory.Delete(entity);
        }

        public MessageCategory TGetByID(int id)
        {
            return _messageCategory.GetByID(id);
        }

        public List<MessageCategory> TGetList()
        {
            return _messageCategory.GetList();
        }

        public void TInsert(MessageCategory entity)
        {
            _messageCategory.Insert(entity);
        }

        public void TUpdate(MessageCategory entity)
        {
            _messageCategory.Update(entity);
        }
    }
}
