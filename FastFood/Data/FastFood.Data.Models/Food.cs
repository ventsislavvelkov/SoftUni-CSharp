namespace FastFood.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using FastFood.Data.Common.Models;
    using FastFood.Data.Models.Enumerations;

    public class Food : BaseDeletableModel<int>
    {
        public FoodType FoodType { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(FoodIngredients))]
        public int FoodIngredientsId { get; set; }

        public virtual FoodIngredients FoodIngredients { get; set; }

        public PizzaSize PizzaSizes { get; set; }

        public PizzaCrust PizzaCrust { get; set; }

        public FoodSize SaladSize { get; set; }

        public int Weight { get; set; }

        public decimal Price { get; set; }
    }
}