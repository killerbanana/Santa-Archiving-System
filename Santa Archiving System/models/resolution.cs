using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santa_Archiving_System.models
{
    public class Resolution
    {
        public int Id { get; set; }
        public string ResolutionNo { get; set; }
        public string Series { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Files { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Tag { get; set; }
        public string Reading { get; set; }
        public bool QuickAction { get; set; }
        public string Created { get; set; }
    }
}
