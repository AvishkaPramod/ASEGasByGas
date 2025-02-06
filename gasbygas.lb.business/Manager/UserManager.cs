using gasbygas.lb.business.Mappers;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.contracts.Manager;
using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.data.Repositories;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.entities.User;
using gasbygas.lb.shared.Contracts;
using gasbygas.lb.shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Manager
{
    public class UserManager: IUserManager
    {
        /// <summary>
        /// ILogger for error logs
        /// </summary>
        private readonly ILogger<UserManager> _logger;

        /// <summary>
        /// Banks repository
        /// </summary>
        private readonly IUserRepositories _userRepository;

        /// <summary>
        /// The service response error mapper
        /// </summary>
        private readonly IMapper<ResponseMessage, ResponseBase> _serviceResponseErrorMapper;

        /// <summary>
        /// The Banks save mapper
        /// </summary>
        private readonly IMapper<UserRequestWrapper, UserSaveRequest> _userSaveRequestMapper;

        private readonly IMapper<Object, ResponseBase> _serviceResponseMapper;

        //Constructor
        public UserManager(ILogger<UserManager> logger,
            IUserRepositories userRepository,
            IMapper<ResponseMessage, ResponseBase> serviceResponseErrorMapper,
            IMapper<UserRequestWrapper, UserSaveRequest> userSaveRequestMapper,
            IMapper<Object, ResponseBase> serviceResponseMapper
            )
        {
            _logger = logger;
            _userRepository = userRepository ;
            _serviceResponseErrorMapper = serviceResponseErrorMapper;
            _userSaveRequestMapper = userSaveRequestMapper;
            _serviceResponseMapper = serviceResponseMapper;
        }

        //Add 
        public async Task<ResponseBase> AddUserAsync(UserRequest request)
        {
            try
            {
                var UserSaveRequest = _userSaveRequestMapper.Map(new UserRequestWrapper { Request = request });

                var userSaveResponse = await _userRepository.SaveUserAsync(UserSaveRequest);

                return _serviceResponseMapper.Map(userSaveResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<ResponseBase> UpdateUserAsync(UserRequest request)
        {
            try
            {

                var UserUpdateRequest = _userSaveRequestMapper.Map(new UserRequestWrapper { Request = request });

                var UserResponse = await _userRepository.UpdateUserAsync(UserUpdateRequest);

                return _serviceResponseMapper.Map(UserResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<ResponseBase> GetAllUserAsync()
        {
            try
            {
                var UserResponse = await _userRepository.GetAllUserAsync();
                return _serviceResponseMapper.Map(UserResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<ResponseBase> ViewUserDetailAsync(UserRequest request)
        {
            try
            {
                var UserDetail = await _userRepository.GetUserDetailAsync(request.Attributes);
                return _serviceResponseMapper.Map(UserDetail);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<ResponseBase> DeleteUserAsync(UserRequest userrequest)
        {
            try
            {
                var result = await _userRepository.DeleteUserAsync(userrequest.Attributes);
                return _serviceResponseMapper.Map(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

    }
}
