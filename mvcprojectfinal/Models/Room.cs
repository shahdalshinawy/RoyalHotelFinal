using System.ComponentModel.DataAnnotations.Schema;

namespace mvcprojectfinal.Models
{
    public class Room
    {
        public int ID { get; set; }
       
        public string Type { get; set; }

        public string View { get; set; }
        public int price { get; set; }  
        public bool IsReserved { get; set; }
        public bool IsHavingAirconditioning { get; set; }
        public bool IsHavingTv { get; set; }

        [ForeignKey("hotels")]
        public int? HotelId { get; set; }
        public Hotels? hotels { get; set; }

        public List<RoomVisits> onceReserved { get; set; }    

    }
}
