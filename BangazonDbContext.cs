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
                new User
                {
                    Id = 1,
                    Username = "kcob",
                    FirstName = "Keana",
                    LastName = "Cobarde",
                    Email = "keanacobarde@gmail.com",
                    Address = "123 Witchy Lane",
                    IsSeller = true,
                    Uid = "Kqa5uPcWOgRIUtiXEBnJbP6VQXB3"
                },
                new User
                {
                    Id = 2,
                    Username = "keykey",
                    FirstName = "Kiki",
                    LastName = "Wiki",
                    Email = "keyzelgears@gmail.com",
                    Address = "124 Witchy Lane",
                    IsSeller = true,
                    Uid = "Kqa5uPcWOgRIUtiXEBnJbP6VQXB3"
                },
                new User
                {
                    Id = 3,
                    Username = "kira",
                    FirstName = "June",
                    LastName = "Bloom",
                    Email = "junejune22@gmail.com",
                    Address = "125 Witchy Lane",
                    IsSeller = false,
                    Uid = "Kqa5uPcWOgRIUtiXEBnJbP6VQXB3"
                }
            });

            modelBuilder.Entity<Product>().HasData(new Product[]
            {
                new Product
                {
                    Id = 1,
                    Title = "Laptop",
                    Description = "Powerful laptop for all your computing needs",
                    ImageUrl = "laptop_image_url.jpg",
                    QuantityAvailable = 50,
                    Price = 999.99f,
                    SellerId = 1,
                    CategoryId = 1,
                },
                new Product
                {
                    Id = 2,
                    Title = "Smartphone",
                    Description = "High-performance smartphone with advanced features",
                    ImageUrl = "smartphone_image_url.jpg",
                    QuantityAvailable = 100,
                    Price = 499.99f,
                    SellerId = 2,
                    CategoryId = 2,
                },
                new Product
                {
                    Id = 3,
                    Title = "Headphones",
                    Description = "Premium noise-canceling headphones for an immersive audio experience",
                    ImageUrl = "headphones_image_url.jpg",
                    QuantityAvailable = 30,
                    Price = 149.99f,
                    SellerId = 1,
                    CategoryId = 2,
                }
            });

            modelBuilder.Entity<Order>().HasData(new Order[]
            {
                new Order
                {
                    Id = 1,
                    CustomerId = 2,
                    PaymentId = 2,
                    IsOrderOpen = true,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = 1,
                            Title = "Laptop",
                            Description = "Powerful laptop for all your computing needs",
                            ImageUrl = "laptop_image_url.jpg",
                            QuantityAvailable = 50,
                            Price = 999.99f,
                            SellerId = 101,
                            CategoryId = 1,
                        },
                        new Product
                        {
                            Id = 2,
                            Title = "Smartphone",
                            Description = "High-performance smartphone with advanced features",
                            ImageUrl = "smartphone_image_url.jpg",
                            QuantityAvailable = 100,
                            Price = 499.99f,
                            SellerId = 102,
                            CategoryId = 2,
                        },
                    }
                },

                new Order
                {
                    Id = 2,
                    CustomerId = 2,
                    PaymentId = 3,
                    IsOrderOpen = true,
                    Products = new List<Product>
                   {
                        new Product
                        {
                            Id = 3,
                            Title = "Headphones",
                            Description = "Premium noise-canceling headphones for an immersive audio experience",
                            ImageUrl = "headphones_image_url.jpg",
                            QuantityAvailable = 30,
                            Price = 149.99f,
                            SellerId = 103,
                            CategoryId = 3,
                        },
                    }
                },

                new Order
                {
                    Id = 3,
                    CustomerId = 2,
                    PaymentId = 1,
                    IsOrderOpen = false,
                    Products = new List<Product>
                {
                        new Product
                        {
                            Id = 2,
                            Title = "Smartphone",
                            Description = "High-performance smartphone with advanced features",
                            ImageUrl = "smartphone_image_url.jpg",
                            QuantityAvailable = 100,
                            Price = 499.99f,
                            SellerId = 102,
                            CategoryId = 2,
                        },
                }
                }
            });

            modelBuilder.Entity<PaymentType>().HasData(new PaymentType[]
            {

                new PaymentType
                {
                     Id = 1,
                     Name = "Credit",
                },


                new PaymentType
                {
                    Id = 2,
                    Name = "Debit Card",
                },

                new PaymentType
                {
                    Id = 3,
                    Name = "Cryptocurrency",
                },

            });

            modelBuilder.Entity<Category>().HasData(new Category[]
            {
                new Category
                {
                    Id = 1,
                    Name = "Samsung",
                },
                new Category
                {
                    Id = 2,
                    Name = "Apple",
                },
                new Category
                {
                    Id = 3,
                    Name = "Sony",
                },
            });
           
        }

    }
}
