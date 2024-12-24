using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using dagnyr.api.Data;
using dagnyr.api.Entities;
using dagnyr.api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace dagnyr.api.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    public class SuppliersController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpGet]
        public async Task<ActionResult> ListAllSuppliers()
        {
            var suppliers = await _context.Orders
            .Include(s => s.Suppliers)
            .Select(supplier => new
            {
                OrderNumberSupplier = supplier.OrderId,
                SupplierProducts = supplier.Suppliers
                .Select(product => new{
                    product.Product.ProductName,
                    product.PricePerKg,
                    product.SupplierName,
                    product.SupplierAddress,
                    product.ContactPerson,
                    product.PhoneNumber,
                    product.Email
                    
                })
            })

            .ToListAsync();

            return Ok(new{sucess = true, statusCode = 200, data = suppliers});
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> FindSupplier(int id)
        {
            var supplier = await _context.Orders
            .Include(s => s.Suppliers)
            .Where(s => s.OrderId == id)
            .Select(supplier => new
            {
                OrderNumberSupplier = supplier.OrderId,
                SupplierProducts = supplier.Suppliers
                .Select(product => new{
                    product.Product.ProductName,
                    product.PricePerKg,
                    product.SupplierName,
                    product.SupplierAddress,
                    product.ContactPerson,
                    product.PhoneNumber,
                    product.Email
                })
            })
            .SingleOrDefaultAsync();

            if (supplier == null)
            {
                return NotFound(new { success = false, StatusCode = 404, message = $"Supplier not found: {id}" });
            }

            return Ok(new { success = true, statusCode = 200, data = supplier });
        }

        [HttpPost()]
        public async Task<ActionResult> AddProductToSupplier(OrderViewModel order)
        {
            var newProduct = new Order
            {
                OrderNumber = order.OrderNumber,
                Suppliers = []
            };

        foreach (var product in order.Products) 
          {
            var prod = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == product.ProductId);
            if (prod is null) return BadRequest($"Product not found: {product.ProductId}");
            var item = new Supplier
                {
                    PricePerKg = product.Price,
                    ProductId = product.ProductId
                };
                newProduct.Suppliers.Add(item);   
          }

          try
          {
            await _context.Orders.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(FindSupplier), new { id = newProduct.OrderId }, new {newProduct.OrderId, newProduct.OrderNumber});
          }

          catch (Exception ex)
          {
            System.Console.WriteLine(ex.Message);
            return BadRequest(new { success = false, statusCode = 400, message = ex.Message });
          }

          
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSupplier(int id)
        {
            var toDelete = await _context.Orders.SingleOrDefaultAsync(s => s.OrderId == id);
            _context.Orders.Remove(toDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProduct(int id, OrderViewModel order)
        {
            var productToUpdate = await _context.Orders
            .Where(c => c.OrderId == id)
            .Include(s => s.Suppliers)
            .SingleOrDefaultAsync();
            
            if(productToUpdate is null) return BadRequest("$Product not found: {id}");

            productToUpdate.OrderNumber = order.OrderNumber;

            foreach(var item in order.Products)
            {
                foreach(var supplier in productToUpdate.Suppliers)
                {
                    supplier.PricePerKg = item.Price;
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateProductPrice(int id, PatchOrderViewModel order)
        {
            
            return NoContent();
        }
        
  
    }
