using System;
using System.Collections.Generic;
using System.Text;
using P03.ShoppingSpree.Common;

namespace P03.ShoppingSpree.Models
{
    public class Person
    {
        private const decimal MONEY_MIN_VALUE = 0;
        private string name;
        private decimal money;
        private List<Product> bag;

        private Person()
        {
            this.bag = new List<Product>();
        }
        public Person(string name, decimal money)
        :this()
        {
            this.Name = name;
            this.Money = money;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw  new ArgumentException(GlobalConstants.InvalidNameExceptionMessage);
                }

                this.name = value;
            }
        }

        public decimal Money
        {
            get => this.money;
            set
            {
                if (value < MONEY_MIN_VALUE)
                {
                    throw new ArgumentException(GlobalConstants.InvalidMoneyExceptionMessage);
                }

                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();

        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new InvalidOperationException(String.Format
                    (GlobalConstants.InsufficientMoneyExceptionMessage, this.Name, product.Name));
            }

            this.Money -= product.Cost;
            this.bag.Add(product);
        }

        public override string ToString()
        {
            string productsOutput = this.Bag.Count>0 ? String.Join(", ", this.Bag) : "Nothing bought";
           
            return $"{this.name} - {productsOutput}";
        }
    } 
}
