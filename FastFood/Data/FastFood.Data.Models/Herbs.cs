namespace FastFood.Data.Models
{
    using FastFood.Data.Common.Models;

    public class Herbs : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        //Basil = 1,
        //Oregano = 2,
        //ParmesanSprinkles = 3,
    }
}