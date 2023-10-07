using Microsoft.EntityFrameworkCore;
using RestApiTemplate.Models;

namespace RestApiTemplate.Context
{
    public class AppDbContext : DbContext
    {
        private static string _connectionString = "Server=localhost;Port=3306;Database=TemplateDB;User=sa;Password=123456";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }
        public DbSet<Template> Templates { get; set; }
        public DbSet<TemplateDetail> TemplateDetails { get; set; }
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            var entriesTemplate = ChangeTracker.Entries().Where(x => x.Entity is Template && (x.State == EntityState.Added || x.State == EntityState.Modified));
            foreach (var entry in entriesTemplate)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        ((Template)entry.Entity).CreatedDate = DateTime.Now;
                        ((Template)entry.Entity).UpdatedDate = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        Entry((Template)entry.Entity).Property(x => x.CreatedDate).IsModified = false;
                        ((Template)entry.Entity).UpdatedDate = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
    }
}