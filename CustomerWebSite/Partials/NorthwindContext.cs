using Microsoft.EntityFrameworkCore;

namespace CustomerWebSite.Models
{
    public partial class NorthwindContext : DbContext
    {
        public NorthwindContext() { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseSqlServer(config.GetConnectionString("NorthWind"));
            }
        }
    }
}
