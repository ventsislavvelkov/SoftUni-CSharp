using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

            ResetDatabase(db);

        }

        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was Successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Database was Successfully created!");
        }
    }
}