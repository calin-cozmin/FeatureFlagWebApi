using FeatureFlags.DataLayer.Entities;
using FeatureFlags.RepositoryLayer.Base;

namespace FeatureFlags.RepositoryLayer
{
    public interface IFeatureFlagRepository : IRepository<FeatureFlagEntity>
    {
    }
}
