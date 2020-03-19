using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveControl
{
    class StreamStatus
    {
        public bool preview_only { get; set; }
        public bool recording { get; set; }
        public bool recording_paused { get; set; }
        public bool streaming { get; set; }
        public string message_id { get; set; }
        public string status { get; set; }
        public string stream_timecode { get; set; }
        public string rec_timecode { get; set; }
    }
}
