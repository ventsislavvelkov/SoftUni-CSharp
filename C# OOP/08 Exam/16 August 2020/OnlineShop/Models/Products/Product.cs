using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private int _id;
        private string _manufacturer;
        private string _model;
        private decimal _price;
        private double _overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get => _id;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Id can not be less or equal than 0.");
                }
                _id = value;
            }
        }

        public string Manufacturer
        {
            get => _manufacturer;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Manufacturer can not be empty.");
                }
                _manufacturer = value;
            }
        }

        public string Model
        {
            get => _model;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Model can not be empty.");
                }
                _model = value;
            }
        }

        public virtual decimal Price
        {
            get => _price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price can not be less or equal than 0.");
                }
                _price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get => _overallPerformance;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Overall Performance can not be less or equal than 0.");
                }
                _overallPerformance = value;
            }
        }

        public override string ToString()
        {
            string pattern = $"Overall Performance: {OverallPerformance:F2}. Price: {Price:F2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id})";
            return pattern.ToString();
        }
    }
}
