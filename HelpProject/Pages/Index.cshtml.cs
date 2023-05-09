using HelpProject.Model;
using HelpProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [TempData]
        public string Message { get; set; }

        public IndexModel(ILogger<IndexModel> logger, JsonFileUserService userService)
        {
            _logger = logger;
            UserService = userService;
        }

        public JsonFileUserService UserService { get; }
        public IEnumerable<User> Users { get; private set; }
        public UserLogin UserLogin { get; set; }

        public void OnGet() => Users = UserService.GetUsers();

        [BindProperty]
        public UserLogin userLogin { get; set; }

        public IActionResult OnPostUserLoginAsync()
        {
            Console.WriteLine("The request came");

            var Duser = UserService.AuthenticateUser(userLogin.UserName, userLogin.password);

            if (Duser != null && Duser.Password == userLogin.password)
            {

                string logedUser = Duser.UserName;
                return RedirectToPage("/Landing", new { logedUser });
                //return RedirectToAction("ThankYou", "Index");
                // Message = userLogin.UserName + " " + userLogin.password;
                // return RedirectToPage("/Index");
            }
            else
            {
                Message = $"Something went wrong User {userLogin.UserName} dont exit or password not correct";
                return RedirectToPage("./Index");
            }
        }
    }
}
