using mvcprojectfinal.Models;

namespace mvcprojectfinal.VM
{
    public class BookingALLVM
    {
        public string SSN { get; set; }
        public string Visa { get; set; }
        public string ApplicationUserID { get; set; }

        public Hotels HotelDetails { get; set; }
        //public RoomVisits roomVisits { get; set; } = new RoomVisits();
        public List<int> roomsThatReserved { get; set; }
        //public int subPrice { get; set; }
        public DateTime check_in { get; set; }
        public DateTime check_out { get; set; }
    }
}
