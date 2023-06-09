﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tatilim.BusinessLayer.Abstract;
using Tatilim.EntityLayer.Concrete;

namespace Tatilim.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BookingController : ControllerBase
	{
		private readonly IBookingService _bookingService;
		public BookingController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}

		[HttpGet]
		public IActionResult BookingList()
		{
			var values = _bookingService.TGetList();
			return Ok(values);
		}
		[HttpPost]
		public IActionResult AddBooking(Booking booking)
		{
			_bookingService.TInsert(booking);
			return Ok();
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteBooking(int id)
		{
			var values = _bookingService.TGetByID(id);
			_bookingService.TDelete(values);
			return Ok();
		}
		[HttpPut("UpdateBooking")]
		public IActionResult UpdateBooking(Booking booking)
		{
			_bookingService.TUpdate(booking);
			return Ok();
		}
		[HttpGet("{id}")]
		public IActionResult GetBooking(int id)
		{
			var values = _bookingService.TGetByID(id);
			return Ok(values);
		}
		[HttpPut("aaaaa")]
		public IActionResult aaaaa(Booking booking)
		{
			_bookingService.TBookingStatusChangeApproved(booking);
			return Ok();
		}
		[HttpPut("bbbb/{id}")]
		public IActionResult bbbb(int id)
		{
			_bookingService.TBookingStatusChangeApproved(id);
			return Ok();
		}
		[HttpGet("Last6Booking")]
		public IActionResult Last6Booking()
		{
			var values=_bookingService.TLast6Booking();
			return Ok(values);
		}
		[HttpGet("BookingAproved")]
		public IActionResult BookingAproved(int id)
		{
			_bookingService.TBookingStatusChangeApproved3(id);
			return Ok();
		}
		[HttpGet("BookingCancel")]
		public IActionResult BookingCancel(int id)
		{
			_bookingService.TBookingStatusChangeCancel(id);
			return Ok();
		}
		[HttpGet("BookingWaitingForApproval")]
		public IActionResult BookingWaitingForApproval(int id)
		{
			_bookingService.TBookingStatusChangeWaitingForApproval(id);
			return Ok();
		}
	}
}
