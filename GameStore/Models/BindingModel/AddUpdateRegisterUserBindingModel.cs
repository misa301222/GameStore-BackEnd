using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models.BindingModel
{
    public class AddUpdateRegisterUserBindingModel
    {
        public String FullName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public List<String> Roles { get; set; }

        public decimal Funds { get; set; }
    }
}

