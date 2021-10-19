using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class Product
    {
        public Product(int productId, string productName, string description, int category, string coverUrl, decimal price, int quantity)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Description = description;
            this.Category = category;
            this.CoverUrl = coverUrl;
            this.Price = price;
            this.Quantity = quantity;
        }

        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int Category { get; set; }

        public string CoverUrl { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

    }
}
