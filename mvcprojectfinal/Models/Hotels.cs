using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace mvcprojectfinal.Models
{
    public class Hotels
    {
        public int id { get; set; }
        public string name { get; set; }
        public string Location { get; set; }
        public string? Description { get; set; }


        public virtual List<FeedBack>? feedBacks { get; set; }

        [ForeignKey("City")]
        public int CityID { get; set; }

        public virtual City? City { get; set; }
        [ForeignKey("Fun")]
        public int FunID { get; set; }
        public List<Images>? images { get; set; }
        public virtual Fun? Fun { get; set; } = new Fun();
        public  List<Room>? Rooms { get; set; }
      
    }
}
