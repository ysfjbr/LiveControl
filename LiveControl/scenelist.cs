using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

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
            List<string> strs = new List<string>();
            foreach (scene s in this.scenes)
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

    class scene
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string[] sources { get; set; }

    }

    class source1
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

    class Source
    {
        public Source sourceFromJSON(string json)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                return js.Deserialize<Source>(json);
            }
            catch(Exception ex) { return null; }
        }
        public string message_id { get; set; }
        public string sourceName { get; set; }
        public string sourceType { get; set; }
        public SourceSettings sourceSettings { get; set; }
        public string status { get; set; }
    }

    class SourceSettings
    {
        public string file { get; set; }
        public Int64 color { get; set; }
        public SFont font { get; set; }
        public string text { get; set; }
        public string playback_behavior { get; set; }
        public string css { get; set; }
        public int  height { get; set; }
        public int width { get; set; }
        public bool reroute_audio { get; set; }
        public string url { get; set; }
        public Playlist[] playlist { get; set; }

    }

    class SFont
    {
        public string face { get; set; }
        public string style { get; set; }
        public int flags { get; set; }
        public int size { get; set; }

    }

    class Playlist
    {
        public bool hidden { get; set; }
        public bool selected { get; set; }
        public string value { get; set; }
    }
}
