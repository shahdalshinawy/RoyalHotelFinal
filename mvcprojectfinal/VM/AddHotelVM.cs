using mvcprojectfinal.Models;

namespace mvcprojectfinal.VM
{
    public class AddHotelVM
    {
        public string name { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }
        public int CityID { get; set; }
        public int FunID { get; set; }
        public IFormFile Photo { get; set; }
        public List<Images>? images { get; set; } = new List<Images>();
        public virtual Fun? Fun { get; set; } = new Fun();
    }
}
