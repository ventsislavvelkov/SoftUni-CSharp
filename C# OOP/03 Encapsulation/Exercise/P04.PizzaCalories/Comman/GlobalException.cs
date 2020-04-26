using System;
using System.Collections.Generic;
using System.Text;

namespace P04.PizzaCalories.Comman
{
   public static class GlobalException
    {
        public const string InvalidTypeOfDoughExceptionMessage = "Invalid type of dough.";

        public const string InvalidWeightOfDoughExceptionMessage = "Dough weight should be in the range [1..200].";

        public const string InvalidToppingTypeExceptionMessage = "Cannot place {0} on top of your pizza.";

        public const string InvalidWeightOfToppingExceptionMessage = "{0} weight should be in the range [1..50].";

        public const string InvalidPizzaNameExceptionMessage = "Pizza name should be between 1 and 15 symbols.";

        public const string InvalidNumberOfToppingsExceptionMessage = "Number of toppings should be in range [0..10].";
    }
}
