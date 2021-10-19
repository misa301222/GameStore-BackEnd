using GameStore.Data.Entity;
using GameStore.Models.Catalogo;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models.BindingModel;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.Data
{
    public class GameStoreDBContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public GameStoreDBContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Game> Game { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<Category> Category { get; set; }

        public DbSet<History> History { get; set; }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<UserImage> UserImage { get; set; }

        //public DbSet<UserDTO> usuario { get; set; }

    }
}
