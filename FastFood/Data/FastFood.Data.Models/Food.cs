namespace FastFood.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using FastFood.Data.Common.Models;
    using FastFood.Data.Models.Enumerations;

    public class Food : BaseDeletableModel<int>
    {

        public FoodType FoodType { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(Ingredients))]
        public int IngredientsId { get; set; }

        public Ingredients Ingredients { get; set; }

        public PizzaSize PizzaSizes { get; set; }

        public PizzaCrust PizzaCrust { get; set; }

        public FoodSize SaladSize { get; set; }

        public string Images { get; set; }

        public int Weight { get; set; }

        public decimal Price { get; set; }
    }
}