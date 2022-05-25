using FeatureFlags.DataLayer.Entities.Base;

namespace FeatureFlags.DataLayer.Entities
{
    public class FeatureFlagEntity : BaseEntity
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
