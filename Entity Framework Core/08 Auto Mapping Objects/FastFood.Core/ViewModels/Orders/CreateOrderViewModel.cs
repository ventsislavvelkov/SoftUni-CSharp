namespace FastFood.Core.ViewModels.Orders
{
    using System.Collections.Generic;

    public class CreateOrderViewModel
    {
        public List<string> Items { get; set; }

        public List<string> Employees { get; set; }
    }
}
