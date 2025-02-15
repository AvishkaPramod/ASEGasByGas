using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.GasRequest;
using gasbygas.lb.entities.Outlet;
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
    public class GasRequestRepository: IGasRequestRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<GasRequestRepository> _logger;

        //Constructor
        public GasRequestRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, 
            ILogger<GasRequestRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add 
        public async Task<GasRequestResponse> SaveGasRequestAsync(GasRequestSaveRequest request)
        {
            try
            {
                var GasRequestDetails = _entityMapper.Map<GasRequestSaveRequest, gasrequest>(request);
                var GasRequestSaveObj = _gasBygasContext.gasrequests.Add(GasRequestDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                // If status is "Accept", generate a token inside this method
                if (GasRequestSaveObj.RequestStatus == "accept")
                {
                    var token = new token
                    {
                        RequestID = GasRequestSaveObj.RequestID,
                        UserID = GasRequestSaveObj.UserID,
                        TokenNumber = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10), // Generate random token
                        GasQTY = GasRequestSaveObj.GasQTY,
                        GasType = GasRequestSaveObj.GasType,
                        UnitPrice = 3000.0, // Fetch actual price if needed
                        Total = GasRequestSaveObj.GasQTY * 3000.0,
                        PurchaseStartDate = DateTime.UtcNow,
                        PurchaseEndDate = DateTime.UtcNow.AddDays(14),
                        TokenReturnDate = DateTime.UtcNow.AddDays(16),
                        TokenStatus = "Active"
                    };

                    _gasBygasContext.tokens.Add(token);
                    await _gasBygasContext.SaveChangesAsync();
                }



                return _entityMapper.Map<gasrequest, GasRequestResponse>(GasRequestSaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<GasRequestResponse> UpdateGasRequestAsync(GasRequestSaveRequest request)
        {
            try
            {
                var GasRequest = await _gasBygasContext.gasrequests.FirstOrDefaultAsync(i => i.RequestID == request.RequestID);
                GasRequest.CustomerID = request.CustomerID;
                GasRequest.UserID = request.UserID;
                GasRequest.OutletID = request.OutletID;
                GasRequest.RequestCategory = request.RequestCategory;
                GasRequest.GasQTY = request.GasQTY;
                GasRequest.GasType = request.GasType;
                GasRequest.GasNeedDate = request.GasNeedDate;
                GasRequest.RequestDate = request.RequestDate;
                GasRequest.RequestStatus = request.RequestStatus;
                GasRequest.UpdatedDate = request.UpdatedDate;
          

                return _entityMapper.Map<gasrequest, GasRequestResponse>(GasRequest);


            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List 
        public async Task<List<GasRequestResponse>> GetAllGasRequestAsync()
        {
            try
            {
                var GasRequests = await _gasBygasContext.gasrequests
                .Select(u => new GasRequestResponse
                {
                    RequestID = u.RequestID,
                    CustomerID = u.CustomerID,
                    UserID = u.UserID,
                    OutletID = u.OutletID,
                    RequestCategory = u.RequestCategory,
                    GasQTY = u.GasQTY,
                    GasType = u.GasType,
                    GasNeedDate = u.GasNeedDate,
                    RequestDate = u.RequestDate,
                    RequestStatus = u.RequestStatus,
                    UpdatedDate = u.UpdatedDate
                    
                }).ToListAsync();

                return GasRequests;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        //View 
        public async Task<GasRequestResponse> GetGasRequestDetailAsync(GasRequestAttributes request)
        {
            try
            {
                var GasRequest = await _gasBygasContext.gasrequests
                    .Where(u => u.RequestID == request.RequestID)
                    .Select(u => new GasRequestResponse
                    {
                        RequestID = u.RequestID,
                        CustomerID = u.CustomerID,
                        UserID = u.UserID,
                        OutletID = u.OutletID,
                        RequestCategory = u.RequestCategory,
                        GasQTY = u.GasQTY,
                        GasType = u.GasType,
                        GasNeedDate = u.GasNeedDate,
                        RequestDate = u.RequestDate,
                        RequestStatus = u.RequestStatus,
                        UpdatedDate = u.UpdatedDate,
                        
                    }).FirstOrDefaultAsync();

                return GasRequest;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete  
        public async Task<GasRequestResponse> DeleteGasRequestAsync(GasRequestAttributes request)
        {
            try
            {
                var GasRequestObj = await _gasBygasContext.gasrequests.FirstOrDefaultAsync(x => x.RequestID == request.RequestID);
                _gasBygasContext.Remove(GasRequestObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<gasrequest, GasRequestResponse> (GasRequestObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
