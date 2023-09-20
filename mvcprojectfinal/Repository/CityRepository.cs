using Microsoft.Extensions.Hosting;
using mvcprojectfinal.Models;

namespace mvcprojectfinal.Repository
{
    public class CityRepository : ICityRepository
    {
        Context context;
        public CityRepository(Context _context)
        {
            context = _context;

        }
        public void Delete(int id)
        {
            City orgcity = GetById(id);
            context.cities.Remove(orgcity);
            context.SaveChanges();

        }

        public List<City> GetAll()
        {
            return context.cities.ToList();
        }

        public City GetById(int id)
        {
            return context.cities.FirstOrDefault(c => c.Id == id);
        }

        public void Insert(City city)
        {
            context.cities.Add(city);
            context.SaveChanges();
        }

        public void Update(int id, City city)
        {
            City orgcity = GetById(id);
            orgcity.Name = city.Name;
            orgcity.Image = city.Image;
            context.SaveChanges();
        }
    }
}
