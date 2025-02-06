using gasbygas.lb.entities.Cetificatevalidaton;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Manager
{
    public interface ICertificatevalidationManager
    {
        //Add 
        Task<ResponseBase> AddCertificatevalidationAsync(CertificatevalidationRequest request);

        //update 
        Task<ResponseBase> UpdateCertificatevalidationAsync(CertificatevalidationRequest request);

        //list 
        Task<ResponseBase> GetAllCertificatevalidationAsync();

        //View 
        Task<ResponseBase> ViewCertificatevalidationAsync(CertificatevalidationRequest request);

        //Delete 
        Task<ResponseBase> DeleteCertificatevalidationAsync(CertificatevalidationRequest request);
    }
}
