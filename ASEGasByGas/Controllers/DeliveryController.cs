using gasbygas.lb.business.Manager;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.entities.Delivery;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.shared.Common;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASEGasByGas.Controllers
{
    [Route("")]
    [ApiController]
    public class DeliveryController: ControllerBase
    {
        //The  Manager
        private readonly IDeliveryManager _deliveryManager;

        //ILogger for error logs
        private readonly ILogger<DeliveryController> _logger;

        // The service response error mappper
        private readonly IMapper<ResponseMessage, ResponseBase> _ServiceResponseErrorMapper;

        //The Entity Mapper
        private readonly IEntityMapper _entityMapper;

        public DeliveryController(IDeliveryManager deliveryManager,
            ILogger<DeliveryController> logger,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IEntityMapper entityMapper)
        {
            _deliveryManager = deliveryManager;
            _logger = logger;
            _ServiceResponseErrorMapper = serviceResponseErrorMapper;
            _entityMapper = entityMapper;
        }

        [HttpPost("delivery")]
        public async Task<ActionResult<ResponseBase>> DeliveryManager([FromBody] DeliveryRequest request)
        {
            try
            {
                if (request?.Action?.ToLower() == RequestActions.Add)
                {
                    var response = await _deliveryManager.AddDeliveryAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Update)
                {
                    var response = await _deliveryManager.UpdateDeliveryAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.List)
                {
                    var response = await _deliveryManager.GetAllDeliveryAsync();
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.View)
                {
                    var response = await _deliveryManager.ViewDeliveryAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Delete)
                {
                    var response = await _deliveryManager.DeleteDeliveryAsync(request);
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
