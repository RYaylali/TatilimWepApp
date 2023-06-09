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
	public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

		public void TBookingStatusChangeWaitingForApproval(int id)
		{
			_bookingDal.BookingStatusChangeWaitingForApproval(id);
		}

		public void TBookingStatusChangeApproved(Booking booking)
		{
			_bookingDal.BookingStatusChangeApproved(booking);
		}

		public void TBookingStatusChangeApproved(int id)
		{
			_bookingDal.BookingStatusChangeApproved(id);
		}

		public void TBookingStatusChangeApproved3(int id)
		{
            _bookingDal.BookingStatusChangeApproved3(id);
		}

		public void TBookingStatusChangeCancel(int id)
		{ 
            _bookingDal.BookingStatusChangeCancel(id);
		}

		public void TDelete(Booking entity)
        {
            _bookingDal.Delete(entity);
        }

        public int TGetBookingCount()
        {
           return _bookingDal.GetBookingCount();
        }

        public Booking TGetByID(int id)
        {
           return _bookingDal.GetByID(id);
        }

        public List<Booking> TGetList()
        {
            return _bookingDal.GetList();
        }

        public void TInsert(Booking entity)
        {
            _bookingDal.Insert(entity);
        }

        public List<Booking> TLast6Booking()
        {
            return _bookingDal.Last6Booking();
        }

        public void TUpdate(Booking entity)
        {
            _bookingDal.Update(entity);
        }
    }
}
