using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OBSServ
{
    public partial class SourceList
    {
        [JsonProperty("message-id")]
        public string MessageId { get; set; }

        [JsonProperty("sources")]
        public SLSource[] Sources { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class SLSource
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("typeId")]
        public string TypeId { get; set; }
    }

    public enum TypeEnum { Input };

    public partial class SourceList
    {
        public static SourceList FromJson(string json) => JsonConvert.DeserializeObject<SourceList>(json, Converter.Settings);
    }

    public partial class SlsSettings
    {
        [JsonProperty("message-id")]
        public string MessageId { get; set; }

        [JsonProperty("sourceName")]
        public string SourceName { get; set; }

        [JsonProperty("sourceSettings")]
        public SLSourceSettings SourceSettings { get; set; }

        [JsonProperty("sourceType")]
        public string SourceType { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public partial class SLSourceSettings
    {
        [JsonProperty("height")]
        public double Height { get; set; }

        [JsonProperty("reroute_audio")]
        public bool RerouteAudio { get; set; }

        [JsonProperty("url")]
        public object Url { get; set; }

        [JsonProperty("width")]
        public double Width { get; set; }

        [JsonProperty("file")]
        public object File { get; set; }

        [JsonProperty("read_from_file")]
        public bool ReadFromFile { get; set; }

        [JsonProperty("color")]
        public double Color { get; set; }

        [JsonProperty("font")]
        public object Font { get; set; }

        [JsonProperty("text")]
        public object Text { get; set; }

        [JsonProperty("playback_behavior")]
        public string PlaybackBehavior { get; set; }

        [JsonProperty("css")]
        public object Css { get; set; }

        [JsonProperty("playlist")]
        public SLPlaylist[] Playlist { get; set; }
    }

    public partial class SLPlaylist
    {
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class SlsSettings
    {
        public static SlsSettings FromJson(string json) => JsonConvert.DeserializeObject<SlsSettings>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SlsSettings self) => JsonConvert.SerializeObject(self, Converter.Settings);
        public static string ToJson(this SLSourceSettings self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    

    internal class TypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeEnum) || t == typeof(TypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "input")
            {
                return TypeEnum.Input;
            }
            throw new Exception("Cannot unmarshal type TypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeEnum)untypedValue;
            if (value == TypeEnum.Input)
            {
                serializer.Serialize(writer, "input");
                return;
            }
            throw new Exception("Cannot marshal type TypeEnum");
        }

        public static readonly TypeEnumConverter Singleton = new TypeEnumConverter();
    }
}
