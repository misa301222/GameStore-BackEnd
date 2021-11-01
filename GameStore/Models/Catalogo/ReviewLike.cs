using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class ReviewLike
    {
        public ReviewLike(int id, int reviewId, string email, int likeValue)
        {
            Id = id;
            ReviewId = reviewId;
            Email = email;
            LikeValue = likeValue;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string Email { get; set; }
        public int LikeValue { get; set; }
    }
}
