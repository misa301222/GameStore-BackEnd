using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class EmploymentApplication
    {
        public EmploymentApplication(int employmentApplicationId, string email, string fullName, string phone, string address, string scholarship, int employmentDesired, string applicationDate, int applicationStatus)
        {
            EmploymentApplicationId = employmentApplicationId;
            Email = email;
            FullName = fullName;
            Phone = phone;
            Address = address;
            Scholarship = scholarship;
            EmploymentDesired = employmentDesired;
            ApplicationDate = applicationDate;
            ApplicationStatus = applicationStatus;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int EmploymentApplicationId { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Scholarship { get; set; }
        public int EmploymentDesired { get; set; }
        public string ApplicationDate { get; set; }
        public int ApplicationStatus { get; set; }
    }
}
