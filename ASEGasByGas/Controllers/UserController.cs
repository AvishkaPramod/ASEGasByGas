using gasbygas.lb.business.Manager;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.entities.User;
using gasbygas.lb.shared.Common;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASEGasByGas.Controllers
{
    [Route("")]
    [ApiController]
    public class UserController: ControllerBase
    {
        //The GasStock Manager
        private readonly IUserManager _userManager;

        //ILogger for error logs
        private readonly ILogger<UserController> _logger;

        // The service response error mappper
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        //The Entity Mapper
        private readonly IEntityMapper _entityMapper;

        public UserController(IUserManager userManager,
            ILogger<UserController> logger,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IEntityMapper entityMapper)
        {
            _userManager = userManager;
            _logger = logger;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _entityMapper = entityMapper;            
        }

        [HttpPost("user")]

        public async Task<ActionResult<ResponseBase>> UserManager([FromBody] UserRequest request)
        {
            try
            {
                if (request?.Action?.ToLower() == RequestActions.Add)
                {
                    var response = await _userManager.AddUserAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Update)
                {
                    var response = await _userManager.UpdateUserAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.List)
                {
                    var response = await _userManager.GetAllUserAsync();
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.View)
                {
                    var response = await _userManager.ViewUserDetailAsync(request);
                    return Ok(response);
                }
                else if (request?.Action?.ToLower() == RequestActions.Delete)
                {
                    var response = await _userManager.DeleteUserAsync(request);
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
