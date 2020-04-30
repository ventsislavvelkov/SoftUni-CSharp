using System;
using System.Collections.Generic;
using System.Text;

namespace P06.FoodShortage.Interfaces
{
    interface IBuyer
    {
        string Name { get; }

        int Age { get; }

        int Food { get; }

        void BuyFood();
    }
}
