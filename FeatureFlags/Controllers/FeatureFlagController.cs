using AutoMapper;
using FeatureFlags.Models;
using FeatureFlags.ServiceLayer;
using FeatureFlags.ServiceLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlags.Controllers
{
    [ApiController]
    [Route("featureFlags")]
    public class FeatureFlagController : ControllerBase
    {
        private readonly ILogger<FeatureFlagController> _logger;
        private readonly IFeatureFlagService _featureFlagService;
        private readonly IMapper _mapper;

        public FeatureFlagController(ILogger<FeatureFlagController> logger, IFeatureFlagService featureFlagService, IMapper mapper)
        {
            _logger = logger;
            _featureFlagService = featureFlagService;
            _mapper = mapper;
        }

        [HttpGet(Name = "getAllFeatureFlags")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var featureFlags = await _featureFlagService.GetAllAsync();
                if (featureFlags.Any())
                {
                    return Ok(featureFlags);
                }

                return NotFound("No feature flag has been found");
            }
            catch (Exception exception)
            {
                _logger.LogError(new EventId(1), exception, null, null);
                return BadRequest("Something bad has happen. Please contact support team!");
            }
        }

        [HttpPost(Name = "create")]
        public async Task<IActionResult> Post([FromBody] CreateFeatureFlagModel createFeatureFlagModel)
        {
            try
            {
                var featureFlag = await _featureFlagService.Add(_mapper.Map<FeatureFlagModel>(createFeatureFlagModel));
                if (featureFlag != null)
                {
                    return Ok(featureFlag);
                }

                return NotFound("Something bad has happen. Please contact administrator!");
            }
            catch (Exception exception)
            {
                _logger.LogError(new EventId(1), exception, null, null);
                return BadRequest("Something bad has happen. Please contact support team!");
            }
        }

        [HttpPost(Name = "update")]
        public async Task<IActionResult> Put([FromBody] UpdateFeatureFlagModel updateFeatureFlagModel)
        {
            try
            {
                var featureFlag = await _featureFlagService.Update(_mapper.Map<FeatureFlagModel>(updateFeatureFlagModel));
                if (featureFlag != null)
                {
                    return Ok(featureFlag);
                }

                return NotFound("Something bad has happen. Please contact administrator!");
            }
            catch (Exception exception)
            {
                _logger.LogError(new EventId(1), exception, null, null);
                return BadRequest("Something bad has happen. Please contact support team!");
            }
        }

        [HttpDelete(Name = "remove")]
        public async Task<IActionResult> Delete(Guid featureFlagId)
        {
            try
            {
                var isRemoved = await _featureFlagService.RemoveById(featureFlagId);
                if (isRemoved)
                {
                    return Ok();
                }

                return NotFound("Something bad has happen. Please contact administrator!");
            }
            catch (Exception exception)
            {
                _logger.LogError(new EventId(1), exception, null, null);
                return BadRequest("Something bad has happen. Please contact support team!");
            }
        }
    }
}