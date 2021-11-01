using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class ApplicationStatus
    {
        public ApplicationStatus(int applicationStatusId, string description)
        {
            ApplicationStatusId = applicationStatusId;
            Description = description;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int ApplicationStatusId { get; set; }
        public string Description { get; set; }
    }
}
