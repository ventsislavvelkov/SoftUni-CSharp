using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using CarDealer.Data;
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

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var suppliersXml = File.ReadAllText("../../../Datasets/suppliers.xml");
            var partsXml = File.ReadAllText("../../../Datasets/parts.xml");
            var carsXml = File.ReadAllText("../../../Datasets/cars.xml");

            var suppliersResult = ImportSuppliers(context, suppliersXml);
            var partsResult = ImportParts(context, partsXml);
            var carsResult = ImportCars(context, carsXml);

            Console.WriteLine(suppliersResult);
            Console.WriteLine(partsResult);
            Console.WriteLine(carsResult);

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

            var carsDto = XMLConverter.Deserializer<ImpoortCarsDto>(inputXml, rootElement);

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

    }
}