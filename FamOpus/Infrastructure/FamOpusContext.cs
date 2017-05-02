using FamOpus.Domain.Aggregate;
using Microsoft.EntityFrameworkCore;

namespace FamOpus.Infrastructure
{
    public class FamOpusContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=aromato.db");
        }
    }
}