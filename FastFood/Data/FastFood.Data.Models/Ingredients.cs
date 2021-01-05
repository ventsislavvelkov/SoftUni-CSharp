
namespace FastFood.Data.Models
{
    using FastFood.Data.Common.Models;

    public class Ingredients : BaseDeletableModel<int>
    {
        public string Name { get; set; }

    }
}