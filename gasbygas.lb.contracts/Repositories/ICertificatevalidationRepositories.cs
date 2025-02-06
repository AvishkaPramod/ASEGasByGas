using gasbygas.lb.entities.Cetificatevalidaton;
using gasbygas.lb.entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.contracts.Repositories
{
    public interface ICertificatevalidationRepositories
    {
        // Add 
        Task<CertificatevalidationResponse> SaveCertificatevalidationAsync(CertificatevalidationSaveRequest request);

        //Update 
        Task<CertificatevalidationResponse> UpdateCertificatevalidationAsync(CertificatevalidationSaveRequest request);

        //List 
        Task<List<CertificatevalidationResponse>> GetAllCertificatevalidationAsync();

        //View 
        Task<CertificatevalidationResponse> GetCertificatevalidationDetailAsync(CertificatevalidationAttributes request);

        //Delete 
        Task<CertificatevalidationResponse> DeleteCertificatevalidationAsync(CertificatevalidationAttributes request);
    }
}
