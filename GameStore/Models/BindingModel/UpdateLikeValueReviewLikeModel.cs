using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.BindingModel
{
    public class UpdateLikeValueReviewLikeModel
    {
        public int ReviewId {get; set; }
        public string Email { get; set; }
        public int LikeValue { get; set; }
    }
}
