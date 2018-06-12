using Autofac;
using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataAccessLayer.Repositories;
using System.Collections.Generic;

namespace Services
{
    public class ClientService
    {
        static IContainer _container;

        static ClientService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<ClientRepository>().As<IClientRepository>();
            _container = builder.Build();
        }

        public static List<Client> GetAll()
        {
            return _container.Resolve<IClientRepository>().GetAll();
        }
    }
}
