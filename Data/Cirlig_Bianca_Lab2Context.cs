using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cirlig_Bianca_Lab2.Models;

namespace Cirlig_Bianca_Lab2.Data
{
    public class Cirlig_Bianca_Lab2Context : DbContext
    {
        public Cirlig_Bianca_Lab2Context (DbContextOptions<Cirlig_Bianca_Lab2Context> options)
            : base(options)
        {
        }

        public DbSet<Cirlig_Bianca_Lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<Cirlig_Bianca_Lab2.Models.Publisher> Publisher { get; set; } = default!;
        public DbSet<Cirlig_Bianca_Lab2.Models.Author> Author { get; set; } = default!;
        public DbSet<Cirlig_Bianca_Lab2.Models.Category> Category { get; set; } = default!;
    }
}
