using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSServ
{
    class Scenelist
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
                    foreach (Source sr in s.sources)
                    {
                        strs.Add(sr.Name);
                    }
                }
            }
            return strs;
        }
    }

    class SceneListNames
    {
        public string current_scene { get; set; }
        public string message_id { get; set; }
        public SceneNames[] scenes { get; set; }
        public string status { get; set; }

        public SceneListNames(Scenelist sl)
        {
            SceneNames[] sn = new SceneNames[sl.scenes.Length];
            for (int i = 0; i < sn.Length; i++)
            {
                sn[i] = new SceneNames();
                sn[i].Name = sl.scenes[i].Name;

                string[] scr = new string[sl.scenes[i].sources.Length];
                for (int j = 0; j < sl.scenes[i].sources.Length; j++)
                {
                    scr[j] = ""+sl.scenes[i].sources[j].Name;
                }
                sn[i].sources = scr;
            }

            current_scene = sl.current_scene;
            scenes = sn;
            status = sl.status;
        }
    }

    
}
