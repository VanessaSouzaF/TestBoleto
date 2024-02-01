// Data/ApplicationContext.cs
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public DbSet<Boleto> Boletos { get; set; }
    public DbSet<Banco> Bancos { get; set; }
    public DbSet<UserModel> Users { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Defina aqui qualquer configuração específica do modelo, se necessário.
    }
}
