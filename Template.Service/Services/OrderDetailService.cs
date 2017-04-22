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
    public class OrderDetailService : Service<Order_Details>, IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        public OrderDetailService(IOrderDetailRepository orderDetailRepository) : base(orderDetailRepository)
        {
            this._orderDetailRepository = orderDetailRepository;
        }
    }
}
