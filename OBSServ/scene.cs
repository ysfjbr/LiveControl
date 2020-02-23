using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSServ
{
    class scene
    {
        public int id { get; set; }
        public string Name { get; set; }
        public source[] sources { get; set; }

    }

    class SceneNames
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string[] sources { get; set; }
    }
}
