using System.Collections.Generic;

namespace Disaster_information_viewer
{
    /*public class EEW_iedred_json
    {
        public class Title
        {
            public string String { get; set; }//緊急地震速報（予報）

            public string Detail { get; set; }//"キャンセル（取り消し）情報" or "マグニチュード、最大予測震度及び主要動到達予測時刻の緊急地震速報（発表パターン3： グリッドサーチ法、EPOS自動処理手法）"
        }
        public class AnnouncedTime
        {
            public string String { get; set; }
        }
        public class OriginTime
        {
            public string String { get; set; }
        }
        public class Depth
        {
            public int Int { get; set; }
        }
        public class Location
        {
            public double Lat { get; set; }
            public double Long { get; set; }
            public Depth Depth { get; set; }
        }
        public class Magnitude
        {
            public double Float { get; set; }
        }
        public class Hypocenter
        {
            public string Name { get; set; }
            public bool IsAssumption { get; set; }//plum
            public Location Location { get; set; }
            public Magnitude Magnitude { get; set; }
        }
        public class MaxIntensity
        {
            public string String { get; set; }
        }
        public class WarnForecast
        {

            public string District { get; set; }
        }

        public class EEW_iedred_JSON
        {

            public Title Title { get; set; }
            public AnnouncedTime AnnouncedTime { get; set; }
            public OriginTime OriginTime { get; set; }
            public Location Location { get; set; }
            public Magnitude Magnitude { get; set; }
            public Depth Depth { get; set; }
            public WarnForecast District { get; set; }
            public Hypocenter Hypocenter { get; set; }
            public MaxIntensity MaxIntensity { get; set; }
            public int Serial { get; set; }//報
            public bool Warn { get; set; }
        }
    }*/

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Title
    {
        public int Code { get; set; }
        public string String { get; set; }
        public string Detail { get; set; }
    }

    public class Source
    {
        public int Code { get; set; }
        public string String { get; set; }
    }

    public class Status
    {
        public string Code { get; set; }
        public string String { get; set; }
        public string Detail { get; set; }
    }

    public class AnnouncedTime
    {
        public string String { get; set; }
        public int UnixTime { get; set; }
        public string RFC1123 { get; set; }
    }

    public class OriginTime
    {
        public string String { get; set; }
        public int UnixTime { get; set; }
        public string RFC1123 { get; set; }
    }

    public class Type
    {
        public int Code { get; set; }
        public string String { get; set; }
        public string Detail { get; set; }
    }

    public class Depth
    {
        public int Int { get; set; }
        public string String { get; set; }
        public int Code { get; set; }
    }

    public class Location
    {
        public double Lat { get; set; }
        public double Long { get; set; }
        public Depth Depth { get; set; }
    }

    public class Magnitude
    {
        public double Float { get; set; }
        public string String { get; set; }
        public string LongString { get; set; }
        public int Code { get; set; }
    }

    public class Epicenter
    {
        public int Code { get; set; }
        public string String { get; set; }
        public int Rank2 { get; set; }
        public string String2 { get; set; }
    }

    public class Accuracy
    {
        public Epicenter Epicenter { get; set; }
        public Depth Depth { get; set; }
        public Magnitude Magnitude { get; set; }
        public int NumberOfMagnitudeCalculation { get; set; }
    }

    public class Hypocenter
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public bool IsAssumption { get; set; }
        public Location Location { get; set; }
        public Magnitude Magnitude { get; set; }
        public Accuracy Accuracy { get; set; }
        public bool IsSea { get; set; }
    }

    public class MaxIntensity
    {
        public string From { get; set; }
        public string To { get; set; }
        public string String { get; set; }
        public string LongString { get; set; }
    }

    public class WarnForecast
    {
        public Hypocenter Hypocenter { get; set; }
        public List<string> District { get; set; }
        public List<string> LocalAreas { get; set; }
        public List<string> Regions { get; set; }
    }

    public class Reason
    {
        public int Code { get; set; }
        public string String { get; set; }
    }

    public class Change
    {
        public int Code { get; set; }
        public string String { get; set; }
        public Reason Reason { get; set; }
    }

    public class Option
    {
        public Change Change { get; set; }
    }

    public class Intensity
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string Description { get; set; }
    }

    public class Arrival
    {
        public bool Flag { get; set; }
        public string Condition { get; set; }
        public string Time { get; set; }
    }

    public class Forecast
    {
        public Intensity Intensity { get; set; }
        public bool Warn { get; set; }
        public Arrival Arrival { get; set; }
    }

    public class EEW_iedred_JSON
    {
        public string ParseStatus { get; set; }
        public Title Title { get; set; }
        public Source Source { get; set; }
        public Status Status { get; set; }
        public AnnouncedTime AnnouncedTime { get; set; }
        public OriginTime OriginTime { get; set; }
        public string EventID { get; set; }
        public Type Type { get; set; }
        public int Serial { get; set; }
        public Hypocenter Hypocenter { get; set; }
        public MaxIntensity MaxIntensity { get; set; }
        public bool Warn { get; set; }
        public WarnForecast WarnForecast { get; set; }
        public Option Option { get; set; }
        public List<Forecast> Forecast { get; set; }
        public string OriginalText { get; set; }
    }

}