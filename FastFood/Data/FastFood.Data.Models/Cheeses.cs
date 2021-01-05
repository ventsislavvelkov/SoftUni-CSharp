namespace FastFood.Data.Models
{
    using FastFood.Data.Common.Models;

    public class Cheeses : BaseDeletableModel<int>

    {
        public string Name { get; set; }
    }
}