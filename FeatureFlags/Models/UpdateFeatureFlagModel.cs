namespace FeatureFlags.Models
{
    public class UpdateFeatureFlagModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}
