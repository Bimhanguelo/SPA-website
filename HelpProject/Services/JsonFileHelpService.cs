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
    public class JsonFileHelpService : IHelpService
    {
        public JsonFileHelpService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }
        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "data", "help.json");

         public List<Help> GetHelps()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<List<Help>>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public List<Help> GetUserHelp(string userName)
        {
            List<Help> userHelp = new List<Help>();
            try {
                var helps = GetHelps();
                foreach (Help hp in helps)
                {
                    if (hp.UserName == userName)
                    {
                        userHelp.Add(hp);
                    }
                }
                return userHelp;
            } catch (InvalidOperationException ioe) {
                Console.WriteLine("Error: " + ioe.Message);
            }
            return null;
        }

        public Help PostHelp(Help help)
        {
            var helps = GetHelps();
            helps.Add(help);
            string newHelp = "[ " + String.Join(",", helps) + "]";
            File.WriteAllText(JsonFileName, newHelp);
            return help;

        }

        public void AddReply(string helpId, Reply reply)
        {
            var helps = GetHelps();

            if (helps.First(x => x.Id == helpId).Response == null)
            {
                helps.First(x => x.Id == helpId).Response = new Reply[] { reply };
            }
            else
            {
                var responses = helps.First(x => x.Id == helpId).Response.ToList();
                responses.Add(reply);
                helps.First(x => x.Id == helpId).Response = responses.ToArray();
            }

            using var outputStream = File.OpenWrite(JsonFileName);

            JsonSerializer.Serialize<IEnumerable<Help>>(
                new Utf8JsonWriter(outputStream, new JsonWriterOptions
                {
                    SkipValidation = true,
                    Indented = true
                }),
                helps
            );
        }
    }

}

  
