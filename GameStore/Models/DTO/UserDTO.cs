using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Models.DTO
{
    public class UserDTO
    {
        public UserDTO(string fullname, string email, string username, DateTime datecreated, List<String> roles, decimal funds)
        {
            this.FullName = fullname;
            this.Email = email;
            this.UserName = username;
            this.DateCreated = datecreated;
            this.Roles = roles;
            this.Funds = funds;
        }

        public String FullName { get; set; }
        public String Email { get; set; }
        public String UserName { get; set; }
        public DateTime DateCreated { get; set; }
        public String Token { get; set; }
        public List<String> Roles { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Funds { set; get; }
    }
}
