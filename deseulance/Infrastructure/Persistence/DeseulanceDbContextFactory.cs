using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence;

public class DeseulanceDbContextFactory : IDesignTimeDbContextFactory<DeseulanceDbContext>
{
    public DeseulanceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<DeseulanceDbContext>();
        var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings__DefaultConnection")
            ?? "Server=localhost,1433;Database=deseulance;User Id=sa;Password=Your_password123;TrustServerCertificate=True";

        optionsBuilder.UseSqlServer(connectionString);

        return new DeseulanceDbContext(optionsBuilder.Options);
    }
}
