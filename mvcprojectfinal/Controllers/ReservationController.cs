using Microsoft.AspNetCore.Mvc;
using mvcprojectfinal.Models;
using mvcprojectfinal.Repository;

namespace mvcprojectfinal.Controllers
{
    public class ReservationController : Controller
    {
        IBookingRepository bookingRepository;
        public ReservationController(IBookingRepository _bookingRepository)
        {
            bookingRepository = _bookingRepository;


        }
        [HttpGet]
        public IActionResult New()
        {
            return View(new Booking());

        }

        [HttpPost]
        public IActionResult SaveNew(Booking booking)
        {

            if (booking.Visa != null)
            {
                bookingRepository.Insert(booking);


                return RedirectToAction("saved");
            }
            return View(booking);
        }
        public IActionResult saved()
        {
            return Content("aaa");
        }

    }
}
