using FastFood.Data.Common.Models;

namespace FastFood.Data.Models
{
    public class Vegetables : BaseDeletableModel<int>
    {
        public string Name { get; set; }

        //FreshGreenPeppers = 1,
        //FreshMushrooms = 2,
        //BlackOlives = 3,
        //Onion = 4,
        //JalapenosPeppers = 5,
        //Ruccula = 6,
        //FreshTomato = 7,
        //Corn = 8,
        
    }
}