using System.Numerics;
using Newtonsoft.Json;

namespace CarDealer.DTO.Cars
{
    public class GetCarsFromMakeToyotaDTO
    {
        [JsonProperty("Id")]
        public int Id { get; set; }
        [JsonProperty("Make")]
        public string Make { get; set; }
        [JsonProperty("Model")]
        public string Model { get; set; }
        [JsonProperty("TravelledDistance")]
        public long TravelledDistance { get; set; }
    }
}
