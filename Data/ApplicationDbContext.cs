using CRUDStudent.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace CRUDStudent.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; }
    }
}
