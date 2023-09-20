using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcprojectfinal.Models;
using mvcprojectfinal.Repository;
using mvcprojectfinal.VM;

namespace mvcprojectfinal.Controllers
{
    //[Authorize(Roles = "User")]
    public class AllController : Controller
    {

        IHotelRepository hotelRepository;
        IRoomRepository roomRepository1;
        private readonly UserManager<AppliacationUser> _userManager;
        Context context;
        public AllController(IHotelRepository _hotelrepository, IRoomRepository roomRepository, UserManager<AppliacationUser> userManager)
        {
            hotelRepository = _hotelrepository;
            roomRepository1 = roomRepository;
            _userManager = userManager;
            context = new Context();
        }

        public IActionResult AllInCity(int id)
        {
            City city = context.cities.FirstOrDefault(c => c.Id == id);

            return View(city);
        }
        public IActionResult Hotelss(int id)
        {
            List<Hotels> hotels = context.hotels.Include(n=>n.images).Include(s=>s.feedBacks).Where(h => h.CityID == id).ToList();
            ViewBag.Id = id;
            return View(hotels);
         
        }

        [HttpGet]
        public IActionResult specificHotel(int id)
        {
            ViewBag.hotells = hotelRepository.GetById(id);
          
            List<RoomVisits> roomVisits = context.roomVisits.ToList();
            Room room;
            foreach (RoomVisits roomVisits1 in roomVisits)
            {
                if (roomVisits1.check_out <= DateTime.Now)
                {
                    room = context.rooms.Where(w => w.ID == roomVisits1.RoomID).FirstOrDefault();
                    room.IsReserved = false;
                }
            }
            context.SaveChanges();
            ViewBag.roomss = context.rooms.Where(e => e.IsReserved == false).ToList();
            //Hotels hotells = hotelRepository.GetById(id);
            //BookingALLVM viewModel = new BookingALLVM()
            //{
            //    HotelDetails = hotells
            //};
            return View();

        }
        [HttpPost]
        public IActionResult NewReservation(BookingALLVM bookingAllVm)
        {
            int? TotalPrice = 0;
            bookingAllVm.ApplicationUserID = _userManager.GetUserId(HttpContext.User);
            Booking booking = new Booking()
            {
                SSN = bookingAllVm.SSN,
                Visa = bookingAllVm.Visa,
                AppliacationUserID = bookingAllVm.ApplicationUserID
            };

            context.booking.Add(booking);
            Room room1;
            foreach (int room in bookingAllVm.roomsThatReserved)
            {
                room1 = context.rooms.Where(r => r.ID == room).FirstOrDefault();
                room1.IsReserved = true;

            }
            context.SaveChanges();
            for (int i = 0; i < bookingAllVm.roomsThatReserved.Count; i++)
            {
                roomRepository1.GetById(bookingAllVm.roomsThatReserved[i]).IsReserved = true;
                RoomVisits roomVisits = new RoomVisits()
                {
                    BokingId = booking.id,
                    RoomID = bookingAllVm.roomsThatReserved[i],
                    subPrice = roomRepository1.GetById(bookingAllVm.roomsThatReserved[i]).price,
                    check_in = bookingAllVm.check_in,
                    check_out = bookingAllVm.check_out,
                    ReservationDate = DateTime.Now,


                };
                roomVisits.numberofnights = roomVisits.check_out.Value.Day - roomVisits.check_in.Value.Day;
                TotalPrice += roomVisits.subPrice * roomVisits.numberofnights;
                booking.totalPrice = TotalPrice;
                //booking.TotalPrice = TotalPrice;
                context.roomVisits.Add(roomVisits);
                context.SaveChanges();
            }




            return Json(bookingAllVm);
        }
		public IActionResult f(int id)
		{
			FilterVm filterVm = new FilterVm();
			filterVm.cityid = id;
			ViewBag.ff = id;
			return View(filterVm);

		}
		[HttpPost]
		public IActionResult filter(FilterVm filterVm)
		{

			Fun f = new Fun();
			f.IsContainsAquaBark = filterVm.IsContainsAquaBark;
			f.IsContainsBeach = filterVm.IsContainsBeach;
			f.IsContainsDesco = filterVm.IsContainsDesco;
			f.IsContaintsSwimmingPool = filterVm.IsContaintsSwimmingPool;
			f.IsHavingElevator = filterVm.IsHavingElevator;
			f.IsHavingKidsArea = filterVm.IsHavingKidsArea;
			f.IsHavingParking = filterVm.IsHavingParking;
			f.IsOpenBuffit = filterVm.IsOpenBuffit;
			f.Stars = filterVm.Stars;



			List<Hotels> hotels =
					context.hotels.Include(h => h.Fun).Include(i=>i.images).Where(q=>q.CityID==filterVm.cityid).ToList();//new List<Hotels>();
			if (f.IsContainsBeach)
				hotels = hotels.Where(n => n.Fun.IsContainsBeach == true && n.CityID == filterVm.cityid).ToList();

			if (f.IsContainsAquaBark)
			{

				hotels = hotels.Where(a => a.Fun.IsContainsAquaBark == true && a.CityID == filterVm.cityid).ToList();

			}
			if (f.IsContainsDesco)
			{


				hotels = hotels.Where(q => q.Fun.IsContainsDesco == true && q.CityID == filterVm.cityid).ToList();

			}
			if (f.IsContaintsSwimmingPool)
			{

				hotels = hotels.Where(a => a.Fun.IsContaintsSwimmingPool == true && a.CityID == filterVm.cityid).ToList();

			}
			if (f.IsHavingElevator)
			{

				hotels = hotels.Where(a => a.Fun.IsHavingElevator == true && a.CityID == filterVm.cityid).ToList();

			}
			if (f.IsHavingKidsArea)
			{

				hotels = hotels.Where(a => a.Fun.IsHavingKidsArea == true && a.CityID == filterVm.cityid).ToList();

			}
			if (f.IsHavingParking)

			{
				hotels = hotels.Where(a => a.Fun.IsHavingParking == true && a.CityID == filterVm.cityid).ToList();

			}
			if (f.IsOpenBuffit)
			{

				hotels = hotels.Where(a => a.Fun.IsOpenBuffit == true && a.CityID == filterVm.cityid).ToList();

			}
			ViewBag.Id = filterVm.cityid;

			//RedirectToAction("Hotelss", filterVm.cityid);
          
			return View("Hotelss", hotels);
           


		}
        public IActionResult ReservationHistory()
        {
            DateTime datenow = DateTime.Now;
            ViewBag.datenow = datenow;
            string userid = _userManager.GetUserId(HttpContext.User);

            var userReserveHistory = context.roomVisits.Include(r => r.booking).Include(r => r.Room.hotels).Include(r => r.Room).Where(r => r.booking.AppliacationUserID == userid && r.Room.IsReserved == true).ToList();
            return View(userReserveHistory);
        }

        [Route("All/CancleResevation/{id?}")]
        public IActionResult CancleResevation(string? userid, int? roomid)
        {
            var user = context.roomVisits.Include(r => r.booking).Include(r => r.Room).Include(r => r.Room.hotels).FirstOrDefault(r => r.booking.AppliacationUserID == userid && r.Room.IsReserved == true && r.RoomID == roomid);
            if (user != null)
            {
                context.roomVisits.Remove(user);
                context.SaveChanges();
            }
                var user1 = context.roomVisits.Include(r => r.booking).Include(r => r.Room.hotels).Include(r => r.Room).Where(r => r.booking.AppliacationUserID == userid && r.Room.IsReserved == true).ToList();
                if (user1.Count() == 0)
                {
                    var userBooking = context.booking.FirstOrDefault(r => r.AppliacationUserID == userid);
                    context.booking.Remove(userBooking);
                    context.SaveChanges();
                
                }
            return RedirectToAction("ReservationHistory", "All");

        }
        public IActionResult ThankYou()
        {
            return View();

        }




    }
}
