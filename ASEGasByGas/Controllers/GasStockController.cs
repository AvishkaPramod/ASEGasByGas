using gasbygas.lb.business.Manager;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.shared.Common;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASEGasByGas.Controllers
{
    [Route("")]
    [ApiController]
    public class GasStockController: ControllerBase
    {
        //The GasStock Manager
        private readonly IGasStockManager _gasStockManager;

        //ILogger for error logs
        private readonly ILogger<GasStockController> _logger;

        // The service response error mappper
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        //The Entity Mapper
        private readonly IEntityMapper _entityMapper;

        public GasStockController(IGasStockManager gasStockManager,
            ILogger<GasStockController> logger,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IEntityMapper entityMapper)
        {
            _gasStockManager = gasStockManager;
            _logger = logger;
            _entityMapper = entityMapper;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
        }

        [HttpPost("gasstock")]

        public async Task<ActionResult<ResponseBase>> GasStockManager([FromBody] GasStockRequest request)
        {
            try
            {
                if (request?.Action?.ToLower() == RequestActions.Add)
                {
                    var response = await _gasStockManager.AddGasStockAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Update)
                {
                    var response = await _gasStockManager.UpdateGasStockAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.List)
                {
                    var response = await _gasStockManager.GetAllGasStockAsync();
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.View)
                {
                    var response = await _gasStockManager.ViewGasStockAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Delete)
                {
                    var response = await _gasStockManager.DeleteGasStockAsync(request);
                    return Ok(response);
                }

                return BadRequest("Invalid Action.");
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, _serviceResponseErrorMapper.Map(new ResponseMessage()));
            }
        }
    }
}
