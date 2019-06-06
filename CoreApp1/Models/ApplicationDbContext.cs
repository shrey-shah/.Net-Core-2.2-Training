using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp1.Models
{
    /// <summary>
    /// The Data Access Layer Class
    /// DbContext will manage Db mapping and transactions
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// DbSet is a generic class that represents the mapping of T class with Table T
        /// It is also a cursor for CRUD operations.
        /// </summary>
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        /// <summary>
        /// DbContextOptions class will read connection string from 
        /// ConfigureServices() method from StartUp class
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
