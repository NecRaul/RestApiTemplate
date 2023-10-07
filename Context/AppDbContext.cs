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
    }
}