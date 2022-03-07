namespace Disaster_information_viewer
{
    public class Level_json
    {
        public int G { get; set; }
        public int Y { get; set; }
        public int R { get; set; }
        public int L { get; set; }
    }
    public class RTC_JSON
    {
        public int Distance { get; set; }
        public long Origin_time { get; set; }
        public int Depth { get; set; }
    }
    public class Tokens_JSON
    {
        public string ConsumerKey { get; set; }
        public string ConsumerSecret { get; set; }
        public string AccessToken { get; set; }
        public string AccessSecret { get; set; }
    }
}
