using HelpProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpProject.Services
{
    interface IHelpService
    {
        public List<Help> GetUserHelp(string username);
        public List<Help> GetHelps();
        public Help PostHelp(Help help);
        public void AddReply(string helpId, Reply reply);
    }
}
