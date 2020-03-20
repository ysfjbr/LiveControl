using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Drawing;

namespace LiveControl
{
    public partial class Obs
    {
        [JsonProperty("AuxAudioDevice1")]
        public AudioDevice1 AuxAudioDevice1 { get; set; }

        [JsonProperty("DesktopAudioDevice1")]
        public AudioDevice1 DesktopAudioDevice1 { get; set; }

        [JsonProperty("current_program_scene")]
        public string CurrentProgramScene { get; set; }

        [JsonProperty("current_scene")]
        public string CurrentScene { get; set; }

        [JsonProperty("current_transition")]
        public string CurrentTransition { get; set; }

        [JsonProperty("groups")]
        public List<object> Groups { get; set; }

        [JsonProperty("modules")]
        public Modules Modules { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("preview_locked")]
        public bool PreviewLocked { get; set; }

        [JsonProperty("quick_transitions")]
        public List<object> QuickTransitions { get; set; }

        [JsonProperty("saved_projectors")]
        public List<object> SavedProjectors { get; set; }

        [JsonProperty("scaling_enabled")]
        public bool ScalingEnabled { get; set; }

        [JsonProperty("scaling_level")]
        public double ScalingLevel { get; set; }

        [JsonProperty("scaling_off_x")]
        public double ScalingOffX { get; set; }

        [JsonProperty("scaling_off_y")]
        public double ScalingOffY { get; set; }

        [JsonProperty("scene_order")]
        public List<SceneOrder> SceneOrder { get; set; }

        [JsonProperty("sources")]
        public List<Source> Sources { get; set; }

        [JsonProperty("transition_duration")]
        public double TransitionDuration { get; set; }

        [JsonProperty("transitions")]
        public List<object> Transitions { get; set; }


        public bool Ready { get; set; }
        public bool OnAir { get; set; }

        public Image onAirImg()
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
            return  img ;
        }
    }

    public partial class AudioDevice1
    {
        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("deinterlace_field_order")]
        public double DeinterlaceFieldOrder { get; set; }

        [JsonProperty("deinterlace_mode")]
        public double DeinterlaceMode { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("flags")]
        public double Flags { get; set; }

        [JsonProperty("hotkeys")]
        public Hotkeys Hotkeys { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mixers")]
        public double Mixers { get; set; }

        [JsonProperty("monitoring_type")]
        public double MonitoringType { get; set; }

        [JsonProperty("muted")]
        public bool Muted { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("prev_ver")]
        public double PrevVer { get; set; }

        [JsonProperty("private_settings")]
        public PrivateSettings PrivateSettings { get; set; }

        [JsonProperty("push-to-mute")]
        public bool PushToMute { get; set; }

        [JsonProperty("push-to-mute-delay")]
        public double PushToMuteDelay { get; set; }

        [JsonProperty("push-to-talk")]
        public bool PushToTalk { get; set; }

        [JsonProperty("push-to-talk-delay")]
        public double PushToTalkDelay { get; set; }

        [JsonProperty("settings")]
        public AuxAudioDevice1Settings Settings { get; set; }

        [JsonProperty("sync")]
        public double Sync { get; set; }

        [JsonProperty("versioned_id")]
        public string VersionedId { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }
    }

    public partial class Hotkeys
    {
        [JsonProperty("libobs.mute")]
        public List<object> LibobsMute { get; set; }

        [JsonProperty("libobs.push-to-mute")]
        public List<object> LibobsPushToMute { get; set; }

        [JsonProperty("libobs.push-to-talk")]
        public List<object> LibobsPushToTalk { get; set; }

        [JsonProperty("libobs.unmute")]
        public List<object> LibobsUnmute { get; set; }
    }

    public partial class PrivateSettings
    {
    }

    public partial class AuxAudioDevice1Settings
    {
        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
    }

    public partial class Modules
    {
        [JsonProperty("auto-scene-switcher")]
        public AutoSceneSwitcher AutoSceneSwitcher { get; set; }

        [JsonProperty("captions")]
        public Captions Captions { get; set; }

        [JsonProperty("output-timer")]
        public OutputTimer OutputTimer { get; set; }

        [JsonProperty("scripts-tool")]
        public List<object> ScriptsTool { get; set; }
    }

    public partial class AutoSceneSwitcher
    {
        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("interval")]
        public double Interval { get; set; }

        [JsonProperty("non_matching_scene")]
        public string NonMatchingScene { get; set; }

        [JsonProperty("switch_if_not_matching")]
        public bool SwitchIfNotMatching { get; set; }

        [JsonProperty("switches")]
        public List<object> Switches { get; set; }
    }

    public partial class Captions
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("lang_id")]
        public double LangId { get; set; }

        [JsonProperty("provider")]
        public string Provider { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }
    }

    public partial class OutputTimer
    {
        [JsonProperty("autoStartRecordTimer")]
        public bool AutoStartRecordTimer { get; set; }

        [JsonProperty("autoStartStreamTimer")]
        public bool AutoStartStreamTimer { get; set; }

        [JsonProperty("pauseRecordTimer")]
        public bool PauseRecordTimer { get; set; }

        [JsonProperty("recordTimerHours")]
        public double RecordTimerHours { get; set; }

        [JsonProperty("recordTimerMinutes")]
        public double RecordTimerMinutes { get; set; }

        [JsonProperty("recordTimerSeconds")]
        public double RecordTimerSeconds { get; set; }

        [JsonProperty("streamTimerHours")]
        public double StreamTimerHours { get; set; }

        [JsonProperty("streamTimerMinutes")]
        public double StreamTimerMinutes { get; set; }

        [JsonProperty("streamTimerSeconds")]
        public double StreamTimerSeconds { get; set; }
    }

    public partial class SceneOrder
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class Source
    {
        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("deinterlace_field_order")]
        public double DeinterlaceFieldOrder { get; set; }

        [JsonProperty("deinterlace_mode")]
        public double DeinterlaceMode { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("flags")]
        public double Flags { get; set; }

        [JsonProperty("hotkeys")]
        public Dictionary<string, List<object>> Hotkeys { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mixers")]
        public double Mixers { get; set; }

        [JsonProperty("monitoring_type")]
        public double MonitoringType { get; set; }

        [JsonProperty("muted")]
        public bool Muted { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("prev_ver")]
        public double PrevVer { get; set; }

        [JsonProperty("private_settings")]
        public PrivateSettings PrivateSettings { get; set; }

        [JsonProperty("push-to-mute")]
        public bool PushToMute { get; set; }

        [JsonProperty("push-to-mute-delay")]
        public double PushToMuteDelay { get; set; }

        [JsonProperty("push-to-talk")]
        public bool PushToTalk { get; set; }

        [JsonProperty("push-to-talk-delay")]
        public double PushToTalkDelay { get; set; }

        [JsonProperty("settings")]
        public SourceSettings Settings { get; set; }

        [JsonProperty("sync")]
        public double Sync { get; set; }

        [JsonProperty("versioned_id")]
        public string VersionedId { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public List<Filter> Filters { get; set; }
    }

    public partial class Filter
    {
        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("deinterlace_field_order")]
        public double DeinterlaceFieldOrder { get; set; }

        [JsonProperty("deinterlace_mode")]
        public double DeinterlaceMode { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("flags")]
        public double Flags { get; set; }

        [JsonProperty("hotkeys")]
        public PrivateSettings Hotkeys { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("mixers")]
        public double Mixers { get; set; }

        [JsonProperty("monitoring_type")]
        public double MonitoringType { get; set; }

        [JsonProperty("muted")]
        public bool Muted { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("prev_ver")]
        public double PrevVer { get; set; }

        [JsonProperty("private_settings")]
        public PrivateSettings PrivateSettings { get; set; }

        [JsonProperty("push-to-mute")]
        public bool PushToMute { get; set; }

        [JsonProperty("push-to-mute-delay")]
        public double PushToMuteDelay { get; set; }

        [JsonProperty("push-to-talk")]
        public bool PushToTalk { get; set; }

        [JsonProperty("push-to-talk-delay")]
        public double PushToTalkDelay { get; set; }

        [JsonProperty("settings")]
        public FilterSettings Settings { get; set; }

        [JsonProperty("sync")]
        public double Sync { get; set; }

        [JsonProperty("versioned_id")]
        public string VersionedId { get; set; }

        [JsonProperty("volume")]
        public double Volume { get; set; }
    }

    public partial class FilterSettings
    {
        [JsonProperty("speed_x")]
        public double SpeedX { get; set; }
    }

    public partial class SourceSettings
    {
        [JsonProperty("height", NullValueHandling = NullValueHandling.Ignore)]
        public double? Height { get; set; }

        [JsonProperty("reroute_audio", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RerouteAudio { get; set; }

        [JsonProperty("width", NullValueHandling = NullValueHandling.Ignore)]
        public double? Width { get; set; }

        [JsonProperty("color", NullValueHandling = NullValueHandling.Ignore)]
        public double? Color { get; set; }

        [JsonProperty("file", NullValueHandling = NullValueHandling.Ignore)]
        public string File { get; set; }

        [JsonProperty("read_from_file", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ReadFromFile { get; set; }

        [JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
        public string Text { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("custom_size", NullValueHandling = NullValueHandling.Ignore)]
        public bool? CustomSize { get; set; }

        [JsonProperty("id_counter", NullValueHandling = NullValueHandling.Ignore)]
        public double? IdCounter { get; set; }

        [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
        public List<Item> Items { get; set; }

        [JsonProperty("font", NullValueHandling = NullValueHandling.Ignore)]
        public oFont Font { get; set; }

        [JsonProperty("{text", NullValueHandling = NullValueHandling.Ignore)]
        public string SettingsText { get; set; }

        [JsonProperty("playback_behavior", NullValueHandling = NullValueHandling.Ignore)]
        public string PlaybackBehavior { get; set; }

        [JsonProperty("playlist", NullValueHandling = NullValueHandling.Ignore)]
        public List<Playlist> Playlist { get; set; }

        [JsonProperty("shutdown", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Shutdown { get; set; }

        [JsonProperty("clear_on_media_end", NullValueHandling = NullValueHandling.Ignore)]
        public bool? ClearOnMediaEnd { get; set; }

        [JsonProperty("input", NullValueHandling = NullValueHandling.Ignore)]
        public string Input { get; set; }

        [JsonProperty("is_local_file", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsLocalFile { get; set; }

        [JsonProperty("restart_on_activate", NullValueHandling = NullValueHandling.Ignore)]
        public bool? RestartOnActivate { get; set; }
    }

    public partial class oFont
    {
        [JsonProperty("face")]
        public string Face { get; set; }

        [JsonProperty("flags")]
        public double Flags { get; set; }

        [JsonProperty("size")]
        public double Size { get; set; }

        [JsonProperty("style")]
        public string Style { get; set; }
    }

    public partial class Item
    {
        [JsonProperty("align")]
        public double Align { get; set; }

        [JsonProperty("bounds")]
        public Bounds Bounds { get; set; }

        [JsonProperty("bounds_align")]
        public double BoundsAlign { get; set; }

        [JsonProperty("bounds_type")]
        public double BoundsType { get; set; }

        [JsonProperty("crop_bottom")]
        public double CropBottom { get; set; }

        [JsonProperty("crop_left")]
        public double CropLeft { get; set; }

        [JsonProperty("crop_right")]
        public double CropRight { get; set; }

        [JsonProperty("crop_top")]
        public double CropTop { get; set; }

        [JsonProperty("group_item_backup")]
        public bool GroupItemBackup { get; set; }

        [JsonProperty("id")]
        public double Id { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("pos")]
        public Bounds Pos { get; set; }

        [JsonProperty("private_settings")]
        public PrivateSettings PrivateSettings { get; set; }

        [JsonProperty("rot")]
        public double Rot { get; set; }

        [JsonProperty("scale")]
        public Bounds Scale { get; set; }

        [JsonProperty("scale_filter")]
        public ScaleFilter ScaleFilter { get; set; }

        [JsonProperty("visible")]
        public bool Visible { get; set; }
    }

    public partial class Bounds
    {
        [JsonProperty("x")]
        public double X { get; set; }

        [JsonProperty("y")]
        public double Y { get; set; }
    }

    public partial class Playlist
    {
        [JsonProperty("hidden")]
        public bool Hidden { get; set; }

        [JsonProperty("selected")]
        public bool Selected { get; set; }

        [JsonProperty("value")]
        public Uri Value { get; set; }
    }

    public enum ScaleFilter { Disable };

    public partial class Obs
    {
        public static Obs FromJson(string json) => JsonConvert.DeserializeObject<Obs>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Obs self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
        {
            ScaleFilterConverter.Singleton,
            new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
        },
        };
    }

    internal class ScaleFilterConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ScaleFilter) || t == typeof(ScaleFilter?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "disable")
            {
                return ScaleFilter.Disable;
            }
            throw new Exception("Cannot unmarshal type ScaleFilter");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ScaleFilter)untypedValue;
            if (value == ScaleFilter.Disable)
            {
                serializer.Serialize(writer, "disable");
                return;
            }
            throw new Exception("Cannot marshal type ScaleFilter");
        }

        public static readonly ScaleFilterConverter Singleton = new ScaleFilterConverter();
    }
}
