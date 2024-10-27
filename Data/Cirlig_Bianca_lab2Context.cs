using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cirlig_Bianca_lab2.Models;

namespace Cirlig_Bianca_lab2.Data
{
    public class Cirlig_Bianca_lab2Context : DbContext
    {
        public Cirlig_Bianca_lab2Context (DbContextOptions<Cirlig_Bianca_lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Cirlig_Bianca_lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Cirlig_Bianca_lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Author> Authors { get; set; }
        public DbSet<Cirlig_Bianca_lab2.Models.Category> Category { get; set; } = default!;
    }
}
