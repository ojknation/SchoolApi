using Microsoft.EntityFrameworkCore;
using StudyApi.Models;

namespace StudyApi.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options) 
       {

       }

       public DbSet<School> Schools { get; set;}
       public DbSet<Department> Departments { get; set;}
       public DbSet<Course> Courses { get; set;}
       public DbSet<User> Users { get; set; }

    }
}