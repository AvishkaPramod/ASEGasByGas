using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Cetificatevalidaton;
using gasbygas.lb.entities.Customer;
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
    public class CertificatevalidationRepository: ICertificatevalidationRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<CertificatevalidationRepository> _logger;

        //Constructor
        public CertificatevalidationRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<CertificatevalidationRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add 
        public async Task<CertificatevalidationResponse> SaveCertificatevalidationAsync(CertificatevalidationSaveRequest request)
        {
            try
            {
                var CertificatevalidationDetails = _entityMapper.Map<CertificatevalidationSaveRequest, certificatevalidation>(request);
                var CertificatevalidationSaveObj = _gasBygasContext.certificatevalidations.Add(CertificatevalidationDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<certificatevalidation, CertificatevalidationResponse>(CertificatevalidationSaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update customer
        public async Task<CertificatevalidationResponse> UpdateCertificatevalidationAsync(CertificatevalidationSaveRequest request)
        {
            try
            {
                var Certificatevalidation = await _gasBygasContext.certificatevalidations.FirstOrDefaultAsync(i => i.CertificateValidationID == request.CertificateValidationID);
                Certificatevalidation.UserID = request.UserID;
                Certificatevalidation.CustomerID = request.CustomerID;
                Certificatevalidation.CertificateFileNumber = request.CertificateFileNumber;
                Certificatevalidation.CertificateStatus = request.CertificateStatus;
                Certificatevalidation.ValidationStatus = request.ValidationStatus;
                Certificatevalidation.ValidationDate = request.ValidationDate;

                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<certificatevalidation, CertificatevalidationResponse>(Certificatevalidation);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //list
        public async Task<List<CertificatevalidationResponse>> GetAllCertificatevalidationAsync()
        {
            try
            {
                var CertificateValidations = await _gasBygasContext.certificatevalidations
                    .Select(u => new CertificatevalidationResponse
                    {
                        CertificateValidationID = u.CertificateValidationID,
                        UserID = u.UserID,
                        CustomerID = u.CustomerID,
                        CertificateFileNumber = u.CertificateFileNumber,
                        CertificateStatus = u.CertificateStatus,
                        ValidationStatus = u.ValidationStatus,
                        ValidationDate = u.ValidationDate
                    }).ToListAsync();
                return CertificateValidations;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //View 
        public async Task<CertificatevalidationResponse> GetCertificatevalidationDetailAsync(CertificatevalidationAttributes request)
        {
            try
            {
                var CertificateValidation = await _gasBygasContext.certificatevalidations
                    .Where(u => u.CertificateValidationID == request.CertificateValidationID)
                    .Select(u => new CertificatevalidationResponse
                    {
                        CertificateValidationID = u.CertificateValidationID,
                        UserID = u.UserID,
                        CustomerID = u.CustomerID,
                        CertificateFileNumber = u.CertificateFileNumber,
                        CertificateStatus = u.CertificateStatus,
                        ValidationStatus = u.ValidationStatus,
                        ValidationDate = u.ValidationDate
                    }).FirstOrDefaultAsync();
                return CertificateValidation;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete 
        public async Task<CertificatevalidationResponse> DeleteCertificatevalidationAsync(CertificatevalidationAttributes request)
        {
            try
            {
                var CertificateValidationObj = await _gasBygasContext.certificatevalidations.FirstOrDefaultAsync(x => x.CertificateValidationID == request.CertificateValidationID);
                _gasBygasContext.certificatevalidations.Remove(CertificateValidationObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<certificatevalidation, CertificatevalidationResponse>(CertificateValidationObj);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
        

    }
}
