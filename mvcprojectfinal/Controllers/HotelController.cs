using Microsoft.AspNetCore.Authorization;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.Extensions.Hosting;
using mvcprojectfinal.Hubs;
using mvcprojectfinal.Models;
using mvcprojectfinal.Repository;
using mvcprojectfinal.VM;
using NuGet.Protocol.Core.Types;
using System.Data;

namespace mvcprojectfinal.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class HotelController : Controller
    {
        IHotelRepository  hotelRepository;
        ICityRepository cityRepository;
        IImageRepository imageRepository;
        IHubContext<HotelHub> hubContext;

        public HotelController(IHotelRepository _hotelRepository, ICityRepository _cityRepository, IImageRepository imageRepository, IHubContext<HotelHub> _hubContext)
        {
            hotelRepository = _hotelRepository;
            cityRepository = _cityRepository;
            this.imageRepository = imageRepository;

            this.hubContext = _hubContext;//object hub 

        }

        [HttpGet]
        public IActionResult NEw()
        {
            ViewData["City"] = cityRepository.GetAll();
            //List<Images> Images = new List<Images>();
            //Hotels hotel = new Hotels();
            //hotel.images.Add(new Images());
            AddHotelVM hotelVM = new AddHotelVM();
            return View(hotelVM);
        }
        [HttpPost]
        public IActionResult SaveNew(AddHotelVM Hot)
        {
            //ImageVM imgvm=new ImageVM();
            //string FileName = imgvm.FileImage.FileName;


            //string uniqueFileName = Guid.NewGuid().ToString() + "_" + FileName;


            //var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/portfolio", FileName);


            //imgvm.FileImage.CopyTo(new FileStream(imagePath, FileMode.Create));
                string filename = string.Empty;
                if (!ModelState.IsValid)
                {

                    //string uploads = Path.Combine(hosting.WebRootPath, "image");
                    //filename = Hot.ImageFile.FileName;
                    //string fullpath = Path.Combine(uploads, filename);
                    //Hot.ImageFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    string FileName = Hot.Photo.FileName;
                    var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "D:\\Interview Projects\\Royal Hotel\\EmanMvcFinaal\\EmanMvc\\mvcprojectfinal\\wwwroot\\image\\", FileName);

                    Hot.Photo.CopyTo(new FileStream(imagePath, FileMode.Create));


                    Hotels hotel = new Hotels()
                    {
                        CityID = Hot.CityID,
                        Description = Hot.Description,
                        FunID = Hot.FunID,
                        name = Hot.name,
                        Fun = Hot.Fun,
                        images = Hot.images,
                        Location = Hot.Location

                    };
                    hotelRepository.Insert(hotel);
                    Images image = new Images()
                    {
                        HotelsId = hotel.id,
                        source = FileName
                    };

                    Context context = new Context();
                    context.images.Add(image);
                    hotel.images.Add(image);
                    context.SaveChanges();
                    //imageRepository.Insert(Hot.images[0]);
                    hubContext.Clients.All.SendAsync("NewHotelAdd", Hot.name, Hot.Description);
                    return RedirectToAction("index");
                }
            return View("NEw", Hot);

        }
        public IActionResult Index()
        {
            List<Hotels> Hot = hotelRepository.GetAll();
            return View(Hot);
        }
        public IActionResult Deatils(int id)
        {
            Hotels hot = hotelRepository.GetById(id);

            return View( hot);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {

            //old 
            Hotels HotModel =
            hotelRepository.GetById(id);
            return View(HotModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(Hotels newHot)
        {
           
            if (newHot.name != null)
            {
                hotelRepository.Update(newHot);
                return RedirectToAction("index");
            }

                

            return View(newHot);
        }

        //Delete ************************************************


        [HttpGet]
        public IActionResult Delete(int id)
        {
            //old 
            Hotels HotModel = hotelRepository.GetById(id);
            if (HotModel != null)
            {
                hotelRepository.Delete(id);
            }
            //view
            return RedirectToAction("index");
        }


    }
}
