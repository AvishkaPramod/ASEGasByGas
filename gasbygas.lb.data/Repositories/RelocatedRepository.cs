using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Relocated;
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
    public class RelocatedRepository: IRelocatedRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<RelocatedRepository> _logger;

        //Constructor
        public RelocatedRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<RelocatedRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add 
        public async Task<RelocatedResponse> SaveRelocatedAsync(RelocatedSaveRequest request)
        {
            try
            {
                var RelocatedDetails = _entityMapper.Map<RelocatedSaveRequest, relocated>(request);
                var RelocatedSaveObj = _gasBygasContext.relocateds.Add(RelocatedDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<relocated, RelocatedResponse>(RelocatedSaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<RelocatedResponse> UpdateRelocatedAsync(RelocatedSaveRequest request)
        {
            try
            {
                var Relocated = await _gasBygasContext.relocateds.FirstOrDefaultAsync(i => i.RelocateID == request.RelocateID);
                Relocated.OldTokenID = request.OldTokenID;
                Relocated.NewTokenID = request.NewTokenID;
                Relocated.OldRequestID = request.OldRequestID;
                Relocated.NewRequestID = request.NewRequestID;
                Relocated.RelocationDate = request.RelocationDate;
                Relocated.RelocationStatus = request.RelocationStatus;
                

                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<relocated, RelocatedResponse>(Relocated);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List 
        public async Task<List<RelocatedResponse>> GetAllRelocatedAsync()
        {
            try
            {
                var Relocateds = await _gasBygasContext.relocateds
                .Select(u => new RelocatedResponse
                {
                    RelocateID = u.RelocateID,
                    OldTokenID = u.OldTokenID,
                    NewTokenID = u.NewTokenID,
                    OldRequestID = u.OldRequestID,
                    NewRequestID = u.NewRequestID,
                    RelocationDate = u.RelocationDate,
                    RelocationStatus = u.RelocationStatus

                }).ToListAsync();

                return Relocateds;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        //View 
        public async Task<RelocatedResponse> GetRelocatedDetailAsync(RelocatedAttributes request)
        {
            try
            {
                var Relocated = await _gasBygasContext.relocateds
                    .Where(u => u.RelocateID == request.RelocateID)
                    .Select(u => new RelocatedResponse
                    {
                        RelocateID = u.RelocateID,
                        OldTokenID = u.OldTokenID,
                        NewTokenID = u.NewTokenID,
                        OldRequestID = u.OldRequestID,
                        NewRequestID = u.NewRequestID,
                        RelocationDate = u.RelocationDate,
                        RelocationStatus = u.RelocationStatus

                    }).FirstOrDefaultAsync();

                return Relocated;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete  
        public async Task<RelocatedResponse> DeleteRelocatedAsync(RelocatedAttributes request)
        {
            try
            {
                var RelocatedObj = await _gasBygasContext.relocateds.FirstOrDefaultAsync(x => x.RelocateID == request.RelocateID);
                _gasBygasContext.Remove(RelocatedObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<relocated, RelocatedResponse>(RelocatedObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
