using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data.Entity
{
    public class AppUser : IdentityUser
    {
        public string FullName { set; get; }
        public DateTime DateCreated { set; get; }
        public DateTime DateModified { set; get; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Funds { set; get; }
    }
}
