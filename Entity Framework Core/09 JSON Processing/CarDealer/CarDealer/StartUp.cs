using System;
using System.IO;
using System.Linq;
using System.Net.Mime;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;


namespace CarDealer
{
    public class StartUp
    {

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //ResetDatabase(db);

            

            var inputJson = File.ReadAllText("../../../Datasets/sales.json");

            var result = ImportSales(db, inputJson);

            Console.WriteLine(result);

        }

        //Import Database
        public static void ResetDatabase(CarDealerContext db)
        {
            db.Database.EnsureDeleted();

            Console.WriteLine("Database successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Database successfully Created!");
        }

        //Problem 8
        public static string ImportSuppliers(CarDealerContext context, string inputJson)
        {
            var suppliers = JsonConvert.DeserializeObject<Supplier[]>(inputJson);

            context.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";

        }

        //Problem 9
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s=>s.Id == p.SupplierId))
                .ToArray();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";


        }

        //Problem 10
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var cars = JsonConvert.DeserializeObject<Car[]>(inputJson);

            context.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Length}.";
        }

        //Problem 11 
        public static string ImportCustomers(CarDealerContext context, string inputJson)
        {
            var customers = JsonConvert.DeserializeObject<Customer[]>(inputJson);

            context.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        //Problem 12
        public static string ImportSales(CarDealerContext context, string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }
    }
}