using mvcprojectfinal.Models;

namespace mvcprojectfinal.Repository
{
    public class ImageRepo : IImageRepository
    {
        Context context;
        public ImageRepo(Context _context)
        {
            context = _context;

        }
        public void Delete(int id)
        {
            Images orgImg = GetById(id);
            context.images.Remove(orgImg);
            context.SaveChanges();

        }

        public List<Images> GetAll()
        {
            return context.images.ToList();
        }

        public Images GetById(int id)
        {
            return context.images.FirstOrDefault(c => c.id == id);
        }

        public void Insert(Images images)
        {
            context.images.Add(images);
            context.SaveChanges();
        }


        public void Update(int id, Images images)
        {
            Images orgImg = GetById(id);
            orgImg.source = images.source;

            context.SaveChanges();
        }
    }
}
