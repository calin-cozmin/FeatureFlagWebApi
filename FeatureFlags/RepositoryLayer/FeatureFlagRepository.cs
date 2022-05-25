using FeatureFlags.DataLayer;
using FeatureFlags.DataLayer.Entities;
using FeatureFlags.RepositoryLayer.Base;

namespace FeatureFlags.RepositoryLayer
{
    public class FeatureFlagRepository : Repository<FeatureFlagEntity>, IFeatureFlagRepository
    {
        readonly DataContext _context;

        public FeatureFlagRepository(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
