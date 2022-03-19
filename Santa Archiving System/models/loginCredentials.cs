using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.models
{
    class loginCredentials
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string image { get; set; }
        public string accountRole { get; set; }
        public List<String> privilege { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool status { get; set; }

    }
}
