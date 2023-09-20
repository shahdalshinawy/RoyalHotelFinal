namespace mvcprojectfinal.Models
{
    public class Booking
    {
        public int id { get; set; }

         public int? totalPrice {get;set; }
   
        public string AppliacationUserID { set; get; }

        public string SSN { get; set; }
        public string? Visa { get; set; }

        public List <RoomVisits> roomVisits { get; set; }  
        public virtual AppliacationUser User { get; set; }

    }
}
