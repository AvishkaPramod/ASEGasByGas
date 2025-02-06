using AutoMapper;
using gasbygas.lb.business.Wrappers;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Cetificatevalidaton;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.business.Mappers
{
    public class CertificatevalidationSaveRequestMapper: IMapper<CertificatevalidationRequestWrapper, CertificatevalidationSaveRequest>
    {
        public CertificatevalidationSaveRequestMapper() 
        { }

        public CertificatevalidationSaveRequest Map(CertificatevalidationRequestWrapper input)
        {
            return new CertificatevalidationSaveRequest()
            {
                CertificateValidationID = input.Request.Attributes.CertificateValidationID,
                UserID = input.Request.Attributes.UserID,
                CustomerID = input.Request.Attributes.CustomerID,
                CertificateFile = input.Request.Attributes.CertificateFile,
                CertificateStatus = input.Request.Attributes.CertificateStatus,
                ValidationStatus = input.Request.Attributes.ValidationStatus,
                ValidationDate = input.Request.Attributes.ValidationDate

            };
        }

    }
}
