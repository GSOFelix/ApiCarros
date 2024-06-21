using Microsoft.EntityFrameworkCore;
using Senai.Core.Models;
using System.Reflection;

namespace Senai.Api.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
    {
        public DbSet<Cars> Carros { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
       => modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        /*O método ApplyConfigurationsFromAssembly busca todas as classes no assembly que implementam a interface
        IEntityTypeConfiguration<TEntity> e aplica essas configurações ao modelo.*/
    }
}
