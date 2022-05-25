using FeatureFlags.ServiceLayer.Models.Base;

namespace FeatureFlags.ServiceLayer.Models
{
    public class FeatureFlagModel : BaseModel
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
