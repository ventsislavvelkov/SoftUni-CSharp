using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Numerics;

namespace _07StoreBoxes
{
    class StartUp
    {
        static void Main(string[] args)
        {
           

            List<Box> storeBox = new List<Box>();


            while (true)
            {
                List<string> resevedItem = Console.ReadLine().Split(" ").ToList();

                if (resevedItem[0] == "end")
                {
                    break;
                }

                string serialNumber = resevedItem[0];
                string itemName = resevedItem[1];
                int itemQuantity = int.Parse(resevedItem[2]);
                double itemPrice = double.Parse(resevedItem[3]);

                Box box = new Box();
                {
                    box.SerialNumber = serialNumber;
                    box.Item.Name = itemName;
                    box.Item.Price = itemPrice;
                    box.Quantity = itemQuantity;
                    box.PriceBox = itemPrice * itemQuantity;
                }

                storeBox.Add(box);
            }

            var printList = storeBox.OrderByDescending(x => x.PriceBox);

            foreach (Box box in printList)
            {
                Console.WriteLine($"{box.SerialNumber}");
                Console.WriteLine($"-- {box.Item.Name} - ${box.Item.Price:f2}: {box.Quantity}");
                Console.WriteLine($"-- ${box.PriceBox:f2}");
            }
            
        }
    }
    class Box
    {
        public Box()
        {
            Item = new Item();

        }

        public string SerialNumber { get; set; }
        public Item Item { get; set;  }
        public int Quantity { get; set; }
        public double PriceBox { get; set; }

    }

    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}
