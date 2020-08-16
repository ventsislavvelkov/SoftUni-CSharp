using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public abstract class Component : Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation) : base(id, manufacturer, model, price, overallPerformance)
        {
            Generation = generation;
        }

        public int Generation { get; private set; }
        public override string ToString()
        {
            var pattern = $"Overall Performance: {OverallPerformance:F2}. Price: {Price:F2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id}) Generation: {Generation}";
            return pattern.ToString();
        }
    }
}
