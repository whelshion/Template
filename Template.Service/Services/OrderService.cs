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
    public class OrderService : Service<Orders>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            this._orderRepository = orderRepository;
        }
    }
}
