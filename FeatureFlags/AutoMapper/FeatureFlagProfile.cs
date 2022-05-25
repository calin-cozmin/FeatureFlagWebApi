using AutoMapper;
using FeatureFlags.DataLayer.Entities;
using FeatureFlags.Models;
using FeatureFlags.ServiceLayer.Models;

namespace FeatureFlags.AutoMapper
{
    public class FeatureFlagProfile : Profile
    {
        public FeatureFlagProfile()
        {
            CreateMap<FeatureFlagEntity, FeatureFlagModel>().ReverseMap();
            CreateMap<IEnumerable<FeatureFlagModel>, IEnumerable<FeatureFlagModel>>().ReverseMap();
            CreateMap<CreateFeatureFlagModel, FeatureFlagModel>().ReverseMap();
            CreateMap<UpdateFeatureFlagModel, FeatureFlagModel>().ReverseMap();
        }
    }
}
