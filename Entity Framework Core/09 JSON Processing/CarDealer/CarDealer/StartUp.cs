﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Data;
using CarDealer.DTO.Cars;
using CarDealer.DTO.Customers;
using CarDealer.DTO.Import;
using CarDealer.DTO.Sales;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore.Update;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


namespace CarDealer
{
    public class StartUp
    {
        private static readonly string ResultDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            var db = new CarDealerContext();

            //ResetDatabase(db);

            //var inputJson = File.ReadAllText("../../../Datasets/suppliers.json");

            //var result = ImportSuppliers(db, inputJson);

            InitialMapper();

            var json = GetSalesWithAppliedDiscount(db);

            Console.WriteLine(json);

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

            return $"Successfully imported {suppliers.Length}.";

        }

        //Problem 9
        public static string ImportParts(CarDealerContext context, string inputJson)
        {
            var parts = JsonConvert.DeserializeObject<Part[]>(inputJson)
                .Where(p => context.Suppliers.Any(s => s.Id == p.SupplierId))
                .ToArray();

            context.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";


        }

        //Problem 10
        public static string ImportCars(CarDealerContext context, string inputJson)
        {
            var carsDto = JsonConvert.DeserializeObject<ImportCarsDTO[]>(inputJson);

            foreach (var ImportCarsDTO in carsDto)
            {
                Car car = new Car
                {
                    Make = ImportCarsDTO.Make,
                    Model = ImportCarsDTO.Model,
                    TravelledDistance = ImportCarsDTO.TravelledDistance
                };

                context.Cars.Add(car);

                foreach (var partId in ImportCarsDTO.PartsId)
                {
                    PartCar partCar = new PartCar
                    {
                        CarId = car.Id,
                        PartId = partId
                    };

                    if (car.PartCars.FirstOrDefault(p => p.PartId == partId) == null)
                    {
                        context.PartCars.Add(partCar);
                    }
                }
            }
            context.SaveChanges();

            return $"Successfully imported {carsDto.Length}.";
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

        //Problem 13
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context.Customers
                .OrderBy(c => c.BirthDate)
                .ThenBy(c => c.IsYoungDriver)
                .ProjectTo<GetOrderedCustomersDTO>()
                .ToArray();

            var json = JsonConvert.SerializeObject(customers, Formatting.Indented);

            return json;
        }

        //Problem 14
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(c => c.Make == "Toyota")
                .OrderBy(c => c.Model)
                .ThenByDescending(c=>c.TravelledDistance)
                .ProjectTo<GetCarsFromMakeToyotaDTO>()
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;
        }

        //Problem 15
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context.Suppliers
                .Where(s => s.IsImporter == false)
                .Select(s => new
                {
                    Id = s.Id,
                    Name = s.Name,
                    PartsCount = s.Parts.Count()
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

            return json;

        }

        //Problem 16 
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context.Cars
                .Select(c => new 
                {
                    car = new GetListOfCarsWithParts
                    {
                        Make = c.Make,
                        Model = c.Model,
                        TravelledDistance = c.TravelledDistance
                    },
                    parts = c.PartCars.Select(cp => new GetListOfParts()
                        {
                            Name = cp.Part.Name,
                            Price = $"{cp.Part.Price:F2}"
                        })
                        .ToArray()
                })
                .ToArray();

            var json = JsonConvert.SerializeObject(cars, Formatting.Indented);

            return json;

        }

        //Problem 17
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customer = context.Customers
                .Where(c => c.Sales.Count >= 1)
                //.Select(c => new CustomerCarDto()
                //{
                //    FullName = c.Name,
                //    BoughtCars = c.Sales.Count,
                //    SpentMoney = c.Sales.Sum(s => s.Car.PartCars.Sum(pc => pc.Part.Price))
                //})
                .ProjectTo<CustomerCarDto>()
                .OrderByDescending(c=>c.SpentMoney)
                .ThenByDescending(c => c.BoughtCars)
                .ToList();

            string jsonExport = JsonConvert.SerializeObject(customer, new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            });

            return jsonExport;
        }

        //Problem 18
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales = context.Sales
                .Take(10)
                .Select(s => new SalesDto
                {
                    Car = new CarDto
                    {
                        Make = s.Car.Make,
                        Model = s.Car.Model,
                        TravelledDistance = s.Car.TravelledDistance
                    },
                    CustomerName = s.Customer.Name,
                    Discount = $"{s.Discount:F2}",
                    Price = $"{s.Car.PartCars.Sum(pc => pc.Part.Price):F2}",
                    PriceWithDiscount = $@"{s.Car.PartCars.Sum(pc => pc.Part.Price)
                                                - (s.Car.PartCars.Sum(pc => pc.Part.Price) * s.Discount / 100):F2}"
                })
                .ToList();


            var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

            return json;

        }

        //customerName": "Ann Mcenaney",
        //"Discount": "30.00",
        //"price": "2176.37",
        //"priceWithDiscount": "1523.46"



        private static void InitialMapper()
        {
            Mapper.Initialize(cfg => { cfg.AddProfile<CarDealerProfile>(); });
        }
    }
}