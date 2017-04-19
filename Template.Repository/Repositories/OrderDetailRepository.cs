using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template.Entity;
using Template.Repository.IRepositories;

namespace Template.Repository.Repositories
{
    public class OrderDetailRepository : Repository<Order_Details>, IOrderDetailRepository
    {
    }
}
