using Microsoft.EntityFrameworkCore;
using mvcprojectfinal.Models;

namespace mvcprojectfinal.Repository
{
    public class HotelRepository : IHotelRepository
    {
        Context context;
        public HotelRepository(Context _context)
        {
            context = _context;

        }
        public void Delete(int id)
        {
            Hotels orgHot = GetById(id);
            context.hotels.Remove(orgHot);
            context.SaveChanges();
        }
        public int SingleRoomQuantity(int id)
        {
            int counter = 0;
            Hotels orgHot = GetById(id);
            foreach (var item in orgHot.Rooms)
            {
                if (item.Type == "Single" || item.Type == "single")
                {
                    counter++;
                }
            }
            return counter;


        }
        public List<Hotels> GetAll()
        {
            return context.hotels.Include(x => x.Rooms).Include(f=>f.feedBacks).Include(q=>q.images).ToList();
        }
        public Hotels GetById(int id)
        {
            return context.hotels.Where(i => i.id == id).
                Include(h => h.Fun).
                Include(h => h.City).
                Include(h => h.images).Include(h => h.Rooms).Include(f=>f.feedBacks).FirstOrDefault();

        }
        public void Insert(Hotels hotel)
        {
            context.hotels.Add(hotel);
            context.SaveChanges();
        }

        public void Update(Hotels hot)
        {
            Hotels orgHot = GetById(hot.id);
            orgHot.name = hot.name;
            orgHot.Location = hot.Location;
            //orgHot.feedBacks = hot.feedBacks;
            orgHot.Fun.IsContainsBeach = hot.Fun.IsContainsBeach;
            orgHot.Fun.IsContainsDesco = hot.Fun.IsContainsDesco;
            orgHot.Fun.IsContainsAquaBark = hot.Fun.IsContainsAquaBark;
            orgHot.Fun.IsHavingElevator = hot.Fun.IsHavingElevator;
            orgHot.Fun.IsHavingKidsArea = hot.Fun.IsHavingKidsArea;
            orgHot.Fun.IsOpenBuffit = hot.Fun.IsOpenBuffit;
            orgHot.Fun.Stars = hot.Fun.Stars;
            orgHot.Fun.IsContaintsSwimmingPool = hot.Fun.IsContaintsSwimmingPool;
            orgHot.Fun.IsHavingParking = hot.Fun.IsHavingParking;
            //orgHot.CityID = hot.CityID;
            orgHot.Description = hot.Description;
            context.SaveChanges();

        }
    }
}
