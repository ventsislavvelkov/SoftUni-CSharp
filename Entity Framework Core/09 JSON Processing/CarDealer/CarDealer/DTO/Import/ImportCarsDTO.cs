using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CarDealer.DTO.Import
{
   public  class ImportCarsDTO
    {
        [JsonProperty("make")]
        public string Make { get; set; }
        [JsonProperty("model")]
        public string Model { get; set; }
        [JsonProperty("travelledDistance")]
        public long TravelledDistance { get; set; }
        [JsonProperty("partsId")]
        public List<int> PartsId { get; set; }
    }
}
