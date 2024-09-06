// Entity Framework Core functionality
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Models
{
    // Handles database connection and mapping of models
    public class ApplicationDBContext : DbContext
    {
        // Passes configuration options to DbContext
        public ApplicationDBContext(DbContextOptions options) : base(options) { }

        // Represents 'Transactions' table
        public DbSet<Transaction> Transactions { get; set; }

        // Represents 'Categories' table
        public DbSet<Category> Categories { get; set; }
    }
}
