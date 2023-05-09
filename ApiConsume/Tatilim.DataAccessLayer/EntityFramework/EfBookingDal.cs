using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tatilim.DataAccessLayer.Abstract;
using Tatilim.DataAccessLayer.Concrete;
using Tatilim.DataAccessLayer.Migrations;
using Tatilim.DataAccessLayer.Repositories;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.DataAccessLayer.EntityFramework
{
	public class EfBookingDal : GenericRepository<Booking>, IBookingDal
	{
		public EfBookingDal(Context context) : base(context)
		{
		}

		public void BookingStatusChangeApproved(Booking booking)
		{
			var context = new Context();
			var values = context.Bookings.Where(x => x.BookingID == booking.BookingID).FirstOrDefault();
			values.Status = "Onaylandı";
			context.SaveChanges();
		}

		public void BookingStatusChangeApproved(int id)
		{
			var context = new Context();
			var values = context.Bookings.Find(id);
			values.Status = "Onaylandı";
			context.SaveChanges();
		}
	}
}
