using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral: Product, IPeripheral
    {
        protected Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            ConnectionType = connectionType;
        }

        public string ConnectionType { get; private set; }

        public override string ToString()
        {
            string pattern = $"Overall Performance: {OverallPerformance:F2}. Price: {Price:F2} - {GetType().Name}: {Manufacturer} {Model} (Id: {Id}) Connection Type: {ConnectionType}";
            return pattern.ToString();
        }
    }
}
