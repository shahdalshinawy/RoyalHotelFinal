using System.ComponentModel.DataAnnotations;

namespace mvcprojectfinal.VM
{
    public class RegistrationVM
    {
        [Required]
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public string Gender { get; set; }
        public int age { get; set; }
        

        [DataType(DataType.Password)]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
