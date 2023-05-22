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
	public class SendMessageManager : ISendMessageService
	{
		private readonly ISendMessageDal _sendMessage;

		public SendMessageManager(ISendMessageDal sendMessage)
		{
			_sendMessage = sendMessage;
		}

		public void TDelete(SendMessage entity)
		{
			_sendMessage.Delete(entity);
		}

		public SendMessage TGetByID(int id)
		{
			return _sendMessage.GetByID(id);
		}

		public List<SendMessage> TGetList()
		{
			return _sendMessage.GetList();
		}

		public void TInsert(SendMessage entity)
		{
			_sendMessage.Insert(entity);
		}

		public void TUpdate(SendMessage entity)
		{
			_sendMessage.Update(entity);
		}
	}
}
