using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data.Models
{
    public class Store
    {
        public int  StoreId { get; set; }

        public string Name { get; set; }

        public Sale Sales { get; set; }

    }
}
