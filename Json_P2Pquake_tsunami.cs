using Newtonsoft.Json;
using System.Collections.Generic;

namespace Disaster_information_viewer
{

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Area
    {
        public string Grade { get; set; }
        public string Immediate { get; set; }
        public string Name { get; set; }
    }

    public class Issue
    {
        public string Source { get; set; }
        public string Time { get; set; }
        public string Type { get; set; }
    }

    public class JSON_P2P_Tsunami
    {
        public List<Area> Areas { get; set; }
        public bool Cancelled { get; set; }
        public int Code { get; set; }
        public string Created_at { get; set; }
        public string Icd { get; set; }
        public Issue Issue { get; set; }
        public string Time { get; set; }
        [JsonProperty("user-agent")]
        public string UserAgent { get; set; }
        public string ver { get; set; }
    }

}
