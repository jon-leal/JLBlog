using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace JLBlog.Data;

public class JLBlogContext : IdentityDbContext<BlogUser>
{
    protected readonly IConfiguration Configuration;
    public JLBlogContext(DbContextOptions<JLBlogContext> options, IConfiguration configuration)
        : base(options)
    {
        Configuration = configuration;
    }

    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        // conecta ao banco de dados blogDB através do app settings
        options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection"));
    }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
