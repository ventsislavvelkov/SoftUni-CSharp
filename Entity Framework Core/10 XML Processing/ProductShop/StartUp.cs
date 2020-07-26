using System;
using System.Drawing;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductShop.Data;
using ProductShop.Dtos.Import;
using ProductShop.Models;
using ProductShop.XmlHelper;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var userXml = File.ReadAllText("../../../Datasets/users.xml");
            var productsXml = File.ReadAllText("../../../Datasets/products.xml");
            var categoriesXml = File.ReadAllText("../../../Datasets/categories.xml");
            var categoryProductsXml = File.ReadAllText("../../../Datasets/categories-products.xml");

            ImportUsers(context, userXml);
            ImportProducts(context, productsXml);
            ImportCategories(context, categoriesXml);

            var result = ImportCategoryProducts(context, categoryProductsXml);

            Console.WriteLine(result);

        }

        //Problem 1
        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Users";

            var usersResult = XMLConverter.Deserializer<ImportUserDto>(inputXml, rootElement);

            var users = usersResult
                .Select(u => new User
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age
                })
                .ToArray();
            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        //Problem 2
        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Products";

            var productResult = XMLConverter.Deserializer<ImportProductsDto>(inputXml, rootElement);

            var product = productResult
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId

                })
                .ToArray();

            context.Products.AddRange(product);
            context.SaveChanges();

            return $"Successfully imported {product.Length}";
        }

        //Problem 3
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            const string rootElement = "Categories";

            var categoriesResult = XMLConverter.Deserializer<ImportCategoriesDto>(inputXml, rootElement);

            var categories = categoriesResult
                .Where(c => c.Name != null)
                .Select(c => new Category
                {
                    Name = c.Name

                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Length}";


        }

        //Problem 4
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            const string rootElements = "CategoryProducts";

            var categoryProductResult = XMLConverter.Deserializer<ImportCategoryProductsDto>(inputXml, rootElements);

            var categoryProducts = categoryProductResult
                .Where(i => context.Categories.Any(c => c.Id == i.CategoryId) &&
                            context.Products.Any(p => p.Id == i.ProductId))
                .Select(c => new CategoryProduct
                {
                    CategoryId = c.CategoryId,
                    ProductId = c.ProductId
                })
                .ToArray();

            context.CategoryProducts.AddRange(categoryProducts);
            context.SaveChanges();
            return $"Successfully imported {categoryProducts.Length}";
        }

    }
}