using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class Jobs
    {
        public Jobs(int jobId, string description)
        {
            JobId = jobId;
            Description = description;
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int JobId { get; set; }
        public string Description { get; set; }
    }
}
