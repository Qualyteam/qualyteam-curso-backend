using Microsoft.EntityFrameworkCore;
using ReceitasWebApi.Domain.Entities;

namespace ReceitasWebApi.Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Receita> Receitas { get; set; }
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receita>()
                .HasKey(receita => receita.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}