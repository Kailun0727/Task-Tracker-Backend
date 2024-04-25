using Microsoft.EntityFrameworkCore;
using TaskAPI.Entities;

namespace TaskAPI.Data
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>().HasKey(t => t.Id);
        }

        //Name of the database table
        public DbSet<ToDoTask> Tasks { get; set; }
    }
}
