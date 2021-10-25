using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GameStore.Data;
using GameStore.Models.Catalogo;
using GameStore.Models.BindingModel;
using GameStore.Models;
using GameStore.Enums;
using Microsoft.AspNetCore.Hosting;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly GameStoreDBContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(GameStoreDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: api/Product
        [HttpGet("GetAllProducts")]
        public async Task<ActionResult<IEnumerable<Product>>> GetProduct()
        {
            return await _context.Product.ToListAsync();
        }

        /*
        [HttpGet("GenerateReport")]
        public async Task<IActionResult> GenerateReport()
        {
            string mimtype = "";
            int extension = 1;
            var path = $"{this._webHostEnvironment.WebRootPath}\\Reports\\ProductReport.rdlc";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("rp1", "Hola mundo");
            LocalReport localReport = new LocalReport(path);
            
            var products = await _context.Product.ToListAsync();
            //localReport.AddDataSource("Prod", products);
            //TODO HACER QUE MUESTRE LA INFORMACION EN EL REPORTE
            localReport.AddDataSource("Product", products);
            var result = localReport.Execute(RenderType.Pdf, extension, parameters, mimtype);
            var file = File(result.MainStream, "application/pdf");
            return file;
        }
        */

        // GET: api/Product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/Product/5
        [HttpGet("GetAllProductByCategoryId/{categoryId}")]
        public async Task<object> GetAllProductByCategoryId(int categoryId)
        {
            var result = await _context.Product.ToListAsync();
            List<Product> productList = new List<Product>();
            foreach (var product in result)
            {
                if (product.Category == categoryId)
                {
                    productList.Add(product);
                }
            }
            return productList;
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("AddProduct")]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("UpdateQuantity")]
        public async Task<ActionResult<Product>> UpdateQuantity([FromBody] UpdateQuantityProductModel model)
        {
            var currentProduct = _context.Product.FindAsync(model.ProductId);
            currentProduct.Result.Quantity -= model.Quantity;
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = currentProduct.Result.ProductId }, currentProduct);
        }

            private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
