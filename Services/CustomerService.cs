using Autofac;
using BusinessLayer.Entities;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using System.Collections.Generic;

namespace Services
{
    public class CustomerService
    {
        static IContainer _container;

        static CustomerService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int customerId)
        {
            return _container.Resolve<ICustomerRepository>().Delete(customerId);
        }

        public static List<Customer> GetAll()
        {
            return _container.Resolve<ICustomerRepository>().GetAll();
        }

        public static Customer Save(Customer customer, EntityState state)
        {
            if (state == EntityState.Added)
            {
                customer.CustomerId = _container.Resolve<ICustomerRepository>().Insert(customer);
            }
            else
            {
                _container.Resolve<ICustomerRepository>().Update(customer);
            }

            return customer;
        }
    }
}
