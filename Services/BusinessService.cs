﻿using Autofac;
using BusinessLayer;
using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BusinessService
    {
        static IContainer _container;

        static BusinessService()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<BusinessRepository>().As<IBusinessRepository>();
            _container = builder.Build();
        }

        public static bool Delete(int businessId)
        {
            return _container.Resolve<IBusinessRepository>().Delete(businessId);
        }

        public static List<Business> GetAll()
        {
            return _container.Resolve<IBusinessRepository>().GetAll();
        }

        public static Business Save(Business business, EntityState state)
        {
            if (state == EntityState.Added)
            {
                business.BusinessId = _container.Resolve<IBusinessRepository>().Insert(business);
            }
            else
            {
                _container.Resolve<IBusinessRepository>().Update(business);
            }

            return business;
        }
    }
}
