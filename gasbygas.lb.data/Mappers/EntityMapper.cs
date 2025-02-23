using AutoMapper;
using gasbygas.lb.dbcontex.tables.Models;
using gasbygas.lb.entities.Cetificatevalidaton;
using gasbygas.lb.entities.Customer;
using gasbygas.lb.entities.Delivery;
using gasbygas.lb.entities.GasRequest;
using gasbygas.lb.entities.GasStock;
using gasbygas.lb.entities.Notification;
using gasbygas.lb.entities.Outlet;
using gasbygas.lb.entities.OutletStock;
using gasbygas.lb.entities.Payment;
using gasbygas.lb.entities.Relocated;
using gasbygas.lb.entities.Token;
using gasbygas.lb.entities.User;
using gasbygas.lb.shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gasbygas.lb.data.Mappers
{
    /// <summary>
    /// EntityMapper
    /// </summary>
    /// <seealso cref="gabygas.lb.shared.Contracts.IEntityMapper" />
    public class EntityMapper: IEntityMapper
    {
        /// <summary>
        /// The configuration
        /// </summary>
        private MapperConfiguration _config;

        /// <summary>
        /// The mapper
        /// </summary>
        private IMapper _mapper;


        /// <summary>
        /// Initializes a new instance of the <see cref="EntityMapper"/> class.
        /// </summary>
        public EntityMapper()
        {
            Configure();
            Create();
        }
        /// <summary>
        /// Configures this instance.
        /// </summary>
        /// 

        private void Configure() 
        {
            _config = new MapperConfiguration(cfg =>
            {
                //Customer
                cfg.CreateMap<customer, CustomerSaveRequest>().ReverseMap();
                cfg.CreateMap<customer, CustomerResponse>().ReverseMap();

                //GasStock
                cfg.CreateMap<gasstock, GasStockSaveRequest>().ReverseMap();
                cfg.CreateMap<gasstock, GasStockResponse>().ReverseMap();

                //User
                cfg.CreateMap<user, UserSaveRequest>().ReverseMap();
                cfg.CreateMap<user, UserResponse>().ReverseMap();

                //Certificatevalidatoin
                cfg.CreateMap<certificatevalidation, CertificatevalidationSaveRequest>().ReverseMap();
                cfg.CreateMap<certificatevalidation, CertificatevalidationResponse>().ReverseMap();

                //OutletStock
                cfg.CreateMap<outletstock, OutletStockSaveRequest>().ReverseMap();
                cfg.CreateMap<outletstock, OutletStockResponse>().ReverseMap();

                //Outlet
                cfg.CreateMap<outlet, OutletSaveRequest>().ReverseMap();
                cfg.CreateMap<outlet, OutletResponse>().ReverseMap();

                //Delivery
                cfg.CreateMap<delivery, DeliverySaveRequest>().ReverseMap();
                cfg.CreateMap<delivery, DeliveryResponse>().ReverseMap();

                //GasRequest
                cfg.CreateMap<gasrequest, GasRequestSaveRequest>().ReverseMap();
                cfg.CreateMap<gasrequest, GasRequestResponse>().ReverseMap();

                //Token
                cfg.CreateMap<token, Token>().ReverseMap();
                cfg.CreateMap<token, TokenSaveRequest>().ReverseMap();
                cfg.CreateMap<token, TokenResponse>().ReverseMap();
                 

                //Payment
                cfg.CreateMap<payment, PaymentSaveRequest>().ReverseMap();
                cfg.CreateMap<payment, PaymentResponse>().ReverseMap();

                //Notification
                cfg.CreateMap<notification, NotificationSaveRequest>().ReverseMap();
                cfg.CreateMap<notification, NotificationResponse>().ReverseMap();

                //Relocated
                cfg.CreateMap<relocated, RelocatedSaveRequest>().ReverseMap();
                cfg.CreateMap<relocated, RelocatedResponse>().ReverseMap();


            });

            
        }
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// 

        private void Create()
        {
            _mapper = _config.CreateMapper();
        }
        /// <summary>
        /// Maps the specified source.
        /// </summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }
    }
}
