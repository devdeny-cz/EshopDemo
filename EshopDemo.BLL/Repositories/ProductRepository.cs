using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopDemo.BLL.Repositories
{
    /// <summary>
    /// Repository for DB context
    /// </summary>
    public class ProductRepository : IRepository<Product>
    {

        public Task<Product> Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Product entity)
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
