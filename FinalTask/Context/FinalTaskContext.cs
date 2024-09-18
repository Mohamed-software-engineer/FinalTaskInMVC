using FinalTask.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalTask.Context
{
    public class FinalTaskContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FinalTask;Trusted_Connection=True;Encrypt=false");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _Users = new List<User>
            {
                new User {UserId = 1, FirstName = "Mohamed", LastName = "Saad", Email = "mohamed@gmail.com", Password = "123456"},
                new User {UserId = 2, FirstName = "Ahmed", LastName = "Yasser", Email = "ahmed@gmail.com", Password = "123456"},
                new User {UserId = 3, FirstName = "Khaled", LastName = "Ali", Email = "khaled@gmail.com", Password = "123456"},
                new User {UserId = 4, FirstName = "Randa", LastName = "Adel", Email = "randa@gmail.com", Password = "123456"},
                new User {UserId = 5, FirstName = "Tassnim", LastName = "Khaled", Email = "tassnim@gmail.com", Password = "123456"},
                new User {UserId = 6, FirstName = "Raina", LastName = "Atef", Email = "rania@gmail.com", Password = "123456"},
                new User {UserId = 7, FirstName = "Ali", LastName = "Reda", Email = "ali@gmail.com", Password = "123456"},
                new User {UserId = 8, FirstName = "Omar", LastName = "Adel", Email = "omar@gmail.com", Password = "123456"},
                new User {UserId = 9, FirstName = "Rana", LastName = "Mohamed", Email = "rana@gmail.com", Password = "123456"},
                new User {UserId = 10, FirstName = "Amr", LastName = "Mahmoud", Email = "amr@gmail.com", Password = "123456"},
            };

            //========================================================================//
            var _Products = new List<Product>
            {
                new Product {ProductId = 1, Title = "Kaps", Description = "", Price = 25, Quantity = 10, ImagePath = "", CategoryId = 1 },
                new Product {ProductId = 2, Title = "Shirts", Description = "", Price = 30, Quantity = 100, ImagePath = "", CategoryId = 1 },
                new Product {ProductId = 3, Title = "Ball", Description = "", Price = 15, Quantity = 20, ImagePath = "", CategoryId = 3 },
                new Product {ProductId = 4, Title = "Jeans", Description = "", Price = 40, Quantity = 30, ImagePath = "", CategoryId = 1 },
                new Product {ProductId = 5, Title = "Smartphones", Description = "", Price = 100, Quantity = 150, ImagePath = "", CategoryId = 2 },
                new Product {ProductId = 6, Title = "Tablets", Description = "", Price = 200, Quantity = 123, ImagePath = "", CategoryId = 2 },
                new Product {ProductId = 7, Title = "Bikes", Description = "", Price = 50, Quantity = 112, ImagePath = "", CategoryId = 3 },
                new Product {ProductId = 8, Title = "Remote Control Car", Description = "", Price = 150, Quantity = 133, ImagePath = "", CategoryId = 3 },
            };

            //==========================================================================//
            var _Categories = new List<Category>
            {
                new Category{CategoryId = 1, Name = "Clothes", Description = ""},
                new Category{CategoryId = 2, Name = "Electronics", Description = ""},
                new Category{CategoryId = 3, Name = "Toys", Description = ""},
            };
            //========================================================================//

            modelBuilder.Entity<User>().HasData(_Users);
            modelBuilder.Entity<Product>().HasData(_Products);
            modelBuilder.Entity<Category>().HasData(_Categories);
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
