using System.ComponentModel.DataAnnotations;

namespace mvcprojectfinal.VM
{
    public class LoginVM
    {
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool rememberMe { get; set; }
    }
}
