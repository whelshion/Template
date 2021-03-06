﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Entity;

namespace Template.Service.IServices
{
    public interface ICustomerService : IService<Customers>
    {
        IList<Orders> GetOrdersByCustomerId(string customerId);
    }
}
