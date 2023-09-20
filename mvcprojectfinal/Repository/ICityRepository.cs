using mvcprojectfinal.Models;

namespace mvcprojectfinal.Repository
{
    public interface ICityRepository
    {
        List<City> GetAll();
        City GetById(int id);
        void Insert(City city);
        void Update(int id, City city);
        void Delete(int id);
    }
}
