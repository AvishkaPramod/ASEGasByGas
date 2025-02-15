using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.OutletStock;
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
    public class OutletStockRepository: IOutletStockRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<OutletStockRepository> _logger;

        //Constructor
        public OutletStockRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<OutletStockRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add 
        public async Task<OutletStockResponse> SaveOutletStockAsync(OutletStockSaveRequest request)
        {
            try
            {
                var OutletStockDetails = _entityMapper.Map<OutletStockSaveRequest, outletstock>(request);
                var OutletStockSaveObj = _gasBygasContext.outletstocks.Add(OutletStockDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<outletstock, OutletStockResponse>(OutletStockSaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<OutletStockResponse> UpdateOutletStockAsync(OutletStockSaveRequest request)
        {
            try
            {
                var OutletStock = await _gasBygasContext.outletstocks.FirstOrDefaultAsync(i => i.OutletStockID == request.OutletStockID);
                OutletStock.GasType = request.GasType;
                OutletStock.EmptyGaSQTY = request.EmptyGaSQTY;
                OutletStock.GasStockLevel = request.GasStockLevel;
                OutletStock.ReceivingQTY = request.ReceivingQTY;
                OutletStock.ReceivingDate = request.ReceivingDate;
                OutletStock.EmptyReturnQTY = request.EmptyReturnQTY;
                OutletStock.OutletID = request.OutletID;
                
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<outletstock, OutletStockResponse>(OutletStock);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List 
        public async Task<List<OutletStockResponse>> GetAllOutletStockAsync()
        {
            try
            {
                var OutletStocks = await _gasBygasContext.outletstocks
                .Select(u => new OutletStockResponse
                {
                    OutletStockID = u.OutletStockID,
                    GasType = u.GasType,
                    EmptyGaSQTY = u.EmptyGaSQTY,
                    GasStockLevel = u.GasStockLevel,
                    ReceivingQTY = u.ReceivingQTY,
                    ReceivingDate = u.ReceivingDate,
                    EmptyReturnQTY = u.EmptyReturnQTY,
                    OutletID = u.OutletID 
                    
                }).ToListAsync();

                return OutletStocks;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        //View 
        public async Task<OutletStockResponse> GetOutletStockDetailAsync(OutletStockAttributes request)
        {
            try
            {
                var OutletStock = await _gasBygasContext.outletstocks
                    .Where(u => u.OutletStockID == request.OutletStockID)
                    .Select(u => new OutletStockResponse
                    {
                        OutletStockID = u.OutletStockID,
                        GasType = u.GasType,
                        EmptyGaSQTY = u.EmptyGaSQTY,
                        GasStockLevel = u.GasStockLevel,
                        ReceivingQTY = u.ReceivingQTY,
                        ReceivingDate = u.ReceivingDate,
                        EmptyReturnQTY = u.EmptyReturnQTY,
                        OutletID = u.OutletID

                    }).FirstOrDefaultAsync();

                return OutletStock;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete  
        public async Task<OutletStockResponse> DeleteOutletStockAsync(OutletStockAttributes request)
        {
            try
            {
                var OutletStockObj = await _gasBygasContext.outletstocks.FirstOrDefaultAsync(x => x.OutletStockID == request.OutletStockID);
                _gasBygasContext.Remove(OutletStockObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<outletstock, OutletStockResponse>(OutletStockObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
