namespace OnlineBookstore.DataAccess
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    class BookstoreContextFactory : IDesignTimeDbContextFactory<BookstoreContext>
    {
        public BookstoreContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookstoreContext>();
            optionsBuilder.UseSqlServer("Data Source =.\\SQLEXPRESS; Initial Catalog = Bookstore; Integrated Security = True");
            return new BookstoreContext(optionsBuilder.Options);

        }


        
    }
}
