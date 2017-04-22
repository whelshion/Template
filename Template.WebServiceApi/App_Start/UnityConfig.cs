using CacheManager.Core;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Template.Repository.IRepositories;
using Template.Repository.Repositories;
using Template.Service.IServices;
using Template.Service.Services;
using Unity.WebApi;

namespace Template.WebServiceApi
{
    public static class UnityConfig
    {
        private static readonly UnityContainer _container = new UnityContainer();
        public static void RegisterComponents()
        {
            //var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

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

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(_container);
        }
    }
}