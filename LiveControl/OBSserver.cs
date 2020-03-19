using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace LiveControl
{
    class OBSserver
    {
        public string Name { get; set; }
        public bool Ready { get; set; }
        public bool OnAir { get; set; }

        public OBSserver(string name,bool ready , bool onair)
        {
            Name = name;
            Ready = ready;
            OnAir = onair;
        }

        public object[] getRow()
        {
            Image img = null;
            if (OnAir)
            {
                img = new Bitmap(Properties.Resources.onair);
            }
            else
            {
                img = new Bitmap(Properties.Resources.onair1);
            }
            return new object[] { this.Name, this.Ready.ToString(), img };
        }
    }
}
