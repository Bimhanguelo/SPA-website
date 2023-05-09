using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpProject.Model
{
    public class Reply
    {
        public string UserName { get; set; }
        public string reply { get; set; }
        public string TimeStamp { get; set; } = DateTime.Now.ToString();

        public override string ToString() => System.Text.Json.JsonSerializer.Serialize<Reply>(this);
    }
}
