using mvcprojectfinal.Models;

namespace mvcprojectfinal.Repository
{
    public interface IHotelRepository
    {
        List<Hotels> GetAll();
        Hotels GetById(int id);
        void Insert(Hotels hotels);
        void Update(Hotels hotels);
        void Delete(int id);
        int SingleRoomQuantity(int id);
    }
}
