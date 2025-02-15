using gasbygas.lb.business.Manager;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Relocated;
using gasbygas.lb.shared.Common;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASEGasByGas.Controllers
{
    [Route("")]
    [ApiController]
    public class RelocatedController: ControllerBase
    {
        //The  Manager
        private readonly IRelocatedManager _relocatedManager;

        //ILogger for error logs
        private readonly ILogger<RelocatedController> _logger;

        // The service response error mappper
        private readonly IMapper<ResponseMessage, ResponseBase> _ServiceResponseErrorMapper;

        //The Entity Mapper
        private readonly IEntityMapper _entityMapper;

        public RelocatedController(IRelocatedManager relocatedManager,
            ILogger<RelocatedController> logger,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IEntityMapper entityMapper)
        {
            _relocatedManager = relocatedManager;
            _logger = logger;
            _ServiceResponseErrorMapper = serviceResponseErrorMapper;
            _entityMapper = entityMapper;
        }

        [HttpPost("relocated")]
        public async Task<ActionResult<ResponseBase>> RelocatedManager([FromBody] RelocatedRequest request)
        {
            try
            {
                if (request?.Action?.ToLower() == RequestActions.Add)
                {
                    var response = await _relocatedManager.AddRelocatedAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Update)
                {
                    var response = await _relocatedManager.UpdateRelocatedAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.List)
                {
                    var response = await _relocatedManager.GetAllRelocatedAsync();
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.View)
                {
                    var response = await _relocatedManager.ViewRelocatedAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Delete)
                {
                    var response = await _relocatedManager.DeleteRelocatedAsync(request);
                    return Ok(response);
                }

                return BadRequest("Invalid Action.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, _ServiceResponseErrorMapper.Map(new ResponseMessage()));
            }
        }
    }
}
