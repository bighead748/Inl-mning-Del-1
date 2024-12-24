using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using dagnyr.api.Data;
using dagnyr.api.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace dagnyr.api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class ProductsController(DataContext context) : ControllerBase
{
    private readonly DataContext _context = context;

    [HttpGet("{id}")]
        public async Task<ActionResult> FindProduct(int id)
        {
            var product = await _context.Products
                .Where(p => p.ProductId == id)
                .Include(p => p.Suppliers)
                .Select(p => new
                {
                    p.ProductId,
                    p.ProductName,
                    p.ItemNumber,
                    Suppliers = p.Suppliers.Select(s => new
                    {
                        s.OrderId,
                        s.SupplierName,
                        s.ContactPerson,
                        s.PhoneNumber,
                        s.Email
                    })
                })
                .SingleOrDefaultAsync();

            if (product == null)
            {
                return NotFound(new { success = false, StatusCode = 404, message = $"Product not found: {id}" });
            }

            return Ok(new { success = true, statusCode = 200, data = product });
        }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        var toDelete = await _context.Products.SingleOrDefaultAsync(p => p.ProductId == id);
        _context.Products.Remove(toDelete);
        await _context.SaveChangesAsync();
        return Ok();
    }

    
}