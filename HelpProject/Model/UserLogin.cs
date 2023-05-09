using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpProject.Model
{
    public class UserLogin
    {
        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "Please Enter Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please Enter Password"), StringLength(12)]
        [Display(Name = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
