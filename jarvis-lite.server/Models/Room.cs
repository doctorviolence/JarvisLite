using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace jarvis_lite.server.Models
{
    [DataContract]
    public class Room
    {
        [DataMember] 
        [JsonProperty("name")] 
        public string Name { get; set; }

        [DataMember]
        [JsonProperty("temperature")]
        public float Temperature { get; set; }

        [DataMember]
        [JsonProperty("humidity")]
        public float Humidity { get; set; }

        [DataMember] 
        [JsonProperty("date")] 
        public string Date { get; set; }
        
        private House House { get; set; }  

        public Room()
        {
        }

        public Room(string name)
        {
            Name = name;
        }

        public Room(string name, float temperature, float humidity, string date, House house)
        {
            Name = name;
            Temperature = temperature;
            Humidity = humidity;
            Date = date;
            House = house;
        }
    }
}