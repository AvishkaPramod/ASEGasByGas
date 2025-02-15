using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.Payment;
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
    public class PaymentRepository: IPaymentRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<PaymentRepository> _logger;

        //Constructor
        public PaymentRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<PaymentRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add 
        public async Task<PaymentResponse> SavePaymentAsync(PaymentSaveRequest request)
        {
            try
            {
                // Check if the TokenID exists in the tokens table
                bool tokenExists = await _gasBygasContext.tokens.AnyAsync(t => t.TokenID == request.TokenID);
                if (!tokenExists)
                {
                    throw new Exception($"TokenID {request.TokenID} does not exist in the tokens table.");
                }

                var paymentDetails = _entityMapper.Map<PaymentSaveRequest, payment>(request);
                var paymentSaveObj = _gasBygasContext.payments.Add(paymentDetails).Entity;

                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<payment, PaymentResponse>(paymentSaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }


        //Update 
        public async Task<PaymentResponse> UpdatePaymentAsync(PaymentSaveRequest request)
        {
            try
            {
                var Payment = await _gasBygasContext.payments.FirstOrDefaultAsync(i => i.PaymentID == request.PaymentID);
                Payment.TokenID = request.TokenID;
                Payment.Status = request.Status;
                Payment.Bank = request.Bank;
                Payment.PaymentType = request.PaymentType;
                Payment.AccountNumber = request.AccountNumber;
                Payment.Price = request.Price;
                Payment.Branch = request.Branch;
                


                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<payment, PaymentResponse>(Payment);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List 
        public async Task<List<PaymentResponse>> GetAllPaymentAsync()
        {
            try
            {
                var Payments = await _gasBygasContext.payments
                .Select(u => new PaymentResponse
                {
                    PaymentID = u.PaymentID,
                    TokenID = u.TokenID,
                    Status = u.Status,
                    Bank = u.Bank,
                    PaymentType = u.PaymentType,
                    AccountNumber = u.AccountNumber,
                    Price = u.Price,
                    Branch = u.Branch

                }).ToListAsync();

                return Payments;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        //View 
        public async Task<PaymentResponse> GetPaymentDetailAsync(PaymentAttributes request)
        {
            try
            {
                var Payment = await _gasBygasContext.payments
                    .Where(u => u.PaymentID == request.PaymentID)
                    .Select(u => new PaymentResponse
                    {
                        PaymentID = u.PaymentID,
                        TokenID = u.TokenID,
                        Status = u.Status,
                        Bank = u.Bank,
                        PaymentType = u.PaymentType,
                        AccountNumber = u.AccountNumber,
                        Price = u.Price,
                        Branch = u.Branch

                    }).FirstOrDefaultAsync();

                return Payment;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete  
        public async Task<PaymentResponse> DeletePaymentAsync(PaymentAttributes request)
        {
            try
            {
                var PaymentObj = await _gasBygasContext.payments.FirstOrDefaultAsync(x => x.PaymentID == request.PaymentID);
                _gasBygasContext.Remove(PaymentObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<payment, PaymentResponse>(PaymentObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
