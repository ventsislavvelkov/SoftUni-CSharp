namespace FastFood.Data.Models
{
    using FastFood.Data.Common.Models;

    public class Meats : BaseDeletableModel<int>
    {
        public string Name { get; set; }
        
        //SpicyBeef = 1,
        //Choriso = 2,
        //Tuna = 3,
        //Hem = 4,
        //Pepperoni = 5,
    }
}