using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using dagnyr.api.Entities;

namespace dagnyr.api.Data;

    public static class Seed
    {
        public static async Task LoadProducts(DataContext context) 
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if(context.Products.Any()) return;

            var json = File.ReadAllText("Data/json/products.json");
            var products = JsonSerializer.Deserialize<List<Product>>(json, options);

            if(products is not null && products.Count > 0)
            {
                await context.Products.AddRangeAsync(products);
                await context.SaveChangesAsync();
            }
        }

        public static async Task LoadOrders(DataContext context) 
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if(context.Orders.Any()) return;

            var json = File.ReadAllText("Data/json/orders.json");
            var orders = JsonSerializer.Deserialize<List<Order>>(json, options);

            if(orders is not null && orders.Count > 0)
            {
                await context.Orders.AddRangeAsync(orders);
                await context.SaveChangesAsync();
            }
        }

        public static async Task LoadSuppliers(DataContext context) 
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            if(context.Suppliers.Any()) return;

            var json = File.ReadAllText("Data/json/suppliers.json");
            var suppliers = JsonSerializer.Deserialize<List<Supplier>>(json, options);

            if(suppliers is not null && suppliers.Count > 0)
            {
                await context.Suppliers.AddRangeAsync(suppliers);
                await context.SaveChangesAsync();
            }
        }
    }
