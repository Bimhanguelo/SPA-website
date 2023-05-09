using HelpProject.Model;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelpProject.Services
{
    public class JsonFileUserService : IUserService
    {
        

        public JsonFileUserService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "users.json");

        public List<User> GetUsers()
        {
            // var jsonFileReader = File.OpenText(JsonFileName);
            List<User> source = new List<User>();
            using (StreamReader r = new StreamReader(JsonFileName))
            {
                string jsonRead = r.ReadToEnd();
                source = JsonSerializer.Deserialize<List<User>>(jsonRead, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            return source;
        }

        public User AddUser(User user)
        {
            try
            {
                var Dusers = GetUsers();
                var isUser = false;
                foreach (User u in Dusers)
                {
                    if (u.UserName.Equals(user.UserName))
                    {
                        isUser = true;
                    }
                }
              
                if (!isUser)
                {
                    Dusers.Add(user);
                    string Duser = "[" + string.Join(",", Dusers) + "]";
                    using (StreamWriter outputFile = new StreamWriter(JsonFileName))
                    {
                        outputFile.WriteLine(Duser);
                    }
                    // File.WriteAllText(JsonFileName, Duser);
                    return user;
                }
                
            }catch(Exception ex)
            {
               Console.WriteLine(ex.StackTrace);
            }
            return null;
        }

        public User AuthenticateUser(string username, string password)
        {
            var users = GetUsers();
            try
            {
                var user = users.First(x => x.UserName == username);
                Console.WriteLine("User" + user);
                if (user != null && user.Password == password)
                {
                    return user;
                }
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);

            }

            return null;
        }

    }
}
