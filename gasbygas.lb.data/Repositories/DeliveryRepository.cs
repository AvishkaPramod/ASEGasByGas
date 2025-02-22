using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Delivery;
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
    public class DeliveryRepository: IDeliveryRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<DeliveryRepository> _logger;

        //Constructor
        public DeliveryRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<DeliveryRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add 
        public async Task<DeliveryResponse> SaveDeliveryAsync(DeliverySaveRequest request)
        {
            try
            {
                var DeliveryDetails = _entityMapper.Map<DeliverySaveRequest, delivery>(request);
                var DeliverySaveObj = _gasBygasContext.deliveries.Add(DeliveryDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<delivery, DeliveryResponse>(DeliverySaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<DeliveryResponse> UpdateDeliveryAsync(DeliverySaveRequest request)
        {
            try
            {
                var Delivery = await _gasBygasContext.deliveries.FirstOrDefaultAsync(i => i.DeliveryID == request.DeliveryID);
                Delivery.StockID = request.StockID;
                //Delivery.OutletID = request.OutletID;
                Delivery.UserID = request.UserID;
                Delivery.GasType = request.GasType;
                Delivery.GasType = request.GasType;
                Delivery.FullCylinderCount = request.FullCylinderCount;
                Delivery.GasStockDeliveryDate = request.GasStockDeliveryDate;
                Delivery.ArrivalAtOutlet = request.ArrivalAtOutlet;
                Delivery.DeliveryStatus = request.DeliveryStatus;
                Delivery.OutletRecipient = request.OutletRecipient;
                Delivery.EmptyCylinderCount = request.EmptyCylinderCount;
                Delivery.EmptyCylinderDeliveryDate = request.EmptyCylinderDeliveryDate;
                Delivery.ArrivalAtGasStock = request.ArrivalAtGasStock;
                Delivery.ReturnStatus = request.ReturnStatus;
                Delivery.StockRecipient = request.StockRecipient;
                Delivery.OutletStockID = request.OutletStockID;
                

                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<delivery, DeliveryResponse>(Delivery);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List 
        public async Task<List<DeliveryResponse>> GetAllDeliveryAsync()
        {
            try
            {
                var Deliveries = await _gasBygasContext.deliveries
                .Select(u => new DeliveryResponse
                {
                    DeliveryID = u.DeliveryID,
                    StockID = u.StockID,
                    //OutletID = u.OutletID,
                    UserID = u.UserID,
                    GasType = u.GasType,
                    FullCylinderCount = u.FullCylinderCount,
                    GasStockDeliveryDate = u.GasStockDeliveryDate,
                    ArrivalAtOutlet = u.ArrivalAtOutlet,
                    DeliveryStatus = u.DeliveryStatus,
                    OutletRecipient = u.OutletRecipient,
                    EmptyCylinderCount = u.EmptyCylinderCount,
                    EmptyCylinderDeliveryDate = u.EmptyCylinderDeliveryDate,
                    ArrivalAtGasStock = u.ArrivalAtGasStock,
                    ReturnStatus = u.ReturnStatus,
                    StockRecipient = u.StockRecipient,
                    OutletStockID = u.OutletStockID

                }).ToListAsync();

                return Deliveries;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        //View 
        public async Task<DeliveryResponse> GetDeliveryDetailAsync(DeliveryAttributes request)
        {
            try
            {
                var Delivery = await _gasBygasContext.deliveries
                    .Where(u => u.DeliveryID == request.DeliveryID)
                    .Select(u => new DeliveryResponse
                    {
                        DeliveryID = u.DeliveryID,
                        StockID = u.StockID,
                        //OutletID = u.OutletID,
                        UserID = u.UserID,
                        GasType = u.GasType,
                        FullCylinderCount = u.FullCylinderCount,
                        GasStockDeliveryDate = u.GasStockDeliveryDate,
                        ArrivalAtOutlet = u.ArrivalAtOutlet,
                        DeliveryStatus = u.DeliveryStatus,
                        OutletRecipient = u.OutletRecipient,
                        EmptyCylinderCount = u.EmptyCylinderCount,
                        EmptyCylinderDeliveryDate = u.EmptyCylinderDeliveryDate,
                        ArrivalAtGasStock = u.ArrivalAtGasStock,
                        ReturnStatus = u.ReturnStatus,
                        StockRecipient = u.StockRecipient,
                        OutletStockID = u.OutletStockID

                    }).FirstOrDefaultAsync();

                return Delivery;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete  
        public async Task<DeliveryResponse> DeleteDeliveryAsync(DeliveryAttributes request)
        {
            try
            {
                var DeliveryObj = await _gasBygasContext.deliveries.FirstOrDefaultAsync(x => x.DeliveryID == request.DeliveryID);
                _gasBygasContext.Remove(DeliveryObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<delivery, DeliveryResponse>(DeliveryObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
