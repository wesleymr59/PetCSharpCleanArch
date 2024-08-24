using Microsoft.EntityFrameworkCore;
using Pet.App.Entities.PgSQL;

namespace Pet.Infrastructure.Data.Config
{
    public class AppDbContext : DbContext
    {
        public DbSet<Matriz> Matriz { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Remove o método OnConfiguring se você estiver configurando o DbContext em Program.cs
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseNpgsql("Host=localhost;Database=Escola;Username=wesley;Password=root");
        //     base.OnConfiguring(optionsBuilder);
        // }
    }
}
