using LibrarySystem.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Infrastructure.Persistence
{
    public class LibrarySystemDbContext : DbContext
    {
        public LibrarySystemDbContext(DbContextOptions<LibrarySystemDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Book>(e =>
                {
                    e.HasKey(b => b.Id);

                    e.HasMany(b => b.LoanList)
                     .WithOne(l => l.Book)
                     .HasForeignKey(l => l.IdBook)
                     .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<Loan>(e =>
                {
                    e.HasKey(l => l.Id);

                    e.HasOne(l => l.User)
                     .WithMany(u => u.Loans)
                     .HasForeignKey(u => u.IdUser)
                     .OnDelete(DeleteBehavior.Restrict);

                    e.HasOne(l => l.Book)
                     .WithMany(b => b.LoanList)
                     .HasForeignKey(l => l.IdBook)
                     .OnDelete(DeleteBehavior.Restrict);
                });

            builder
                .Entity<User>(e =>
                {
                    e.HasKey(l => l.Id);

                    e.HasMany(u => u.Loans)
                     .WithOne(l => l.User)
                     .HasForeignKey(l => l.IdUser);
                });
            base.OnModelCreating(builder);
        }
    }
}
