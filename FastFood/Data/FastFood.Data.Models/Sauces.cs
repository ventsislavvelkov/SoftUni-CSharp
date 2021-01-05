using FastFood.Data.Common.Models;

namespace FastFood.Data.Models
{
    public class Sauces : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        //Cream = 1,
        //Tomato = 2,
    }
}