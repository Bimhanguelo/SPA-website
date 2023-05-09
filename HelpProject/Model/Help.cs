using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HelpProject.Model
{
    public class Help
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Please Enter Subject")]
        [Display(Name = "Please Enter Subject")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Please Enter Detail")]
        [Display(Name = "Please Enter Detail")]
        public string Detail { get; set; }
        [Required(ErrorMessage = "Please Enter Username")]
        [Display(Name = "Please Enter Username")]
        public string UserName { get; set; }
        public Reply[] Response { get; set; }
        public string TimeStamp { get; set; } = DateTime.Now.ToString();

        public override string ToString() => System.Text.Json.JsonSerializer.Serialize<Help>(this);
    }
}
