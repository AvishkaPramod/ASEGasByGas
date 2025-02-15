using gasbygas.lb.business.Manager;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.entities.GasRequest;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.shared.Common;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASEGasByGas.Controllers
{
    [Route("")]
    [ApiController]
    public class GasRequestController: ControllerBase
    {
        //The  Manager
        private readonly IGasRequestManager _gasRequestManager;

        //ILogger for error logs
        private readonly ILogger<GasRequestController> _logger;

        // The service response error mappper
        private readonly IMapper<ResponseMessage, ResponseBase> _ServiceResponseErrorMapper;

        //The Entity Mapper
        private readonly IEntityMapper _entityMapper;

        public GasRequestController(IGasRequestManager gasRequestManager,
            ILogger<GasRequestController> logger,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IEntityMapper entityMapper)
        {
            _gasRequestManager = gasRequestManager;
            _logger = logger;
            _ServiceResponseErrorMapper = serviceResponseErrorMapper;
            _entityMapper = entityMapper;
        }

        [HttpPost("order-management")]
        public async Task<ActionResult<ResponseBase>> GasRequestManager([FromBody] GasRequestRequest request)
        {
            try
            {
                if (request?.Action?.ToLower() == RequestActions.Add)
                {
                    var response = await _gasRequestManager.AddGasRequestAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Update)
                {
                    var response = await _gasRequestManager.UpdateGasRequestAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.List)
                {
                    var response = await _gasRequestManager.GetAllGasRequestAsync();
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.View)
                {
                    var response = await _gasRequestManager.ViewGasRequestAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Delete)
                {
                    var response = await _gasRequestManager.DeleteGasRequestAsync(request);
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
