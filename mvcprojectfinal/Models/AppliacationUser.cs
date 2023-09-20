using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace mvcprojectfinal.Models
{
    public class AppliacationUser: IdentityUser
    {
        public string Gender { get; set; }
        public int age { get; set; }
       
        public virtual List<Booking> booking { get; set; }

        public virtual List<FeedBack> feedBacks { get; set; }

    }
}
