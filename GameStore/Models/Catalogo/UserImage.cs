using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class UserImage
    {
        public UserImage(String email, String coverUrl)
        {
            this.Email = email;
            this.CoverUrl = coverUrl;
        }

        [Key]
        public String Email { get; set; }

        public String CoverUrl { get; set; }
    }
}
