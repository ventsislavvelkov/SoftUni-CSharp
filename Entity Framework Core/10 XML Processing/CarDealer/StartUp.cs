using System;
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

            var inputXml = File.ReadAllText("../../../Datasets/suppliers.xml");

            var result = ImportSuppliers(context, inputXml);

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
                .Where(p=>p.SupplierId)
                .Select(p => new Part
                {
                    Name = p.Name,
                    Price = p.Price,
                    Quantity = p.Quantity,
                    SupplierId = p.SupplierId
                })
                .ToArray();
        }

    }
}