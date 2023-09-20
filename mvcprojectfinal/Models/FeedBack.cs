using System.ComponentModel.DataAnnotations.Schema;

namespace mvcprojectfinal.Models
{
    public class FeedBack
    {
        public int Id { get; set; }
		public string? name { get; set; }

		[NotMapped]
        public List<string> Reviews { get; set; } = new List<string>();
        public string? comment { get; set; }
    
      
        public virtual AppliacationUser? applicationUser { get; set; }
        [ForeignKey("Hotel")]
        public int? HotelsID { get; set; }
        public virtual Hotels? Hotel { get; set; }
        
    }
}
