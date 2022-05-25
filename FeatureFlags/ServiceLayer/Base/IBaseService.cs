using FeatureFlags.ServiceLayer.Models.Base;

namespace FeatureFlags.ServiceLayer.Base
{
    public interface IBaseService<TModel> where TModel : BaseModel
    {
        Task<IEnumerable<TModel>> GetAllAsync();

        Task<TModel> GetByIdAsync(Guid featureId);

        Task<TModel?> Add(TModel model);

        Task<TModel?> Update(TModel model);

        Task<bool> RemoveById(Guid featureId);
    }
}
