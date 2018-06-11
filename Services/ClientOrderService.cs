using Autofac;
using BusinessLayer.Entities;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using System.Collections.Generic;

namespace Services
{
    public class ClientOrderService
    {
        static IContainer _container;

        static ClientOrderService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ClientOrderRepository>().As<IClientOrderRepository>();
            _container = builder.Build();
        }

        public static List<ClientOrder> GetClientOrders(int id, ClientType type)
        {
            return _container.Resolve<IClientOrderRepository>().GetClientOrders(id, type);
        }
    }
}
