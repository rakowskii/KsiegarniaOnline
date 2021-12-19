namespace OnlineBookstore.DataAccess
{
    using System;
    using OnlineBookstore.DataAccess.Entities;
    using Microsoft.EntityFrameworkCore;
    
   public class BookstoreContext : DbContext
    {

        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ShoppingCartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .Property(x => x.Category)
                .HasConversion<string>()
                .HasMaxLength(50);

            modelBuilder
                .Entity<Product>()
                .Property(x => x.Cover)
                .HasConversion<string>()
                .HasMaxLength(20);


            modelBuilder
                .Entity<Product>()
                .Property(x => x.Type)
                .HasConversion<string>()
                .HasMaxLength(50);

           
        }



    }

}


      









