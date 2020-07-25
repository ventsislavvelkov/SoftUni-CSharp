using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Newtonsoft.Json;

namespace CarDealer.DTO.Customers
{
    public class GetOrderedCustomersDTO
    {
        [JsonProperty("Name")]
        public string Name { get; set; }
        [JsonProperty("BirthDate")]
        public string BirthDate { get; set; }
        [JsonProperty("IsYoungDriver")]
        public bool IsYoungDriver { get; set; }
    }
}
