using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class Help
    {
        public Help(int helpId, string question, string answer)
        {
            HelpId = helpId;
            Question = question;
            Answer = answer;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int HelpId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
