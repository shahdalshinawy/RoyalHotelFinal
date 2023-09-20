using mvcprojectfinal.Models;

namespace mvcprojectfinal.Repository
{
    public interface IImageRepository
    {
        List<Images> GetAll();
        Images GetById(int id);
        void Insert(Images images);
        void Update(int id, Images images);
        void Delete(int id);


    }
}
