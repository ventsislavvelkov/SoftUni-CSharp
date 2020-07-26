using Newtonsoft.Json;

namespace CarDealer.DTO.Sales
{
    public class SalesDto
    {
        [JsonProperty("car")]
        public CarDto Car { get; set; }

        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        public string Discount { get; set; }

        [JsonProperty("price")]
        public string Price { get; set; }

        [JsonProperty("priceWithDiscount")]
        public string PriceWithDiscount { get; set; }
    }
}
