using Microsoft.EntityFrameworkCore;
using Bangazon.Models;

namespace Bangazon
{
    public class BangazonDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }
        public DbSet<Category> Categories { get; set; }

        public BangazonDbContext(DbContextOptions<BangazonDbContext> context) : base(context)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            { 
            new User {Id = 1, Username = "kcob", FirstName = "Keana", LastName = "Cobarde", Email = "keanacobarde@gmail.com", Address = "123 Witchy Lane", IsSeller = true, Uid = "Kqa5uPcWOgRIUtiXEBnJbP6VQXB3"  },
            });
        }

    }
}
