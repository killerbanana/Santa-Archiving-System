using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.models
{
    public class EmailContent
    {
        public int Id { get; set; }
        public string DocType { get; set; }
        public string Type { get; set; }
        public string FileName { get; set;}
    }
}
