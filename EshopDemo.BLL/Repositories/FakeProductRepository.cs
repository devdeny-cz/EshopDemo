using EshopDemo.BLL.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EshopDemo.BLL.Repositories
{
    internal class FakeProductRepository : IRepository<Product>
    {

        FakeContext _context;

        public FakeProductRepository()
        {
            _context = new FakeContext();
        }

        public Task<Product> Add(Product entity)
        {
            _context.Products.Add(entity);
            return  Task.FromResult<Product>(entity);
        }

        public bool Delete(Product entity)
        {
            if (_context.Products.Contains(entity))
            {
                _context.Products.Remove(entity);
                return true;
            }

            return false;
        }

        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(product => product.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products;
        }

        public bool Update(Product entity)
        {
            // we have existing item, so for fake, just return true.. Maybe we can find by id and replace, because the entity can be another reference
            return true;
        }
    }
}