using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSServ
{
    class source
    {
        public int id { get; set; }
        public string Name { get; set; }
        public bool locked { get; set; }
        public bool render { get; set; }
        public string type { get; set; }
        public double source_cx { get; set; }
        public double source_cy { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public double cx { get; set; }
        public double cy { get; set; }
        public double volume { get; set; }
    }
}
