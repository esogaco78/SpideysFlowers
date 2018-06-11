using Autofac;
using BusinessLayer.Entities;
using BusinessLayer.Enums;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using System.Collections.Generic;

namespace Services
{
    public class OrderService
    {
        static IContainer _container;

        static OrderService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int orderId)
        {
            return _container.Resolve<IOrderRepository>().Delete(orderId);
        }

        public static List<Order> GetAll()
        {
            return _container.Resolve<IOrderRepository>().GetAll();
        }

        public static Order Save(Order order, EntityState state)
        {
            if (state == EntityState.Added)
            {
                order.OrderId = _container.Resolve<IOrderRepository>().Insert(order);
            }
            else
            {
                _container.Resolve<IOrderRepository>().Update(order);
            }

            return order;
        }
    }
}
