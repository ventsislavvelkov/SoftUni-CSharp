using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Sale
    {
        public int SaleId { get; set; }

        public DateTime Date { get; set; }

        public Product Product { get; set; }

        public Customer Customer { get; set; }

        public Store Store { get; set; }
    }
}
