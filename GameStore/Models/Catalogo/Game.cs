using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Models.Catalogo
{
    public class Game
    {

        public Game(int idGame, string gameName, string publisher, decimal price, String releaseDate, int category, String coverUrl, String description, int quantity)
        {
            IdGame = idGame;
            GameName = gameName;
            Publisher = publisher;
            Price = price;
            ReleaseDate = releaseDate;
            Category = category;
            CoverUrl = coverUrl;
            Description = description;
            Quantity = quantity;
        }

        [Key]
        public int IdGame { get; set; }

        [Column (TypeName = "nvarchar(50)")]
        public String GameName { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public String Publisher { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Column(TypeName = "varchar(50)")]
        public String ReleaseDate { get; set; }

        public int Category { get; set; }

        public String CoverUrl { get; set; }

        public String Description { get; set; }

        public int Quantity { get; set; }

    }
}
