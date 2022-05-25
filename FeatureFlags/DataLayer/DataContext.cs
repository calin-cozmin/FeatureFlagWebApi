using FeatureFlags.DataLayer.Constants;
using FeatureFlags.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeatureFlags.DataLayer
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionString = Configuration.GetConnectionString(DataLayerConstants.DataBaseConfigName);
            options.UseSqlServer(connectionString);
        }

        public DbSet<FeatureFlagEntity> Flags { get; set; }
    }
}
