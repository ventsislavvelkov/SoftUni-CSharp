namespace FastFood.Data.Models
{
    using FastFood.Data.Common.Models;
    using FastFood.Data.Models.Enumerations;

    public class Drink : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        public DringSize Size { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; }
    }
}