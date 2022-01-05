using EntityFrameworkDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkDemo.Database
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> contextOptions):base(contextOptions)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
