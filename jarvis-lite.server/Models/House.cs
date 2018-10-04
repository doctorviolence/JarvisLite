using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace jarvis_lite.server.Models
{
    [DataContract]
    public class House
    {
        [DataMember] 
        [JsonProperty("houseId")] 
        public string HouseId { get; set; }
        
        [DataMember] 
        [JsonProperty("rooms")] 
        public List<Room> Rooms { get; set; }

        public House()
        {
        }

        public House(string houseId)
        {
            HouseId = houseId;
        }
    }
}