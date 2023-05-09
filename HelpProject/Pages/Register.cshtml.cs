using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelpProject.Model;
using HelpProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HelpProject.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;
        [TempData]
        public string Message { get; set; }
        [TempData]
        public string LogedUser { get; set; }


        public RegisterModel(ILogger<RegisterModel> logger, JsonFileUserService userService)
        {
            _logger = logger;
            UserService = userService;
        }

        public JsonFileUserService UserService { get; set; }
        public IEnumerable<User> Users { get; private set; }
        public new User User { get; set; }

        public void OnGet() => Users = UserService.GetUsers();

        [BindProperty]
        public User user { get; set; }

        public IActionResult OnPostUserRegisterAsync()
        {
            Console.WriteLine("The request came");
            if (user == null)
            {
                Message = $"Something went wron: User {user.UserName} not created";
                return RedirectToPage("./Register");
            }
                User Duser = UserService.AddUser(user);
                Console.WriteLine("Duser " + Duser);
                if (Duser != null)
                {
                    //ViewBag.username = string.Format("Successfully logged-in", user.UserName);

                    LogedUser = Duser.UserName;
                    return RedirectToPage("/Landing", new { LogedUser });
                    //return RedirectToAction("ThankYou", "Index");
                }
                else
                {
                    Message += $"Something went wrong, User {user.UserName} already exists";
                    return RedirectToPage("./Register");
                }
        }
    }
}
