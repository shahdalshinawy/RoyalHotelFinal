using mvcprojectfinal.Models;

namespace mvcprojectfinal.Repository
{
    public interface IRoomRepository
    {
        List<Room> GetAll();
        Room GetById(int id);
        void Insert(Room room);


    }
}
