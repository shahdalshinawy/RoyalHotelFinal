using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvcprojectfinal.Models
{
    public class Images
    {
        public int id { get; set; }//1  //2

		[DisplayName("Image Name")]

		public string source { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }//1.png  //2.pmg

        [ForeignKey("hotels")]
        public int HotelsId { get; set; }
        public Hotels hotels { get; set; }
    }
}
