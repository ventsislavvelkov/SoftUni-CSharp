﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text.RegularExpressions;
using CarDealer.Data;
using CarDealer.Dto.Export;
using CarDealer.Dto.Import;
using CarDealer.Models;
using ProductShop.XmlHelper;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            CarDealerContext context = new CarDealerContext();

            //context.Database.EnsureDeleted();
            //context.Database.EnsureCreated();

            //var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            //var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            //var carsXml = File.ReadAllText("../../../Datasets/cars.xml");
            //var customersXml = File.ReadAllText("../../../Datasets/customers.xml");
            //var salesXml = File.ReadAllText("../../../Datasets/sales.xml");

            //var suppliersResult = ImportSuppliers(context, suppliersXml);
            //var partsResult = ImportParts(context, partsXml);
            //var carsResult = ImportCars(context, carsXml);
            //var customersResult = ImportCustomers(context, customersXml);
            //var salesResult = ImportSales(context, salesXml);

            //Console.WriteLine(suppliersResult);
            //Console.WriteLine(partsResult);
            //Console.WriteLine(carsResult);
            //Console.WriteLine(customersResult);
            //Console.WriteLine(salesResult);

            var result = GetSalesWithAppliedDiscount(context);
            Console.WriteLine(result);

        }

        //Problem 9
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Suppliers";

            var suppliersDto = XMLConverter.Deserializer<ImportSuppliersDto>(inputXml, rootElement);

            var suppliers = suppliersDto
                .Select(s => new Supplier
                {
                    Name = s.Name,
                    IsImporter = s.IsImporter
                })
                .ToArray();

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";

        }

        //Problem 10
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Parts";

            var partsDto = XMLConverter.Deserializer<ImportPartsDto>(inputXml, rootElement);

            var parts = partsDto
                .Where(p=>context.Suppliers.Any(s=>s.Id == p.SupplierId))
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToArray();
            
            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        //Problem 11 
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Cars";

            var carsDto = XMLConverter.Deserializer<ImportCarsDto>(inputXml, rootElement);

            var cars = new List<Car>();

            foreach (var carDto in carsDto)
            {
                var uniquePart = carDto.Parts.Select(s => s.Id).Distinct().ToArray();
                var realParts = uniquePart.Where(id => context.Parts.Any(i => i.Id == id));

                var car = new Car
                {
                    Make = carDto.Make,
                    Model = carDto.Model,
                    TravelledDistance = carDto.TraveledDistance,
                    PartCars = realParts.Select(id => new PartCar
                        {
                            PartId = id
                        })
                        .ToArray()
                };

                cars.Add(car);
            }

            context.Cars.AddRange(cars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";

        }

        //Problem 12 
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            const string rootElement = "Customers";

            var customersDto = XMLConverter.Deserializer<ImportCustomersDto>(inputXml, rootElement);

            var customers = customersDto
                .Select(c => new Customer
                {
                    Name = c.Name,
                    BirthDate = c.BirthDate,
                    IsYoungDriver = c.IsYoungDriver

                })
                .ToArray();
            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        //Problem 13 
        public static string ImportSales(CarDealerContext context, string inputXml)
        {

            const string rootElement = "Sales";

            var salesDto = XMLConverter.Deserializer<ImportSalesDto>(inputXml, rootElement);

            var sales = salesDto
                .Where(s => context.Cars.Any(c => c.Id == s.CarId))
                .Select(s => new Sale
                {
                    CarId = s.CarId,
                    CustomerId = s.CustomerId,
                    Discount = s.Discount
                })
                .ToArray();

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}";

        }

        // Problem 14 
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            const string rootElement = "cars";

            var carsWithDistans = context.Cars
                .Where(c => c.TravelledDistance > 2000000)
                .Select(c => new ExportCarsWithDistanceDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c=>c.Make)
                .ThenBy(c=>c.Model)
                .Take(10)
                .ToArray();

            var result = XMLConverter.Serialize(carsWithDistans, rootElement);

            return result;
        }

        //Problem 15
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            const string rootElement = "cars";

            var cars = context.Cars
                .Where(c => c.Make == "BMW")
                .Select(c => new ExportCarsFromBmwDto
                {
                    Id = c.Id,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance
                })
                .OrderBy(c => c.Model)
                .ThenByDescending(c => c.TravelledDistance)
                .ToArray();

            var result = XMLConverter.Serialize(cars, rootElement);
            return result;

        }

        //Problem 16 
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            const string rootElement = "suppliers";

            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new ExportLocalSuppliersDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count


                })
                .ToArray();

            var result = XMLConverter.Serialize(suppliers, rootElement);
            return result;
        }

        //Problem 17
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            const string rootElement = "cars";

            var cars = context.Cars
                .Select(c => new ExportCarWithTheirPartsDto
                {
                    Make = c.Make,
                    Model = c.Model,
                    TravelledDistance = c.TravelledDistance,
                    Parts = c.PartCars.Select(p => new ExportPartsDto
                    {
                        Name = p.Part.Name,
                        Price = p.Part.Price
                    })
                        .OrderByDescending(r=>r.Price)
                        .ToArray()  
                })
                .OrderByDescending(c=>c.TravelledDistance)
                .ThenBy(c=>c.Model)
                .Take(5)
                .ToArray();

            var result = XMLConverter.Serialize(cars, rootElement);
            return result;

        }

        //Problem 18 
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            const string rootElement = "customers";

            var sales = context.Customers
                .Where(c => c.Sales.Count >= 1)
                .Select(c => new ExportSalesByCustomerDto
                {
                    FullName = c.Name,
                    BoughtCars = c.Sales.Count,
                    SpentMoney = c.Sales.Sum(s => s.Car.PartCars
                        .Sum(pc => pc.Part.Price))
                })
                .OrderByDescending(s => s.SpentMoney)
                .ToArray();

            var result = XMLConverter.Serialize(sales, rootElement);

            return result;

        }

        //Problem 19
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            const string rootElement = "sales";

            var sales = context.Sales
                .Select(s => new ExportSalesDiscountDto
                {
                    Car = new CarsDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    Discount = s.Discount,
                    CustomerName = s.Customer.Name,
                    Price = s.Car.PartCars.Sum(p => p.Part.Price),
                    PriceWithDiscount = s.Car.PartCars.Sum(p => p.Part.Price) -
                                        s.Car.PartCars.Sum(p => p.Part.Price) * s.Discount / 100,


                })
                .ToArray();
                

            var result = XMLConverter.Serialize(sales, rootElement);

            return result;

        }
    }
}


//sales>
//<sale>
//      <car make = "BMW" model="M5 F10" travelled-distance="435603343" />
//      <discount>30.00</discount>
//      <customer-name>Hipolito Lamoreaux</customer-name>
//      <price>707.97</price>
//      <price-with-discount>495.58</price-with-discount>
//</sale>
