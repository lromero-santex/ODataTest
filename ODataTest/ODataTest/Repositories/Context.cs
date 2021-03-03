using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ODataTest.Models;

namespace ODataTest.Repositories
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().OwnsOne(c => c.Address);
        }
    }
}