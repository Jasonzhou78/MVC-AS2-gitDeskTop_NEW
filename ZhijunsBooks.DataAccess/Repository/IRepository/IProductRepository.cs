using ZhijunsBooks.Models;
using System;
using System.Collections.Generic;
using System.Text;
using ZhijunBooks.Models;

namespace ZhijunsBooks.DataAccess.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
    }
}
