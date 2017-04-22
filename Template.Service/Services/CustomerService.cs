using CacheManager.Core;
using CacheManager.Redis;
using DapperExtensions;
using Newtonsoft.Json;
using StackExchange.Redis;
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
        private readonly ConnectionMultiplexer _redisPlexer;

        public CustomerService(ICacheManager<IDictionary<string, object>> cacheManager, ConnectionMultiplexer redisPlexer, ICustomerRepository customerRepository, IOrderRepository orderRepository) : base(customerRepository)
        {
            this._cacheManager = cacheManager;
            this._customerRepository = customerRepository;
            this._orderRepository = orderRepository;
            this._redisPlexer = redisPlexer;
        }

        public IList<Orders> GetOrdersByCustomerId(string customerId)
        {
            var orderList = new List<Orders>();
            //var orderCaches = _cacheManager.Get("_order");
            //if (orderCaches != null && orderCaches.ContainsKey(customerId))
            //{
            //    orderList = (List<Orders>)orderCaches[customerId];
            //}
            //else
            //{
            //    var predicate = Predicates.Field<Orders>(f => f.CustomerID, Operator.Eq, customerId);
            //    var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate> { predicate } };
            //    orderList = _orderRepository.FindBy(pg).ToList();
            //    if (orderCaches == null)
            //        orderCaches = new Dictionary<string, object> { { customerId, orderList } };
            //    else
            //        orderCaches.Add(customerId, orderList);
            //    _cacheManager.Add("_order", orderCaches);
            //}

            using (_redisPlexer)
            {
                var redisDb = _redisPlexer.GetDatabase();
                string cacheString = redisDb.StringGet("_order_list_" + customerId);
                var cacheList = cacheString == null ? null : JsonConvert.DeserializeObject<List<Orders>>(redisDb.StringGet("_order_list_" + customerId));
                if (cacheList == null)
                {
                    using (var context = new DbFactory().CreateSqlConnection())
                    {
                        var predicate = Predicates.Field<Orders>(f => f.CustomerID, Operator.Eq, customerId);
                        var pg = new PredicateGroup { Operator = GroupOperator.And, Predicates = new List<IPredicate> { predicate } };
                        orderList = _orderRepository.FindBy(pg).ToList();
                        redisDb.StringSet("_order_list_" + customerId, JsonConvert.SerializeObject(orderList));
                    }
                }
                else
                {
                    orderList = cacheList;
                }
            }
            return orderList;
        }
    }
}
