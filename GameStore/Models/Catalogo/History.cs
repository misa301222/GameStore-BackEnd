using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class History
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int id { get; set; }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public string Email { get; set; }

        public string BuyDate { get; set; }

    }
}
