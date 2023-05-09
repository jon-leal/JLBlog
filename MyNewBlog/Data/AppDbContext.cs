using Microsoft.EntityFrameworkCore;

namespace JLBlog.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration) // injeção de dependência
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // conecta ao banco de dados blogDB através do app settings
            options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"));
        }

        public DbSet<Post> Posts { get; set; }
    }
}
