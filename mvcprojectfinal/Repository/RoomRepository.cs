using Microsoft.EntityFrameworkCore;
using mvcprojectfinal.Models;

namespace mvcprojectfinal.Repository
{
    public class RoomRepository : IRoomRepository
    {
        Context context;
        public RoomRepository(Context _context)
        {
            context = _context;

        }
        public List<Room> GetAll()
        {
            return context.rooms.Include(c => c.hotels).ToList();
        }

        public Room GetById(int id)
        {
            return context.rooms.Where(i => i.ID == id).Include(h => h.hotels).FirstOrDefault();
            //return context.rooms.Include(c => c.hotels).FirstOrDefault(c => c.ID== id);
        }

        public void Insert(Room room)
        {
            context.rooms.Add(room);
            context.SaveChanges();
        }
    }
}
