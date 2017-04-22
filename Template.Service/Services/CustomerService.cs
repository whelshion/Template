using CacheManager.Core;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Entity;
using Template.Repository;
using Template.Repository.IRepositories;
using Template.Service.IServices;

namespace Template.Service.Services
{
    public class CustomerService : Service<Customers>, ICustomerService
    {
        private readonly ICacheManager<IDictionary<string, object>> _cacheManager;
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;

        public CustomerService(ICacheManager<IDictionary<string, object>> cacheManager, ICustomerRepository customerRepository, IOrderRepository orderRepository) : base(customerRepository)
        {
            this._cacheManager = cacheManager;
            this._customerRepository = customerRepository;
            this._orderRepository = orderRepository;
        }

        public IList<Orders> GetOrdersByCustomerId(string customerId)
        {
            var orderList = new List<Orders>();
            using (var context = new DbFactory().CreateSqlConnection())
            {
                var orderCaches = _cacheManager.Get("_order");
                if (orderCaches != null && orderCaches.ContainsKey(customerId))
                {
                    orderList = (List<Orders>)orderCaches[customerId];
                }
                else
                {
                    var predicate = Predicates.Field<Orders>(f => f.CustomerID, Operator.Eq, customerId);
                    var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate> { predicate } };
                    orderList = _orderRepository.FindBy(pg).ToList();
                    if (orderCaches == null)
                        orderCaches = new Dictionary<string, object> { { customerId, orderList } };
                    else
                        orderCaches.Add(customerId, orderList);
                    _cacheManager.Add("_order", orderCaches);
                }
            }
            return orderList;
        }
    }
}
