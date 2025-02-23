using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Delivery;
using gasbygas.lb.entities.Token;
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
    public class TokenRepository: ITokenRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<TokenRepository> _logger;

        //Constructor
        public TokenRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<TokenRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add 
        public async Task<TokenResponse> SaveTokenAsync(TokenSaveRequest request)
        {
            try
            {
                // Ensure request has a valid start date
                if (request.PurchaseStartDate == default)
                {
                    request.PurchaseStartDate = DateTime.UtcNow; // Default to today if not provided
                }

                // Automatically calculate the PurchaseEndDate (14 days from start)
                request.PurchaseEndDate = request.PurchaseStartDate.AddDays(14);

                // Ensure PickupDate is NOT set, as it will be updated later
                request.PickupDate = null;

                // Generate a unique TokenNumber (Example: "TKN-20240207-XYZ123")
                request.TokenNumber = $"TKN-{DateTime.UtcNow:yyyyMMdd}-{Guid.NewGuid().ToString().Substring(0, 6).ToUpper()}";

                // Map request to entity
                var TokenDetails = _entityMapper.Map<TokenSaveRequest, token>(request);

                // Save to database
                var TokenSaveObj = _gasBygasContext.tokens.Add(TokenDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                // Map entity back to response
                return _entityMapper.Map<token, TokenResponse>(TokenSaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update 
        public async Task<TokenResponse> UpdateTokenAsync(TokenSaveRequest request)
        {
            try
            {
                var Token = await _gasBygasContext.tokens.FirstOrDefaultAsync(i => i.TokenID == request.TokenID);
                Token.RequestID = request.RequestID;
                Token.ParentTokenID = request.ParentTokenID;
                Token.UserID = request.UserID;
                Token.GasQTY = request.GasQTY;
                Token.GasType = request.GasType;
                Token.UnitPrice = request.UnitPrice;
                Token.Total = request.Total;
                //Token.PurchaseStartDate = 
                //Token.PurchaseEndDate = 
                Token.PickupDate = DateTime.Now;
                Token.TokenReturnDate = request.TokenReturnDate;
                Token.TokenStatus = request.TokenStatus;
                Token.ReturnEmptyQTY = request.ReturnEmptyQTY;
                Token.EmptyGasStatus = request.EmptyGasStatus;
                Token.ReallocatedBy = request.ReallocatedBy;
                Token.TokenNumber = request.TokenNumber;



                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<token, TokenResponse>(Token);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List 
        public async Task<List<TokenResponse>> GetAllTokenAsync()
        {
            try
            {
                var Tokens = await _gasBygasContext.tokens
                .Select(u => new TokenResponse
                {
                    TokenID = u.TokenID,
                    RequestID = u.RequestID,
                    ParentTokenID = u.ParentTokenID,
                    UserID = u.UserID,
                    GasQTY = u.GasQTY,
                    GasType = u.GasType,
                    UnitPrice = u.UnitPrice,
                    Total = u.Total,
                    PurchaseStartDate = u.PurchaseStartDate,
                    PurchaseEndDate = u.PurchaseEndDate,
                    PickupDate = u.PickupDate,
                    TokenReturnDate = u.TokenReturnDate,
                    TokenStatus = u.TokenStatus,
                    ReturnEmptyQTY = u.ReturnEmptyQTY,
                    EmptyGasStatus = u.EmptyGasStatus,
                    ReallocatedBy = u.ReallocatedBy,
                    TokenNumber = u.TokenNumber

                }).ToListAsync();

                return Tokens;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }

        }

        //View 
        public async Task<TokenResponse> GetTokenDetailAsync(TokenAttributes request)
        {
            try
            {
                var Token = await _gasBygasContext.tokens
                    .Where(u => u.TokenID == request.TokenID)
                    .Select(u => new TokenResponse
                    {
                        TokenID = u.TokenID,
                        RequestID = u.RequestID,
                        ParentTokenID = u.ParentTokenID,
                        UserID = u.UserID,
                        GasQTY = u.GasQTY,
                        GasType = u.GasType,
                        UnitPrice = u.UnitPrice,
                        Total = u.Total,
                        PurchaseStartDate = u.PurchaseStartDate,
                        PurchaseEndDate = u.PurchaseEndDate,
                        PickupDate = u.PickupDate,
                        TokenReturnDate = u.TokenReturnDate,
                        TokenStatus = u.TokenStatus,
                        ReturnEmptyQTY = u.ReturnEmptyQTY,
                        EmptyGasStatus = u.EmptyGasStatus,
                        ReallocatedBy = u.ReallocatedBy,
                        TokenNumber = u.TokenNumber

                    }).FirstOrDefaultAsync();

                return Token;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Delete  
        public async Task<TokenResponse> DeleteTokenAsync(TokenAttributes request)
        {
            try
            {
                var TokenObj = await _gasBygasContext.tokens.FirstOrDefaultAsync(x => x.TokenID == request.TokenID);
                _gasBygasContext.Remove(TokenObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<token, TokenResponse>(TokenObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
