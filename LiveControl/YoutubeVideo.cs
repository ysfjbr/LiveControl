using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace LiveControl
{
    class YoutubeVideo
    {
        private const string URL = "https://www.googleapis.com/youtube/v3/videos?part=contentDetails,status";
        private string API_Key = "AIzaSyDl4wcwTv_f-Z70ACZodZOc__3ryTTSfTA";

        public YoutubeVideo Parse(string TVideoID)
        {
            try
            {
                VideoID = TVideoID;
                if (TVideoID.Contains("?"))
                {
                    string[] parms = TVideoID.Split('?')[1].Split('&');
                    foreach(string prm in parms)
                    {
                        if (prm.Split('=')[0].ToLower() == "v")
                            VideoID = prm.Split('=')[1];
                    }
                }
                
                var httpClient = new HttpClient();
                var content = httpClient.GetStringAsync(URL + "&id=" + VideoID + "&key=" + API_Key);
                //MessageBox.Show(content.Result);
                JavaScriptSerializer js = new JavaScriptSerializer();
                YoutubeVideo yt = js.Deserialize<YoutubeVideo>(content.Result);
                
                if(yt.items[0].status.embeddable)
                    return yt;
                else
                    return null;
            }
            catch(Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return null;
            }
        }

        public double getDuration() // in seconds
        {
            try
            {
                TimeSpan ts = XmlConvert.ToTimeSpan(this.items[0].contentDetails.duration);
                return ts.TotalSeconds;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
        public string VideoID { get; set; }
        public string kind { get; set; }
        public string etag { get; set; }
        public PageInfo pageInfo { get; set; }
        public YItems[] items { get; set; }
    }

    class PageInfo
    {
        public int totalResults { get; set; }
        public int resultsPerPage { get; set; }
    }

    class YItems
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
        public ContentDetails contentDetails { get; set; }
        public TStatus status { get; set; }
    }

    class ContentDetails
    {
        public string duration { get; set; }
        public string dimension { get; set; }
        public string definition { get; set; }
        public string caption { get; set; }
        public bool licensedContent { get; set; }
        public string projection { get; set; }
    }

    class TStatus
    {
        public string uploadStatus { get; set; }
        public string privacyStatus { get; set; }
        public string license { get; set; }
        public bool embeddable { get; set; }
        public bool publicStatsViewable { get; set; }
        public bool madeForKids { get; set; }
    }

}
