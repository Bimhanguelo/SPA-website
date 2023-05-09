using HelpProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpProject.Services
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User AuthenticateUser(string username, string passcode);
        public User AddUser(User user);
    }
}
