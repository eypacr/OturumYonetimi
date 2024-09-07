using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repositories
{
    public class RepositoryContext : IdentityDbContext<IdentityUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.ApplyConfiguration(new ProductConfig());
            // modelBuilder.ApplyConfiguration(new CategoryConfig());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
