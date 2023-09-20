using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mvcprojectfinal.Models;
using mvcprojectfinal.Repository;
using mvcprojectfinal.VM;
using System.Data;

namespace mvcprojectfinal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomController : Controller
    {
        
        IRoomRepository roomRepository;
        IHotelRepository hotelRepository;
        public RoomController(IRoomRepository _IRoomRepository , IHotelRepository hotelRepository)
        {
            roomRepository = _IRoomRepository;
            this.hotelRepository = hotelRepository;
        }
        [HttpGet]
        public IActionResult New ()
        {
            ViewData["Hotel"] = hotelRepository.GetAll();
            return View(new Room()) ;
        }
        [HttpPost]
        public IActionResult SaveNew(Room room)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    roomRepository.Insert(room);
                return RedirectToAction("index");
                }
            }
            catch
            {
                return Content("Please Enter Data !");

            }
            return View("New", room);

        }
        public IActionResult Index()
        {
            List<Room> room = roomRepository.GetAll();
            ViewData["Hotel"] = hotelRepository.GetAll();
            return View(room);
        }
    }
}
