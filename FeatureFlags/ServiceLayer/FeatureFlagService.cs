using AutoMapper;
using FeatureFlags.DataLayer.Entities;
using FeatureFlags.RepositoryLayer;
using FeatureFlags.ServiceLayer.Models;

namespace FeatureFlags.ServiceLayer
{
    public class FeatureFlagService : IFeatureFlagService
    {
        private readonly IFeatureFlagRepository _featureFlagRepository;
        private readonly IMapper _mapper; 

        public FeatureFlagService(IFeatureFlagRepository featureFlagRepository, IMapper mapper)
        {
            _featureFlagRepository = featureFlagRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<FeatureFlagModel>> GetAllAsync()
        {
            var featureFlags = await _featureFlagRepository.GetAllAsync();
            var mappedFeature = _mapper.Map<IEnumerable<FeatureFlagModel>>(featureFlags);
            return mappedFeature;
        }

        public async Task<FeatureFlagModel> GetByIdAsync(Guid featureId)
        {
            var entity = await _featureFlagRepository.GetByIdAsync(featureId);
            return _mapper.Map<FeatureFlagModel>(entity);
        }

        public async Task<FeatureFlagModel?> Add(FeatureFlagModel model)
        {
            var createdEntity = await _featureFlagRepository.AddAsync(_mapper.Map<FeatureFlagEntity>(model));
            return _mapper.Map<FeatureFlagModel>(createdEntity);
        }

        public async Task<FeatureFlagModel?> Update(FeatureFlagModel model)
        {
            var entity = await _featureFlagRepository.GetByIdAsync(model.Id);
            if (entity == null)
            {
                var updatedEntity = await _featureFlagRepository.UpdateAsync(_mapper.Map<FeatureFlagEntity>(model));
                return _mapper.Map<FeatureFlagModel>(updatedEntity);
            }

            return null;
        }

        public async Task<bool> RemoveById(Guid featureId)
        {
            return await _featureFlagRepository.RemoveAsync(featureId);
        }
    }
}
