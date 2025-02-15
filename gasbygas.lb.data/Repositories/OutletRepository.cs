using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Outlet;
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
    public class OutletRepository: IOutletRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<OutletRepository> _logger;

        //Constructor
        public OutletRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<OutletRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add 
        public async Task<OutletResponse> SaveOutletAsync(OutletSaveRequest request)
        {
            try
            {
                var OutletDetails = _entityMapper.Map<OutletSaveRequest, outlet>(request);
                var OutletSaveObj = _gasBygasContext.outlets.Add(OutletDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<outlet, OutletResponse>(OutletSaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<OutletResponse> UpdateOutletAsync(OutletSaveRequest request)
        {
            try
            {
                var Outlet  = await _gasBygasContext.outlets.FirstOrDefaultAsync(i => i.OutletID == request.OutletID);
                Outlet.OutletName = request.OutletName;
                Outlet.ContactDetails = request.ContactDetails;
                Outlet.Location = request.Location;
                Outlet.District = request.District;
                              

                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<outlet, OutletResponse>(Outlet);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List 
        public async Task<List<OutletResponse>> GetAllOutletAsync()
        {
            try
            {
                var Outlets = await _gasBygasContext.outlets
                .Select(u => new OutletResponse
                {
                    OutletID = u.OutletID,
                    OutletName = u.OutletName,
                    ContactDetails = u.ContactDetails,
                    Location = u.Location,
                    District = u.District
                                       
                }).ToListAsync();

                return Outlets;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        //View 
        public async Task<OutletResponse> GetOutletDetailAsync(OutletAttributes request)
        {
            try
            {
                var Outlet = await _gasBygasContext.outlets
                    .Where(u => u.OutletID == request.OutletID)
                    .Select(u => new OutletResponse
                    {
                        OutletID = u.OutletID,
                        OutletName = u.OutletName,
                        ContactDetails = u.ContactDetails,
                        Location = u.Location,
                        District = u.District
                        
                    }).FirstOrDefaultAsync();

                return Outlet;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete  
        public async Task<OutletResponse> DeleteOutletAsync(OutletAttributes request)
        {
            try
            {
                var OutletObj = await _gasBygasContext.outlets.FirstOrDefaultAsync(x => x.OutletID == request.OutletID);
                _gasBygasContext.Remove(OutletObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map< outlet, OutletResponse>(OutletObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
