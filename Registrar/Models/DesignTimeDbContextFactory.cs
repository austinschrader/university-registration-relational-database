using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Registrar.Models
{
  public class RegistrarContextFactory : IDesignTimeDbContextFactory<RegistrarContext>
  {
    RegistrarContext IDesignTimeDbContextFactory<RegistrarContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

          var builder = new DbContextOptionsBuilder<RegistrarContext>();
          var connectionString = configuration.GetConnectionString("DefaultConnection");

          builder.UseMySql(connectionString);

          return new RegistrarContext(builder.Options);
    }
  }
}