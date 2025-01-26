using gasbygas.lb.contracts.Repositories;
using gasbygas.lb.dbcontex.tables.Models;
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
    public class CustomerRepository: ICustomerRepositories
    {
        //The gastech context
        private readonly gasbygasContext _gasBygasContext;

        //The entity mapper
        private readonly IEntityMapper _entityMapper;

        // ILogger for error logs
        private readonly ILogger<CustomerRepository> _logger;

        //Constructor
        public CustomerRepository(gasbygasContext gasBygasContext, IEntityMapper entityMapper, ILogger<CustomerRepository> logger)
        {
            _gasBygasContext = gasBygasContext;
            _entityMapper = entityMapper;
            _logger = logger;
        }

        // Add customer
        public async  Task<CustomerResponse> SaveCustomerAsync(CustomerSaveRequest request)
        {
            try
            {
                var CustomerDetails = _entityMapper.Map<CustomerSaveRequest, customer>(request);
                var CustomerSaveObj = _gasBygasContext.customers.Add(CustomerDetails).Entity;
                await _gasBygasContext.SaveChangesAsync();

                return _entityMapper.Map<customer, CustomerResponse>(CustomerSaveObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //Update customer
        public async Task<CustomerResponse> UpdateCustomerAsync(CustomerSaveRequest request)
        {
            try
            {
                var Customers = await _gasBygasContext.customers.FirstOrDefaultAsync(i => i.CustomerId == request.CustomerId);
                Customers.FirstName = request.FirstName;
                Customers.LastName = request.LastName;
                Customers.NIC = request.Nic;
                Customers.Address = request.Address;
                Customers.ContactNumber = request.ContactNumber;
                Customers.Email = request.Email;
                Customers.CustomerType = request.CustomerType;
                Customers.RegistrationDate = request.RegistrationDate;
                Customers.Status = request.Status;
                Customers.UserName = request.UserName;
                Customers.Password = request.Password;
                Customers.UpdatedDate = request.UpdatedDate;
                Customers.UpdatedBy = request.UpdatedBy;

                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<customer, CustomerResponse>(Customers);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }

        //List Customer
        public async Task<List<CustomerResponse>> GetAllCutomerAsync()
        {
            try 
            {
                var Customers = await _gasBygasContext.customers
                .Select(u => new CustomerResponse
                {
                    CustomerId = u.CustomerId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Nic = u.NIC,
                    Address = u.Address,
                    ContactNumber = u.ContactNumber,
                    Email = u.Email,
                    CustomerType = u.CustomerType,
                    RegistrationDate = u.RegistrationDate,
                    Status = u.Status,
                    UserName = u.UserName,
                    Password = u.Password,
                    UpdatedDate = u.UpdatedDate,
                    UpdatedBy = u.UpdatedBy
                }).ToListAsync();

                return Customers;
            } catch(Exception ex) 
            { 
                _logger.LogError(ex.ToString()); 
                throw; 
            }
        }

        //View Customer
        public async Task<CustomerResponse> GetCustomerDetailAsync(CustomerAttributes request)
        {
            try
            {
                var Customers = await _gasBygasContext.customers
                    .Where(u => u.CustomerId == request.CustomerId)
                    .Select(u => new CustomerResponse
                    {
                        CustomerId = u.CustomerId,
                        FirstName = u.FirstName,
                        LastName = u.LastName,
                        Nic = u.NIC,
                        Address = u.Address,
                        ContactNumber = u.ContactNumber,
                        Email = u.Email,
                        CustomerType = u.CustomerType,
                        RegistrationDate = u.RegistrationDate,
                        Status = u.Status,
                        UserName = u.UserName,
                        Password = u.Password,
                        UpdatedDate = u.UpdatedDate,
                        UpdatedBy = u.UpdatedBy

                    }).FirstOrDefaultAsync();

                return Customers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw; 
            }
        }

        //Delete customer
        public async Task<CustomerResponse> DeleteCustomerAsync(CustomerAttributes request)
        {
            try
            {
                var CustomerObj = await _gasBygasContext.customers.FirstOrDefaultAsync(x => x.CustomerId == request.CustomerId);
                _gasBygasContext.Remove(CustomerObj);
                _gasBygasContext.SaveChanges();

                return _entityMapper.Map<customer, CustomerResponse>(CustomerObj);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }



    }
}
