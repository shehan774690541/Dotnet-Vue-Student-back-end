using learnMySQL.Models;
using Microsoft.EntityFrameworkCore;


namespace learnMySQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){

        }
        public virtual DbSet<StudentModel> Students { get; set; }

    }
}
