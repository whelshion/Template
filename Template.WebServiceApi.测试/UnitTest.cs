﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Template.Repository.IRepositories;
using Template.Service.IServices;
using Template.Repository.Repositories;
using Template.Service.Services;
using CacheManager.Core;
using StackExchange.Redis;
using System.Collections.Generic;
using Unity.WebApi;

namespace Template.WebServiceApi.测试
{
    [TestClass]
    public class UnitTest
    {
        private static readonly UnityContainer _container = new UnityContainer();
        private ICustomerService _customerService;


        [TestInitialize]
        public void SetUp()
        {
            _container.RegisterType<IOrderRepository, OrderRepository>(new HierarchicalLifetimeManager());
            _container.RegisterType<IOrderService, OrderService>(new HierarchicalLifetimeManager());
            _container.RegisterType<IOrderDetailRepository, OrderDetailRepository>(new HierarchicalLifetimeManager());
            _container.RegisterType<IOrderDetailService, OrderDetailService>(new HierarchicalLifetimeManager());
            _container.RegisterType<ICustomerRepository, CustomerRepository>(new HierarchicalLifetimeManager());
            _container.RegisterType<ICustomerService, CustomerService>(new HierarchicalLifetimeManager());
            _container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            _container.RegisterType<IProductService, ProductService>(new HierarchicalLifetimeManager());

            _container.RegisterType(
                typeof(ICacheManager<>),
                new ContainerControlledLifetimeManager(),
                new InjectionFactory((c, targetType, name) => CacheFactory.FromConfiguration(targetType.GenericTypeArguments[0], "myCache")));


            _container.RegisterInstance(
                typeof(ConnectionMultiplexer),
                ConnectionMultiplexer.Connect("localhost"));


            _customerService = _container.Resolve<ICustomerService>();
        }

        [TestMethod]
        public void Test_GetOrdersByCustomerId_Service_Customer()
        {
            Assert.IsNotNull(_container);
            Assert.IsNotNull(_customerService);
            var list = _customerService.GetOrdersByCustomerId("RICAR");
        }
    }
}
