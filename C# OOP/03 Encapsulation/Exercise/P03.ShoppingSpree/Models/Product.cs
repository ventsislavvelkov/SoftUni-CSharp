using System;
using System.Collections.Generic;
using System.Text;
using P03.ShoppingSpree.Common;

namespace P03.ShoppingSpree.Models
{
   public class Product
   {
       private const decimal COST_MIN_VALUE = 0;
       private string name;
       private decimal cost;

       public Product()
       {
           
       }

       public string Name
       {
           get => this.name;
           private set
           {
               if (String.IsNullOrWhiteSpace(value))
               {
                   throw new ArgumentException( GlobalConstants.InvalidNameExceptionMessage);
               }

               this.name = value;
            }
       }

       public decimal Cost
       {
           get => this.cost;
           private set
           {
               if (value < COST_MIN_VALUE)
               {
                   throw new ArgumentException(GlobalConstants.InvalidMoneyExceptionMessage);
               }

               this.cost = value;
           }
       }
   }
}
