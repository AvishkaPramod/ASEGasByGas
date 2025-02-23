using gasbygas.lb.business.Manager;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.entities.Token;
using gasbygas.lb.entities.User;
using gasbygas.lb.shared.Common;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ASEGasByGas.Controllers
{
    [Route("")]
    [ApiController]
    public class TokenController: ControllerBase
    {
        //The GasStock Manager
        private readonly ITokenManager _tokenManager;

        //ILogger for error logs
        private readonly ILogger<TokenController> _logger;

        // The service response error mappper
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        //The Entity Mapper
        private readonly IEntityMapper _entityMapper;

        public TokenController(ITokenManager tokenManager,
            ILogger<TokenController> logger,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IEntityMapper entityMapper)
        {
            _tokenManager = tokenManager;
            _logger = logger;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _entityMapper = entityMapper;
        }

        [HttpPost("token")]

        public async Task<ActionResult<ResponseBase>> TokenManager([FromBody] TokenRequest request)
        {
            try
            {
                if (request?.Action?.ToLower() == RequestActions.Add)
                {
                    var response = await _tokenManager.AddTokenAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Update)
                {
                    var response = await _tokenManager.UpdateTokenAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.List)
                {
                    var response = await _tokenManager.GetAllTokenAsync();
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.View)
                {
                    var response = await _tokenManager.ViewTokenAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Delete)
                {
                    var response = await _tokenManager.DeleteTokenAsync(request);
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
