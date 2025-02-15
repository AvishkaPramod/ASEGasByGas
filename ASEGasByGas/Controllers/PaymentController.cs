using gasbygas.lb.business.Manager;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Payment;
using gasbygas.lb.shared.Common;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASEGasByGas.Controllers
{
    [Route("")]
    [ApiController]
    public class PaymentController: ControllerBase
    {
        //The  Manager
        private readonly IPaymentManager _paymentManager;

        //ILogger for error logs
        private readonly ILogger<PaymentController> _logger;

        // The service response error mappper
        private readonly IMapper<ResponseMessage, ResponseBase> _ServiceResponseErrorMapper;

        //The Entity Mapper
        private readonly IEntityMapper _entityMapper;

        public PaymentController(IPaymentManager paymentManager,
            ILogger<PaymentController> logger,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IEntityMapper entityMapper)
        {
            _paymentManager = paymentManager;
            _logger = logger;
            _ServiceResponseErrorMapper = serviceResponseErrorMapper;
            _entityMapper = entityMapper;
        }

        [HttpPost("payment")]
        public async Task<ActionResult<ResponseBase>> PaymentManager([FromBody] PaymentRequest request)
        {
            try
            {
                if (request?.Action?.ToLower() == RequestActions.Add)
                {
                    var response = await _paymentManager.AddPaymentAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Update)
                {
                    var response = await _paymentManager.UpdatePaymentAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.List)
                {
                    var response = await _paymentManager.GetAllPaymentAsync();
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.View)
                {
                    var response = await _paymentManager.ViewPaymentAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Delete)
                {
                    var response = await _paymentManager.DeletePaymentAsync(request);
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
