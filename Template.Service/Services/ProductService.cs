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
    public class ProductService : Service<Products>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            this._productRepository = productRepository;
        }
    }
}
