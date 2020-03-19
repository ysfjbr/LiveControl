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
        public Source[] sources { get; set; }

    }

    class SceneNames
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string[] sources { get; set; }
    }

    class Source
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

    class SSource
    {
        public string message_id { get; set; }
        public string sourceName { get; set; }
        public string sourceType { get; set; }
        public SourceSettings sourceSettings { get; set; }
        public string status { get; set; }
    }

    class SourceSettings
    {
        public string file { get; set; }
        public bool read_from_file { get; set; }
        public Int64 color { get; set; }
        public SFont font { get; set; }
        public string text { get; set; }
        public string playback_behavior { get; set; }
        public string css { get; set; }
        public int height { get; set; }
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
