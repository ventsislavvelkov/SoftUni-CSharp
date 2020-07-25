using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DTO.Users;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        private static string ResultDirectoryPath = "../../../Datasets/Results";

        public static void Main(string[] args)
        {
            ProductShopContext db = new ProductShopContext();

          //var inputJson = File.ReadAllText("../../../Datasets/categories-products.json");

          //var result =  ImportCategoryProducts(db, inputJson);

          //Console.WriteLine(result);
          InitialMapper();

          var json = GetUsersWithProducts(db);

          if (!Directory.Exists(ResultDirectoryPath))
          {
              Directory.CreateDirectory(ResultDirectoryPath);
          }

          File.WriteAllText(ResultDirectoryPath + "/users-and-products.json", json);

        }

        //Problem 1
        private static void ResetDatabase(ProductShopContext db)
        {
            db.Database.EnsureDeleted();
            Console.WriteLine("Database was Successfully deleted!");

            db.Database.EnsureCreated();
            Console.WriteLine("Database was Successfully created!");
        }

        //Problem 2
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users = JsonConvert.DeserializeObject<User[]>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";

        }

        //Problem 3
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<Product[]>(inputJson);
            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        //Problem 4
        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            var categories = JsonConvert
                .DeserializeObject<Category[]>(inputJson)
                .Where(c => c.Name != null)
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        //Problem 5
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categoriesAndProducts = JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            context.CategoryProducts.AddRange(categoriesAndProducts);
            context.SaveChanges();

            return $"Successfully imported {categoriesAndProducts.Length}";
        }

        //Problem 6 
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Select(p => new
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + ' ' + p.Seller.LastName
                }).ToArray();

            var json = JsonConvert.SerializeObject(products, Formatting.Indented);
            
            return json;
        }

        //Problem 7 with DTO
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .ProjectTo<UserWithSoldProductsDTO>()
                .ToArray();

            var json = JsonConvert.SerializeObject(users, Formatting.Indented);

            return json;

        }

        //Problem 8
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .OrderByDescending(c => c.CategoryProducts.Count)
                .Select(c => new
                {
                    category = c.Name,
                    productCount = c.CategoryProducts.Count(),
                    avaragePrice = c.CategoryProducts.Average(cp => cp.Product.Price)
                        .ToString("f2"),
                    totalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price)
                        .ToString("f2")

                }).ToArray();

            var json = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return json;
        }

        //Problem 9 
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new
                {
                    lastName = u.LastName,
                    age = u.Age,
                    soldProducts = new
                    {
                        count = u.ProductsSold
                            .Count(p => p.Buyer != null),
                        products = u.ProductsSold
                            .Where(p => p.Buyer != null)
                            .Select(p => new
                            {
                                name = p.Name,
                                price = p.Price
                            })
                            .ToArray()
                    }
                })
                .OrderByDescending(u => u.soldProducts.count)
                .ToArray();

            var resultObj = new
            {
                userCount = users.Length,
                users = users
            };

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented
            };

            var json = JsonConvert.SerializeObject(resultObj, settings);

            return json;


        }

        private static void InitialMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });
        }
    }
}