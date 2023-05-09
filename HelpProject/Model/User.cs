using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpProject.Model
{
    public class User
    {
        [Required(ErrorMessage = "Please Enter FirstName")]
        [Display(Name = "Please Enter FirstName")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter LastName")]
        [Display(Name = "Please Enter Username")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "Please Enter Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter Password"), StringLength(12)]
        [MinLength(6)]
        [Display(Name = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public override string ToString() => System.Text.Json.JsonSerializer.Serialize<User>(this);
    }
}
