using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AndreasHarfeldJakobsen201608930.WPF.Models;
using Microsoft.EntityFrameworkCore;

namespace AndreasHarfeldJakobsen201608930.WPF.Data
{
    class BereauDbContext : DbContext
    {
        public DbSet<Model> Models { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<ModelAssignment> ModelAssignments { get; set; }

        public BereauDbContext()
        {}

        public BereauDbContext(DbContextOptions<BereauDbContext> options)
            : base(options)
        {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=BereauDatabase;Trusted_Connection=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModelAssignment>()
                .HasKey(ma => new {ma.AssignmentId, ma.ModelId});

            modelBuilder.Entity<ModelAssignment>()
                .HasOne<Model>(ma => ma.Model)
                .WithMany(m => m.ModelAssignments)
                .HasForeignKey(ma => ma.ModelId);

            modelBuilder.Entity<ModelAssignment>()
                .HasOne<Assignment>(ma => ma.Assignment)
                .WithMany(a => a.ModelAssignments)
                .HasForeignKey(ma => ma.AssignmentId);
        }

    }
}

