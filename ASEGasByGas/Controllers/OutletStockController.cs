using gasbygas.lb.business.Manager;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.OutletStock;
using gasbygas.lb.shared.Common;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASEGasByGas.Controllers
{
    [Route("")]
    [ApiController]
    public class OutletStockController: ControllerBase
    {
        //The  Manager
        private readonly IOutletStockManager _outletStockManager;

        //ILogger for error logs
        private readonly ILogger<OutletStockController> _logger;

        // The service response error mappper
        private readonly IMapper<ResponseMessage, ResponseBase> _ServiceResponseErrorMapper;

        //The Entity Mapper
        private readonly IEntityMapper _entityMapper;

        public OutletStockController(IOutletStockManager outletStockManager,
            ILogger<OutletStockController> logger,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IEntityMapper entityMapper)
        {
            _outletStockManager = outletStockManager;
            _logger = logger;
            _ServiceResponseErrorMapper = serviceResponseErrorMapper;
            _entityMapper = entityMapper;
        }

        [HttpPost("outletstock")]
        public async Task<ActionResult<ResponseBase>> OutletStockManager([FromBody] OutletStockRequest request)
        {
            try
            {
                if (request?.Action?.ToLower() == RequestActions.Add)
                {
                    var response = await _outletStockManager.AddOutletStockAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Update)
                {
                    var response = await _outletStockManager.UpdateOutletStockAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.List)
                {
                    var response = await _outletStockManager.GetAllOutletStockAsync();
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.View)
                {
                    var response = await _outletStockManager.ViewOutletStockAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Delete)
                {
                    var response = await _outletStockManager.DeleteOutletStockAsync(request);
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
