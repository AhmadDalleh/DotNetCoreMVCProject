using Microsoft.EntityFrameworkCore;
using DotNetCoreMVCProject.Models;

namespace DotNetCoreMVCProject.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); 
        }
        public DbSet<Product> Products { get; set; }

        public DbSet<TheClass> Classes { get; set; }

        public DbSet<TheClassStudent> Students { get; set; }
    }
}
