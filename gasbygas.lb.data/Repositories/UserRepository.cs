using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.entities.User;
using gasbygas.lb.shared.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.data.Repositories
{
    public class UserRepository: IUserRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<UserRepository> _logger;

        //Constructor
        public UserRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<UserRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        //Add GasStock
        public async Task<UserResponse> SaveUserAsync(UserSaveRequest request)
        {
            try
            {
                var UserDetails = _entityMapper.Map<UserSaveRequest, user>(request);
                var UserResponse = _gasBygasContext.users.Add(UserDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<user, UserResponse>(UserResponse);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update GasStock
        public async Task<UserResponse> UpdateUserAsync(UserSaveRequest request)
        {
            try
            {
                var User = await _gasBygasContext.users.FirstOrDefaultAsync(i => i.UserID == request.UserID);
                User.OutletID = request.OutletID;
                User.UserName = request.UserName;
                User.Password = request.Password;
                User.FirstName = request.FirstName;
                User.LastName = request.LastName;
                User.Address = request.Address;
                User.Email = request.Email;
                User.Status = request.Status;
                User.UserRole = request.UserRole;
                User.LastLoginDate = request.LastLoginDate;
                User.UpdatedBy = request.UpdatedBy;

                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<user, UserResponse>(User);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<List<UserResponse>> GetAllUserAsync()
        {
            try
            {
                var Users = await _gasBygasContext.users
                    .Select(u => new UserResponse
                    {
                        UserID = u.UserID,
                        OutletID = u.OutletID,
                        UserName = u.UserName,
                        Password = u.Password,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Address = u.Address,
                        Email = u.Email,
                        Status = u.Status,
                        UserRole = u.UserRole,
                        CreatedDate = u.CreatedDate,
                        LastLoginDate = u.LastLoginDate,
                        UpdatedDate = u.UpdatedDate,
                        CreatedBy = u.CreatedBy,
                        UpdatedBy = u.UpdatedBy
                   
                    }).ToListAsync();

                return Users;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View
        public async Task<UserResponse> GetUserDetailAsync(UserAttributes request)
        {
            try
            {
                var User = await _gasBygasContext.users
                .Where(u => u.UserID == request.UserID)
                .Select(u => new UserResponse
                {
                    UserID = u.UserID,
                    OutletID = u.OutletID,
                    UserName = u.UserName,
                    Password = u.Password,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Address = u.Address,
                    Email = u.Email,
                    Status = u.Status,
                    UserRole = u.UserRole,
                    CreatedDate = u.CreatedDate,
                    LastLoginDate = u.LastLoginDate,
                    UpdatedDate = u.UpdatedDate,
                    CreatedBy = u.CreatedBy,
                    UpdatedBy = u.UpdatedBy
                }).FirstOrDefaultAsync();
                return User;
            }
            catch(Exception ex) 
            {
                _logger.LogError(ex.ToString() );
                throw;
            }

        }

        //Delete
        public async Task<UserResponse> DeleteUserAsync(UserAttributes request)
        {
            try
            {
                var UserObj = await _gasBygasContext.users.FirstOrDefaultAsync(x => x.UserID == request.UserID);
                _gasBygasContext.users.Remove(UserObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<user, UserResponse>(UserObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

    }
}
