using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_Magazin.Models;

namespace Proiect_Magazin.Data
{
    public class Proiect_MagazinContext : DbContext
    {
        public Proiect_MagazinContext (DbContextOptions<Proiect_MagazinContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_Magazin.Models.Cloth> Cloth { get; set; } = default!;

        public DbSet<Proiect_Magazin.Models.Designer> Designer { get; set; }

        public DbSet<Proiect_Magazin.Models.Size> Size { get; set; }

        public DbSet<Proiect_Magazin.Models.Collection> Collection { get; set; }

        public DbSet<Proiect_Magazin.Models.Category> Category { get; set; }

        public DbSet<Proiect_Magazin.Models.Material> Material { get; set; }

        public DbSet<Proiect_Magazin.Models.User> User { get; set; }

        public DbSet<Proiect_Magazin.Models.Cart> Cart { get; set; }
    }
}
