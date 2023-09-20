using System.ComponentModel.DataAnnotations.Schema;

namespace mvcprojectfinal.Models
{
    public class RoomVisits
    {
        public int id { get; set; }
        public DateTime ReservationDate { get; set; }
        public int numberofnights { get; set; }

        [ForeignKey("booking")]
        public int? BokingId { get; set; }
        [ForeignKey("Room")]
        public int? RoomID { get; set; }

        public int? subPrice { get; set; }
        public DateTime? check_in { get; set; }
        public DateTime? check_out { get; set; }

        public Booking? booking { get; set; }
        public Room? Room { get; set; }
     

    }
}
