namespace FastFood.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Collections.Generic;
    using FastFood.Data.Common.Models;
    using FastFood.Data.Models.Enumerations;

    public class FoodIngredients : BaseDeletableModel<int>
    {
        public FoodIngredients()
        {
            this.Vegetables = new HashSet<Vegetables>();
            this.Sauces = new HashSet<Sauces>();
            this.Meats = new HashSet<Meats>();
            this.Herbs = new HashSet<Herbs>();
            this.Cheeses = new HashSet<Cheeses>();
        }

        [NotMapped]
        public ICollection<Vegetables> Vegetables { get; set; }

        [NotMapped]
        public ICollection<Sauces> Sauces { get; set; }

        [NotMapped]
        public ICollection<Meats> Meats { get; set; }

        [NotMapped]
        public ICollection<Herbs> Herbs { get; set; }

        [NotMapped]
        public ICollection<Cheeses> Cheeses { get; set; }

    }
}