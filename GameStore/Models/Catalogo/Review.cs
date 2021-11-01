using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class Review
    {
        public Review(int id, int productId, string email, string title, string description, int stars, bool verifiedPurchase, int usefulCount, string reviewDate)
        {
            Id = id;
            ProductId = productId;
            Email = email;
            Title = title;
            Description = description;
            Stars = stars;
            VerifiedPurchase = verifiedPurchase;
            UsefulCount = usefulCount;
            ReviewDate = reviewDate;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public bool VerifiedPurchase { get; set; }
        public int UsefulCount { get; set; }
        public string ReviewDate { get; set; }
    }
}
