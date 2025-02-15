using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.shared.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.data.Repositories
{
    public class GasStockRepository: IGasStockRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<GasStockRepository> _logger;

        //Constructor
        public GasStockRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, 
            ILogger<GasStockRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        //Add GasStock
        public async Task<GasStockResponse> SaveGaasStockAsync(GasStockSaveRequest request)
        {
            try
            {
                var GasStockDetails = _entityMapper.Map<GasStockSaveRequest, gasstock>(request);
                var GasStockResponse = _gasBygasContext.gasstocks.Add(GasStockDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<gasstock, GasStockResponse>(GasStockResponse);

            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update GasStock
        public async Task<GasStockResponse> UpdateGasStockAsync(GasStockSaveRequest request)
        {
            try
            {
                var GasStock = await _gasBygasContext.gasstocks.FirstOrDefaultAsync(i => i.StockID == request.StockID);
                //GasStock.GasType = request.GasType;
                GasStock.DistributedQTY = request.DistributedQTY;
                GasStock.QuantityAvailable = request.QuantityAvailable;
                //GasStock.UnitPrice = request.UnitPrice;
                //GasStock.StockQuantity = request.StockQuantity;
                GasStock.StockStatus = request.StockStatus;
                GasStock.RecoveredemptyQTY = request.RecoveredemptyQTY;


                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<gasstock, GasStockResponse>(GasStock);
            } 
            catch(Exception ex) 
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List
        public async Task<List<GasStockResponse>> GetAllGasStockAsync()
        {
            try
            {
                var GasStockS = await _gasBygasContext.gasstocks
                    .Select(u => new GasStockResponse
                    {
                        StockID = u.StockID,
                        GasType = u.GasType,
                        DistributedQTY = u.DistributedQTY,
                        QuantityAvailable = u.QuantityAvailable,
                        UnitPrice = u.UnitPrice,
                        StockQuantity = u.StockQuantity,
                        StockStatus = u.StockStatus,
                        RecoveredemptyQTY = u.RecoveredemptyQTY,
                        UserID = u.UserID,

                    }).ToListAsync();

                return GasStockS;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString() );
                throw;
            }
        }

        //View
        public async Task<GasStockResponse> GetGasStockDetailAsync(GasStockAttributes request)
        {
            try
            {
                var GasStock = await _gasBygasContext.gasstocks
                    .Where(u => u.StockID == request.StockID)
                    .Select(u => new GasStockResponse
                    {
                        StockID = u.StockID,
                        GasType = u.GasType,
                        DistributedQTY = u.DistributedQTY,
                        QuantityAvailable = u.QuantityAvailable,
                        UnitPrice = u.UnitPrice,
                        StockQuantity = u.StockQuantity,
                        StockStatus = u.StockStatus,
                        RecoveredemptyQTY = u.RecoveredemptyQTY,
                        UserID = u.UserID
                    }).FirstOrDefaultAsync();

                return GasStock;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete
        public async Task<GasStockResponse> DeleteGasStockAsync(GasStockAttributes request)
        {
            try
            {
                var GasStockObj = await _gasBygasContext.gasstocks.FirstOrDefaultAsync(x => x.StockID == request.StockID);
                _gasBygasContext.Remove(GasStockObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<gasstock, GasStockResponse>(GasStockObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
