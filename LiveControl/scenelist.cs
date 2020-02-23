using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveControl
{
    class scenelist
    {
        public string current_scene { get; set; }
        public string message_id { get; set; }
        public scene[] scenes { get; set; }
        public string status { get; set; }

        public List<string> getScenes()
        {
            List<string> strs=new List<string>();
            foreach(scene s in this.scenes)
            {
                strs.Add(s.Name);
            }
            return strs;
        }

        public List<string> getSources(string sceneName)
        {
            List<string> strs = new List<string>();
            foreach (scene s in this.scenes)
            {
                if (s.Name == sceneName)
                {
                    /*foreach (source sr in s.sources)
                    {
                        strs.Add(sr.Name);
                    }*/
                    foreach (string sr in s.sources)
                    {
                        strs.Add(sr);
                    }

                }
                
            }
            return strs;
        }
    }

    
}
