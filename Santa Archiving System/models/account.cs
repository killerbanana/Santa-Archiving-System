using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.models
{
    class account
    {
        public int ID { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string image { get; set; }
        public string gender { get; set; }
        public string birthday { get; set; }
        public string address { get; set; }
        public string contactNo { get; set; }
        public string accountRole { get; set; }
        public string privilege { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string confirmPassword { get; set; }
    }
}
