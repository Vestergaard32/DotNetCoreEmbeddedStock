using System.IO;
using EmbeddedStock.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmbeddedStock.Repositories
{
    public class DatabaseContext : DbContext
    {
        public static IConfigurationRoot Configuration { get; set; }

        public DbSet<Component> Components { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ComponentType> ComponentType { get; set; }
        public DbSet<ComponentTypeCategory> ComponentTypeCategories { get; set; }
        public DbSet<ESImage> EsImages { get; set; }

        public DatabaseContext()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SuperSql"));
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ComponentTypeCategory>()
                .HasKey(ctc => new {ctc.CategoryId, ctc.ComponentTypeId});

            builder.Entity<ComponentTypeCategory>()
                .HasOne(c => c.Category)
                .WithMany(c => c.ComponentTypes)
                .HasForeignKey(c => c.CategoryId);

            builder.Entity<ComponentTypeCategory>()
                .HasOne(c => c.ComponentType)
                .WithMany(c => c.ComponentTypeCategories)
                .HasForeignKey(c => c.ComponentTypeId);
        }
    }
}