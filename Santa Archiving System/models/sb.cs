using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.models
{
    public class Sb
    {
        public string Id { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string suffix { get; set; }
        public string title { get; set; }
        public string position { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public string address { get; set; }
        public string contactNo { get; set; }
        public List<String> committee { get; set; }
        public string terms { get; set; }
        public string image { get; set; }
    }
}
