using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Talabat.Core.Entites;

namespace Talabat.Repository.Data.Contexts
{
    public static class StoreContextSeed
    {
        public static async Task SeedDataAsync(StoreContext context)
        {
            if (context.Brands.Count() == 0)
            {
                var brandsText = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/brands.json");

                var brandsData = JsonSerializer.Deserialize<List<ProductBrand>>(brandsText);

                if (brandsData?.Count > 0)
                    foreach (var brand in brandsData)
                        context.Brands.Add(brand);
                context.SaveChanges();
            }
            if (context.Categories.Count() == 0)
            {
                var categoriesText = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/categories.json");

                var categoriesData = JsonSerializer.Deserialize<List<ProductCategory>>(categoriesText);

                if (categoriesData?.Count > 0)
                    foreach (var category in categoriesData)
                        context.Categories.Add(category);
                context.SaveChanges();
            }
            if (context.Products.Count() == 0)
            {
                var productsText = File.ReadAllText("../Talabat.Repository/Data/DataSeeding/products.json");

                var productsData = JsonSerializer.Deserialize<List<Product>>(productsText);

                if (productsData?.Count > 0)
                    foreach (var product in productsData)
                        context.Products.Add(product);
                context.SaveChanges();
            }

        }
    }
}
