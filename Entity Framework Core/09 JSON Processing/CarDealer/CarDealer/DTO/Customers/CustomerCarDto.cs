using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CarDealer.DTO.Customers
{
    public class CustomerCarDto
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("boughtCars")]
        public int BoughtCars { get; set; }
        [JsonProperty("spentMoney")]
        public decimal SpentMoney { get; set; }
    }
}
