using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.models
{
    public class committees
    {
        public string Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string chairman { get; set; }
        public string viceChairman { get; set; }
        public string terms { get; set; }
        public List<String> members { get; set; }

    }
}
