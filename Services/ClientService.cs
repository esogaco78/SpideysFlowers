using Autofac;
using BusinessLayer.Entities;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using System.Collections.Generic;

namespace Services
{
    public class ClientService
    {
        static IContainer _container;

        static ClientService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<BusinessRepository>().As<IBusinessRepository>();
            _container = builder.Build();
        }

        public static List<Client> GetAll()
        {
            return _container.Resolve<IClientInterface>().GetAll();
        }
    }
}
